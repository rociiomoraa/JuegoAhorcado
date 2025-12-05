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
        private ServicioSesionJugador sesion;

        public FormMenuPrincipal(ServicioSesionJugador sesion)
        {
            InitializeComponent();

            // Validación de sesión para evitar errores si llega nula
            if (sesion == null || sesion.UsuarioActual == null)
            {
                MessageBox.Show("La sesión no es válida. Por favor inicie sesión nuevamente.");
                FormInicioSesion login = new FormInicioSesion();
                login.Show();
                this.Close();
                return;
            }

            this.sesion = sesion;
        }

        private void FormMenuPrincipal_Load(object sender, EventArgs e)
        {
            // Si el form ya se cerró debido a sesión inválida, no continuar
            if (!this.Visible)
                return;

            // Texto de bienvenida
            string nombreUsuarioMayus = sesion.UsuarioActual.NombreUsuario.ToUpper();
            lblBienvenida.Text = "BIENVENIDX\n" + nombreUsuarioMayus;

            // Manejo del botón de administración
            if (!sesion.UsuarioActual.EsAdministrador)
            {
                btnAdministracion.Enabled = false;
                btnAdministracion.BackColor = Color.Gray;
                btnAdministracion.ForeColor = Color.LightGray;
                btnAdministracion.FlatStyle = FlatStyle.Popup;

                toolTip1.SetToolTip(btnAdministracion,
                "Esta opción está disponible únicamente para administradores.");
            }
        }

        private void btnJugar_Click(object sender, EventArgs e)
        {
            FormJuego formJuego = new FormJuego(sesion);
            formJuego.Show();
            this.Close();
        }

        private void btnPerfil_Click(object sender, EventArgs e)
        {
            
            FormPerfilUsuario formPerfil = new FormPerfilUsuario(sesion);
            formPerfil.Show();
            this.Close();
        }

        private void btnHistorial_Click(object sender, EventArgs e)
        {
            FormHistorial formHistorial = new FormHistorial(sesion);
            formHistorial.Show();
            this.Close();
        }

        private void btnAdministracion_Click(object sender, EventArgs e)
        {
            FormAdmin formAdmin = new FormAdmin(sesion);
            formAdmin.Show();
            this.Close();
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            // Cerrar sesión de forma real
            sesion.CerrarSesion();

            FormInicioSesion login = new FormInicioSesion();
            login.Show();
            this.Close();
        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }
    }
}
