using JuegoAhorcado.Modelos;
using JuegoAhorcado.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoAhorcado.Servicios
{
    public class ServicioUsuarios
    {
        private RepositorioUsuarios repo = new RepositorioUsuarios();

        public Usuario IniciarSesion(string nombreUsuario, string contrasena)
        {
            Usuario usuario = repo.ObtenerPorNombre(nombreUsuario);

            if (usuario == null)
                return null;

            if (usuario.Contrasena != contrasena)
                return null;

            return usuario;
        }

        public void CambiarContrasena(int usuarioId, string nuevaContrasena)
        {
            repo.CambiarContrasena(usuarioId, nuevaContrasena);
        }

        public List<Usuario> ObtenerTodos()
        {
            return repo.ObtenerTodos();
        }

        public void ActualizarPuntuacion(int usuarioId, int nuevaPuntuacion)
        {
            repo.ActualizarPuntuacion(usuarioId, nuevaPuntuacion);
        }
    }
}
