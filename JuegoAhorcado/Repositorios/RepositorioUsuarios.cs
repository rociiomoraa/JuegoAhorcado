using JuegoAhorcado.Modelos;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JuegoAhorcado.Repositorios
{
    public class RepositorioUsuarios
    {
        private readonly ConexionBD conexion = new ConexionBD();

        // ----------------------------------------------------------
        // Obtener usuario por nombre
        // ----------------------------------------------------------
        public Usuario ObtenerPorNombre(string nombreUsuario)
        {
            Usuario usuario = null;

            try
            {
                using (var conn = conexion.ObtenerConexion())
                {
                    conn.Open();

                    string sql = "SELECT * FROM usuarios WHERE username = @user";

                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@user", nombreUsuario);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                usuario = new Usuario()
                                {
                                    Id = reader.GetInt32("id"),
                                    NombreUsuario = reader.GetString("username"),
                                    Contrasena = reader.GetString("password"),
                                    EsAdministrador = reader.GetBoolean("admin"),
                                    PuntuacionTotal = reader.GetInt32("score"),
                                    RachaMaxima = reader.GetInt32("racha_maxima")
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al obtener usuario:\n" + ex.Message,
                    "Error en la BD",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }

            return usuario;
        }

        // ----------------------------------------------------------
        // Actualizar puntuación total del usuario
        // ----------------------------------------------------------
        public void ActualizarPuntuacion(int usuarioId, int nuevaPuntuacion)
        {
            try
            {
                using (var conn = conexion.ObtenerConexion())
                {
                    conn.Open();

                    string sql = "UPDATE usuarios SET score = @score WHERE id = @id";

                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@score", nuevaPuntuacion);
                        cmd.Parameters.AddWithValue("@id", usuarioId);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al actualizar la puntuación:\n" + ex.Message,
                    "Error en la BD",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // ----------------------------------------------------------
        // Cambiar contraseña
        // ----------------------------------------------------------
        public void CambiarContrasena(int idUsuario, string nuevaContrasena)
        {
            try
            {
                using (var conn = conexion.ObtenerConexion())
                {
                    conn.Open();

                    string sql = "UPDATE usuarios SET password = @pass WHERE id = @id";

                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@pass", nuevaContrasena);
                        cmd.Parameters.AddWithValue("@id", idUsuario);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al cambiar la contraseña:\n" + ex.Message,
                    "Error en la BD",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // ----------------------------------------------------------
        // Obtener todos los usuarios
        // ----------------------------------------------------------
        public List<Usuario> ObtenerTodos()
        {
            List<Usuario> lista = new List<Usuario>();

            try
            {
                using (var conn = conexion.ObtenerConexion())
                {
                    conn.Open();

                    string sql = "SELECT * FROM usuarios";

                    using (var cmd = new MySqlCommand(sql, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Usuario()
                            {
                                Id = reader.GetInt32("id"),
                                NombreUsuario = reader.GetString("username"),
                                Contrasena = reader.GetString("password"),
                                EsAdministrador = reader.GetBoolean("admin"),
                                PuntuacionTotal = reader.GetInt32("score"),
                                RachaMaxima = reader.GetInt32("racha_maxima")
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al obtener la lista de usuarios:\n" + ex.Message,
                    "Error en la BD",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }

            return lista;
        }

        // ----------------------------------------------------------
        // Actualizar racha máxima
        // ----------------------------------------------------------
        public void ActualizarRachaMaxima(int usuarioId, int nuevaRacha)
        {
            try
            {
                using (var conn = conexion.ObtenerConexion())
                {
                    conn.Open();

                    string sql = "UPDATE usuarios SET racha_maxima = @racha WHERE id = @id";

                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@racha", nuevaRacha);
                        cmd.Parameters.AddWithValue("@id", usuarioId);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al actualizar la racha máxima:\n" + ex.Message,
                    "Error en la BD",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // ----------------------------------------------------------
        // Obtener usuario por ID
        // ----------------------------------------------------------
        public Usuario ObtenerPorId(int idUsuario)
        {
            Usuario usuario = null;

            try
            {
                using (var conn = conexion.ObtenerConexion())
                {
                    conn.Open();

                    string sql = "SELECT * FROM usuarios WHERE id = @id";

                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", idUsuario);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                usuario = new Usuario()
                                {
                                    Id = reader.GetInt32("id"),
                                    NombreUsuario = reader.GetString("username"),
                                    Contrasena = reader.GetString("password"),
                                    EsAdministrador = reader.GetBoolean("admin"),
                                    PuntuacionTotal = reader.GetInt32("score"),
                                    RachaMaxima = reader.GetInt32("racha_maxima")
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al obtener usuario por ID:\n" + ex.Message,
                    "Error en la BD",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }

            return usuario;
        }
        // ----------------------------------------------------------
        // Actualizar nombre de usuario y contraseña
        // ----------------------------------------------------------
        public void ActualizarUsuario(int id, string nuevoNombre, string nuevaContrasena)
        {
            try
            {
                using (var conn = conexion.ObtenerConexion())
                {
                    conn.Open();

                    string sql = @"UPDATE usuarios 
                           SET username = @nombre, password = @pass 
                           WHERE id = @id";

                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@nombre", nuevoNombre);
                        cmd.Parameters.AddWithValue("@pass", nuevaContrasena);
                        cmd.Parameters.AddWithValue("@id", id);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al actualizar el usuario:\n" + ex.Message,
                    "Error en la BD",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
        public void Insertar(Usuario usuario)
        {
            try
            {
                using (var conn = conexion.ObtenerConexion())
                {
                    conn.Open();

                    string sql = @"INSERT INTO usuarios (username, password, admin, score, racha_maxima)
                           VALUES (@user, @pass, @admin, @score, @racha)";

                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@user", usuario.NombreUsuario);
                        cmd.Parameters.AddWithValue("@pass", usuario.Contrasena);
                        cmd.Parameters.AddWithValue("@admin", usuario.EsAdministrador);
                        cmd.Parameters.AddWithValue("@score", usuario.PuntuacionTotal);
                        cmd.Parameters.AddWithValue("@racha", usuario.RachaMaxima);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar usuario:\n" + ex.Message);
            }
        }
        public void Modificar(Usuario usuario)
        {
            try
            {
                using (var conn = conexion.ObtenerConexion())
                {
                    conn.Open();

                    string sql = @"UPDATE usuarios 
                           SET username = @user,
                               password = @pass,
                               admin = @admin
                           WHERE id = @id";

                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", usuario.Id);
                        cmd.Parameters.AddWithValue("@user", usuario.NombreUsuario);
                        cmd.Parameters.AddWithValue("@pass", usuario.Contrasena);
                        cmd.Parameters.AddWithValue("@admin", usuario.EsAdministrador);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar usuario:\n" + ex.Message);
            }
        }
        public void Eliminar(int id)
        {
            try
            {
                using (var conn = conexion.ObtenerConexion())
                {
                    conn.Open();

                    string sql = "DELETE FROM usuarios WHERE id = @id";

                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar usuario:\n" + ex.Message);
            }
        }

    }
}
