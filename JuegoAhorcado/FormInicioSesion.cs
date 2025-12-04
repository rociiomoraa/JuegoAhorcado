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
        // Servicio encargado de validar usuarios contra la base de datos.
        private ServicioUsuarios servicioUsuarios = new ServicioUsuarios();

        // Servicio que mantiene al usuario logueado durante la aplicación.
        private ServicioSesionJugador servicioSesion = new ServicioSesionJugador();

        public FormInicioSesion()
        {
            InitializeComponent();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            string nombre = txtUsuario.Text.Trim();
            string contrasena = txtContrasena.Text.Trim();

            // Validación de campos vacíos
            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(contrasena))
            {
                MessageBox.Show("Introduce usuario y contraseña.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Intento de inicio de sesión contra la base de datos
            Usuario usuario = servicioUsuarios.IniciarSesion(nombre, contrasena);

            if (usuario == null)
            {
                MessageBox.Show("Usuario o contraseña incorrectos.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Registrar la sesión activa
            servicioSesion.IniciarSesion(usuario);

            // Abrir el menú principal y pasarle la sesión
            FormMenuPrincipal menu = new FormMenuPrincipal(servicioSesion);
            menu.Show();

            // Ocultar este formulario
            this.Hide();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            FormInicio inicio = new FormInicio();
            inicio.Show();
            this.Hide();
        }

        private void FormInicioSesion_Load(object sender, EventArgs e)
        {
        }
    }
}
