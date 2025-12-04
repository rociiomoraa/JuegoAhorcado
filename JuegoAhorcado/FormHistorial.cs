using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JuegoAhorcado.Servicios;
using JuegoAhorcado.Repositorios;

namespace JuegoAhorcado
{
    public partial class FormHistorial : Form
    {
        private ServicioSesionJugador sesion;
        private RepositorioPartidas repoPartidas = new RepositorioPartidas();
        private RepositorioPalabras repoPalabras = new RepositorioPalabras();
        private RepositorioCategorias repoCategorias = new RepositorioCategorias();

        public FormHistorial(ServicioSesionJugador sesion)
        {
            InitializeComponent();
            this.sesion = sesion;
        }

        private void FormHistorial_Load(object sender, EventArgs e)
        {
            CargarHistorial();
        }

        private void CargarHistorial()
        {
            // Obtengo las partidas del usuario actual.
            var partidas = repoPartidas.ObtenerPorUsuario(sesion.UsuarioActual.Id);

            // Mapear datos para mostrarlos en la tabla
            var datos = partidas.Select(p =>
            {
                var palabra = repoPalabras.ObtenerPorId(p.PalabraId);
                var categoria = repoCategorias.ObtenerPorId(palabra.CategoriaId);

                return new
                {
                    Id = p.Id,
                    Palabra = palabra.Palabra,
                    Categoria = categoria.Nombre,
                    Resultado = p.Resultado,
                    Puntos = p.PuntuacionObtenida,
                    Fecha = p.Fecha.ToString("dd/MM/yyyy HH:mm")
                };
            }).ToList();

            dgvHistorial.DataSource = datos;

            CalcularEstadisticas(partidas);
        }

        private void CalcularEstadisticas(System.Collections.Generic.List<Modelos.HistorialPartida> lista)
        {
            int total = lista.Count;
            int ganadas = lista.Count(x => x.Resultado == "acertada");
            int perdidas = total - ganadas;

            double porcentaje = (total > 0)
                ? (ganadas * 100.0 / total)
                : 0;

            lblTotalPartidas.Text = total.ToString();
            lblGanadas.Text = ganadas.ToString();
            lblPerdidas.Text = perdidas.ToString();
            lblAcierto.Text = porcentaje.ToString("0.00") + "%";
            lblRachaMaxima.Text = sesion.UsuarioActual.RachaMaxima.ToString();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            FormMenuPrincipal menu = new FormMenuPrincipal(sesion);
            menu.Show();
            this.Hide();
        }
    }
}
