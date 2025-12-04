using JuegoAhorcado.Modelos;
using JuegoAhorcado.Servicios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace JuegoAhorcado
{
    public partial class FormMenuPrincipal : Form
    {
        // Objeto que contiene la información del usuario que ha iniciado sesión.
        private ServicioSesionJugador sesion;

        // Constructor utilizado desde el formulario de inicio de sesión.
        // Recibe la sesión del usuario para poder mostrar su información.
        public FormMenuPrincipal(ServicioSesionJugador sesion)
        {
            InitializeComponent();
            this.sesion = sesion;
        }

        // Constructor vacío requerido únicamente por el diseñador de formularios.
        public FormMenuPrincipal()
        {
            InitializeComponent();
        }

        private void FormMenuPrincipal_Load(object sender, EventArgs e)
        {
            // Se actualiza el texto de bienvenida utilizando el nombre del usuario activo.
            string nombreUsuarioMayus = sesion.UsuarioActual.NombreUsuario.ToUpper();
            lblBienvenida.Text = "BIENVENIDX\n" + nombreUsuarioMayus;


            // Si el usuario no es administrador, el botón permanece visible pero inhabilitado.
            if (!sesion.UsuarioActual.EsAdministrador)
            {
                btnAdministracion.Enabled = false;              // No permite hacer clic
                btnAdministracion.BackColor = Color.Gray;       // Color apagado
                btnAdministracion.ForeColor = Color.LightGray;  // Texto apagado
                btnAdministracion.FlatStyle = FlatStyle.Popup;  // Estilo más "plano"

                toolTip1.SetToolTip(btnAdministracion,
                "Esta opción está disponible únicamente para administradores.");

            }

        }

        private void btnJugar_Click(object sender, EventArgs e)
        {
            // Se abre el formulario del juego, enviando la sesión del jugador.
            FormJuego formJuego = new FormJuego(sesion);
            formJuego.Show();
            this.Hide();
        }

        private void btnPerfil_Click(object sender, EventArgs e)
        {
            // Se accede al formulario del perfil del usuario.
            FormPerfilUsuario formPerfil = new FormPerfilUsuario(sesion);
            formPerfil.Show();
            this.Hide();
        }

        private void btnHistorial_Click(object sender, EventArgs e)
        {
            // Se abre el historial de partidas del usuario actual.
            FormHistorial formHistorial = new FormHistorial(sesion);
            formHistorial.Show();
            this.Hide();
        }

        private void btnAdministracion_Click(object sender, EventArgs e)
        {
            // Solo disponible para administradores.
            FormAdministracion formAdmin = new FormAdministracion(sesion);
            formAdmin.Show();
            this.Hide();
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            // Se finaliza la sesión y se vuelve al inicio de sesión.
            FormInicioSesion login = new FormInicioSesion();
            login.Show();
            this.Hide();
        }
    }
}
