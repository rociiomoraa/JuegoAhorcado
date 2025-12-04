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
        // Instancia del servicio encargado de validar usuarios contra la base de datos.
        // Se mantiene a nivel de clase para reutilizarlo sin recrearlo en cada llamada.
        private ServicioUsuarios servicioUsuarios = new ServicioUsuarios();

        // Servicio que gestiona la sesión del jugador activo durante toda la ejecución.
        private ServicioSesionJugador servicioSesion = new ServicioSesionJugador();

        public FormInicioSesion()
        {
            InitializeComponent();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            // Se obtiene el nombre de usuario y la contraseña introducidos.
            string nombre = txtUsuario.Text.Trim();
            string contrasena = txtContrasena.Text.Trim();

            // Validación inicial: se comprueba que ningún campo esté vacío.
            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(contrasena))
            {
                MessageBox.Show("Introduce usuario y contraseña.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Se intenta iniciar sesión a través del servicio.
            Usuario usuario = servicioUsuarios.IniciarSesion(nombre, contrasena);

            // Si el usuario no existe o la contraseña no coincide, se informa al usuario.
            if (usuario == null)
            {
                MessageBox.Show("Usuario o contraseña incorrectos.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Si las credenciales son válidas, se registra al usuario en la sesión activa.
            servicioSesion.IniciarSesion(usuario);

            // A continuación, se abre el formulario principal del sistema.
            //FormMenuPrincipal menu = new FormMenuPrincipal(servicioSesion);
           // menu.Show();

            // El formulario de inicio de sesión no se cierra, sino que se oculta.
            // Esto evita finalizar la aplicación si es el formulario inicial.
            this.Hide();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            // Al volver, se muestra nuevamente la pantalla de bienvenida.
            // Este comportamiento mantiene la coherencia del flujo de navegación.
            FormInicio inicio = new FormInicio();
            inicio.Show();

            // De nuevo, se oculta el formulario actual para mantener la aplicación activa.
            this.Hide();
        }

        private void FormInicioSesion_Load(object sender, EventArgs e)
        {

        }
    }
}
