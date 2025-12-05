using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JuegoAhorcado.Repositorios;
using JuegoAhorcado.Servicios;

namespace JuegoAhorcado
{
    public partial class FormPerfilUsuario : Form
    {
        private readonly ServicioSesionJugador sesion;
        private readonly RepositorioUsuarios repoUsuarios = new RepositorioUsuarios();

        public FormPerfilUsuario(ServicioSesionJugador sesion)
        {
            InitializeComponent();
            this.sesion = sesion;
        }

        private void FormPerfilUsuario_Load_1(object sender, EventArgs e)
        {
            // Cargar datos del usuario desde BD
            var usuario = repoUsuarios.ObtenerPorId(sesion.UsuarioActual.Id);

            if (usuario == null)
            {
                MessageBox.Show("Error al cargar los datos del usuario.");
                return;
            }

            txtNombreUsuario.Text = usuario.NombreUsuario;
            txtAdmin.Text = usuario.EsAdministrador ? "Sí" : "No";

            // Campos de contraseña vacíos siempre
            txtContrasenaActual.Clear();
            txtNuevaContrasena.Clear();
            txtRepetirContrasena.Clear();
        }

        private void txtNombreUsuario_TextChanged(object sender, EventArgs e) { }
        private void txtContrasenaActual_TextChanged(object sender, EventArgs e) { }
        private void txtNuevaContrasena_TextChanged(object sender, EventArgs e) { }
        private void txtRepetirContrasena_TextChanged(object sender, EventArgs e) { }
        private void txtAdmin_TextChanged(object sender, EventArgs e) { }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            var user = repoUsuarios.ObtenerPorId(sesion.UsuarioActual.Id);

            if (user == null)
            {
                MessageBox.Show("Error: usuario no encontrado.");
                return;
            }

            // Validar contraseña actual si desea cambiarla
            bool cambiandoPass = !string.IsNullOrWhiteSpace(txtNuevaContrasena.Text);

            if (cambiandoPass)
            {
                if (txtContrasenaActual.Text != user.Contrasena)
                {
                    MessageBox.Show("La contraseña actual no es correcta.");
                    return;
                }

                if (txtNuevaContrasena.Text != txtRepetirContrasena.Text)
                {
                    MessageBox.Show("Las contraseñas nuevas no coinciden.");
                    return;
                }
            }

            // Validar nombre de usuario
            if (string.IsNullOrWhiteSpace(txtNombreUsuario.Text))
            {
                MessageBox.Show("El nombre de usuario no puede estar vacío.");
                return;
            }

            // Actualizar en BD
            string nuevaPass = cambiandoPass ? txtNuevaContrasena.Text.Trim() : user.Contrasena;
            string nuevoNombre = txtNombreUsuario.Text.Trim();

            repoUsuarios.ActualizarUsuario(user.Id, nuevoNombre, nuevaPass);

            // Actualizar sesión
            sesion.UsuarioActual.NombreUsuario = nuevoNombre;
            if (cambiandoPass)
                sesion.UsuarioActual.Contrasena = nuevaPass;

            MessageBox.Show("Datos actualizados correctamente.");
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            try
            {
                FormMenuPrincipal menu = new FormMenuPrincipal(sesion);
                menu.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al volver:\n" + ex.Message);
            }
        }
    }
}

