using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using JuegoAhorcado.Modelos;
using JuegoAhorcado.Repositorios;
using JuegoAhorcado.Servicios;
using JuegoAhorcado.Motor;

namespace JuegoAhorcado
{
    public partial class FormJuego : Form
    {
        private ServicioSesionJugador sesion;

        private RepositorioCategorias repoCategorias = new RepositorioCategorias();
        private RepositorioPalabras repoPalabras = new RepositorioPalabras();
        private RepositorioPartidas repoPartidas = new RepositorioPartidas();

        private MotorAhorcado juego;
        private EntradaPalabra palabraElegida;

        private int rachaVictorias = 0;


        public FormJuego(ServicioSesionJugador sesion)
        {
            InitializeComponent();
            this.sesion = sesion;
        }

        private void FormJuego_Load_1(object sender, EventArgs e)
        {
            lblRachaActual.Text = "Racha actual: 0";
            lblRachaMaxima.Text = "Racha máxima: " + sesion.UsuarioActual.RachaMaxima;

            var categorias = repoCategorias.ObtenerTodas();

            cbCategorias.DataSource = categorias;
            cbCategorias.DisplayMember = "Nombre";
            cbCategorias.ValueMember = "Id";

            ConfigurarEventosTeclado();
        }

        private void ConfigurarEventosTeclado()
        {
            foreach (Control c in panelLetras.Controls)
            {
                if (c is Button btnLetra)
                {
                    btnLetra.Click -= btnLetra_Click;
                    btnLetra.Click += btnLetra_Click;
                }
            }
        }

        private void btnLetra_Click(object sender, EventArgs e)
        {
            if (juego == null || juego.PartidaFinalizada)
                return;

            Button btn = sender as Button;
            char letra = btn.Text.ToUpper()[0];

            bool acierto = juego.ProbarLetra(letra);

            btn.Enabled = false;

            ActualizarPantalla();

            if (juego.PartidaFinalizada)
                FinalizarPartida();
        }

