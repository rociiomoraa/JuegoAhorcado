using JuegoAhorcado.Modelos;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoAhorcado.Repositorios
{
    public class RepositorioUsuarios
    {
        private ConexionBD conexion = new ConexionBD();

        public Usuario ObtenerPorNombre(string nombreUsuario)
        {
            Usuario usuario = null;

            MySqlConnection conn = conexion.ObtenerConexion();
            conn.Open();

            string sql = "SELECT * FROM usuarios WHERE username = @user";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@user", nombreUsuario);

            MySqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                usuario = new Usuario();
                usuario.Id = reader.GetInt32("id");
                usuario.NombreUsuario = reader.GetString("username");
                usuario.Contrasena = reader.GetString("password");
                usuario.EsAdministrador = reader.GetBoolean("admin");
                usuario.PuntuacionTotal = reader.GetInt32("score");
            }

            reader.Close();
            conn.Close();

            return usuario;
        }

        public void ActualizarPuntuacion(int usuarioId, int nuevaPuntuacion)
        {
            MySqlConnection conn = conexion.ObtenerConexion();
            conn.Open();

            string sql = "UPDATE usuarios SET score = @score WHERE id = @id";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@score", nuevaPuntuacion);
            cmd.Parameters.AddWithValue("@id", usuarioId);

            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void CambiarContrasena(int idUsuario, string nuevaContrasena)
        {
            MySqlConnection conn = conexion.ObtenerConexion();
            conn.Open();

            string sql = "UPDATE usuarios SET password = @pass WHERE id = @id";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@pass", nuevaContrasena);
            cmd.Parameters.AddWithValue("@id", idUsuario);

            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public List<Usuario> ObtenerTodos()
        {
            List<Usuario> lista = new List<Usuario>();

            MySqlConnection conn = conexion.ObtenerConexion();
            conn.Open();

            string sql = "SELECT * FROM usuarios";
            MySqlCommand cmd = new MySqlCommand(sql, conn);

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Usuario usuario = new Usuario();
                usuario.Id = reader.GetInt32("id");
                usuario.NombreUsuario = reader.GetString("username");
                usuario.Contrasena = reader.GetString("password");
                usuario.EsAdministrador = reader.GetBoolean("admin");
                usuario.PuntuacionTotal = reader.GetInt32("score");

                lista.Add(usuario);
            }

            reader.Close();
            conn.Close();

            return lista;
        }
        public void ActualizarRachaMaxima(int usuarioId, int nuevaRacha)
        {
            MySqlConnection conn = conexion.ObtenerConexion();
            conn.Open();

            string sql = "UPDATE usuarios SET racha_maxima = @racha WHERE id = @id";
            MySqlCommand cmd = new MySqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@racha", nuevaRacha);
            cmd.Parameters.AddWithValue("@id", usuarioId);

            cmd.ExecuteNonQuery();
            conn.Close();
        }

    }
}
