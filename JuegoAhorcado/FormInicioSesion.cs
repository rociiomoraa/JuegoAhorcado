using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JuegoAhorcado.Modelos;
using JuegoAhorcado.Servicios;

namespace JuegoAhorcado
{
    public partial class FormInicioSesion : Form
    {
        private ServicioUsuarios servicioUsuarios = new ServicioUsuarios();
        private ServicioSesionJugador servicioSesion = new ServicioSesionJugador();

        public FormInicioSesion()
        {
            InitializeComponent();
        }

        private void FormInicioSesion_Load(object sender, EventArgs e)
        {
            // Permite iniciar sesión pulsando Enter
            this.AcceptButton = btnEntrar;

            // Ocultar la contraseña si no lo has hecho en el diseñador
            txtContrasena.UseSystemPasswordChar = true;
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            string nombre = txtUsuario.Text.Trim();
            string contrasena = txtContrasena.Text.Trim();

            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(contrasena))
            {
                MessageBox.Show("Introduce usuario y contraseña.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Usuario usuario = servicioUsuarios.IniciarSesion(nombre, contrasena);

            if (usuario == null)
            {
                MessageBox.Show("Usuario o contraseña incorrectos.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Registrar la sesión activa
            servicioSesion.IniciarSesion(usuario);

            // Abrir el menú principal
            FormMenuPrincipal menu = new FormMenuPrincipal(servicioSesion);
            menu.Show();

            // Cerrar el formulario de inicio de sesión
            this.Close();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            FormInicio inicio = new FormInicio();
            inicio.Show();
            this.Close(); // en vez de Hide()
        }
    }
}