        private void btnComenzarPartida_Click(object sender, EventArgs e)
        {
            if (cbCategorias.SelectedItem == null)
            {
                MessageBox.Show("Debes seleccionar una categoría para comenzar la partida.",
                                "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // SOLUCIÓN DEFINITIVA PARA OBJETOS ANÓNIMOS
            var item = cbCategorias.SelectedItem;
            int categoriaId = (int)item.GetType().GetProperty("Id").GetValue(item, null);

            palabraElegida = repoPalabras.ObtenerAleatoria(categoriaId);

            if (palabraElegida == null)
            {
                MessageBox.Show("No hay palabras disponibles en esta categoría.",
                                "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            juego = new MotorAhorcado(palabraElegida);

            ActivarTodasLasLetras();
            ActualizarPantalla();
            panelDibujo.Invalidate();
        }

        private void ActualizarPantalla()
        {
            if (palabraElegida.Palabra.Contains(" "))
                lblPalabra.Text = juego.ObtenerPalabraOcultaMultilinea();
            else
                lblPalabra.Text = juego.PalabraOculta;

            lblAciertos.Text = "Aciertos: " + juego.Aciertos.ToString();
            lblErrores.Text = "Errores: " + juego.Errores.ToString();
            lblPuntuacion.Text = "Puntuación: " + juego.ObtenerPuntuacion().ToString();

            lblRachaActual.Text = "Racha actual: " + rachaVictorias;
            lblRachaMaxima.Text = "Racha máxima: " + sesion.UsuarioActual.RachaMaxima;

            panelDibujo.Invalidate();
        }


        private void panelDibujo_Paint(object sender, PaintEventArgs e)
        {
            if (juego == null)
                return;

            DibujarAhorcado(e.Graphics, juego.Errores);
        }


        private void DibujarAhorcado(Graphics g, int errores)
        {
            Pen lapiz = new Pen(Color.White, 4);

            if (errores >= 1)
                g.DrawLine(lapiz, 30, 430, 270, 430);

            if (errores >= 2)
                g.DrawLine(lapiz, 80, 430, 80, 60);

            if (errores >= 3)
                g.DrawLine(lapiz, 80, 60, 210, 60);

            if (errores >= 4)
                g.DrawLine(lapiz, 210, 60, 210, 110);

            if (errores >= 5)
                g.DrawEllipse(lapiz, 185, 110, 50, 50);

            if (errores >= 6)
                g.DrawLine(lapiz, 210, 160, 210, 250);

            if (errores >= 7)
                g.DrawLine(lapiz, 210, 180, 170, 220);

            if (errores >= 8)
                g.DrawLine(lapiz, 210, 180, 250, 220);

            if (errores >= 9)
                g.DrawLine(lapiz, 210, 250, 180, 300);

            if (errores >= 10)
                g.DrawLine(lapiz, 210, 250, 240, 300);
        }

        private void btnResolver_Click(object sender, EventArgs e)
        {
            if (juego == null)
                return;

            juego.ForzarFinalizacionManual();
            FinalizarPartida();
        }

        private void FinalizarPartida()
        {
            int puntuacionBase = juego.ObtenerPuntuacion();
            int bonusRacha = CalcularBonusRacha(rachaVictorias);
            int puntuacion = puntuacionBase + bonusRacha;

            HistorialPartida h = new HistorialPartida()
            {
                UsuarioId = sesion.UsuarioActual.Id,
                PalabraId = palabraElegida.Id,
                Resultado = juego.PalabraAcertada ? "acertada" : "fallada",
                PuntuacionObtenida = puntuacion,
                Fecha = DateTime.Now
            };

            repoPartidas.RegistrarPartida(h);

            if (juego.PalabraAcertada)
                rachaVictorias++;
            else
                rachaVictorias = 0;

            RepositorioUsuarios repoUsuarios = new RepositorioUsuarios();

            if (rachaVictorias > sesion.UsuarioActual.RachaMaxima)
            {
                repoUsuarios.ActualizarRachaMaxima(sesion.UsuarioActual.Id, rachaVictorias);
                sesion.UsuarioActual.RachaMaxima = rachaVictorias;
            }

            string mensaje;

            if (juego.PalabraAcertada)
            {
                mensaje =
                    "¡Has acertado la palabra!\n" +
                    "Puntuación base: " + puntuacionBase +
                    "\nBonus por racha: " + bonusRacha +
                    "\nPuntuación total: " + puntuacion;
            }
            else
            {
                mensaje = "Has perdido.\nLa palabra era: " + palabraElegida.Palabra;
            }

            if (rachaVictorias >= 2 && juego.PalabraAcertada)
                mensaje += "\nRacha actual de victorias: " + rachaVictorias;

            MessageBox.Show(mensaje, "Fin de la partida", MessageBoxButtons.OK, MessageBoxIcon.Information);

            DialogResult opcion = MessageBox.Show(
                "¿Quieres jugar otra vez o volver al menú principal?",
                "¿Qué deseas hacer?",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (opcion == DialogResult.Yes)
                ReiniciarFormulario();
            else
            {
                FormMenuPrincipal menu = new FormMenuPrincipal(sesion);
                menu.Show();
                this.Hide();
            }
        }

        private int CalcularBonusRacha(int racha)
        {
            if (racha >= 10) return 50;
            if (racha >= 6) return 30;
            if (racha >= 4) return 20;
            if (racha >= 2) return 10;
            return 0;
        }

        private void ReiniciarFormulario()
        {
            juego = null;
            palabraElegida = null;

            lblPalabra.Text = "";
            lblAciertos.Text = "Aciertos:";
            lblErrores.Text = "Errores:";
            lblPuntuacion.Text = "Puntuación: ";

            lblRachaActual.Text = "Racha actual: " + rachaVictorias;
            lblRachaMaxima.Text = "Racha máxima: " + sesion.UsuarioActual.RachaMaxima;

            panelDibujo.Invalidate();
            ActivarTodasLasLetras();
            cbCategorias.SelectedIndex = -1;
        }

        private void ActivarTodasLasLetras()
        {
            foreach (Control c in panelLetras.Controls)
            {
                if (c is Button btnLetra)
                    btnLetra.Enabled = true;
            }
        }
    }
}
