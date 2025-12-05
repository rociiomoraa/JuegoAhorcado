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
    public class RepositorioPartidas
    {
        private readonly ConexionBD conexion = new ConexionBD();

        // ----------------------------------------------------------
        // Registrar una partida jugada
        // ----------------------------------------------------------
        public void RegistrarPartida(HistorialPartida partida)
        {
            try
            {
                using (var conn = conexion.ObtenerConexion())
                {
                    conn.Open();

                    string sql = @"INSERT INTO partidas 
                                   (usuario_id, palabra_id, resultado, puntuacion_obtenida, fecha)
                                   VALUES (@usuario_id, @palabra_id, @resultado, @puntuacion_obtenida, @fecha)";

                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@usuario_id", partida.UsuarioId);
                        cmd.Parameters.AddWithValue("@palabra_id", partida.PalabraId);
                        cmd.Parameters.AddWithValue("@resultado", partida.Resultado);
                        cmd.Parameters.AddWithValue("@puntuacion_obtenida", partida.PuntuacionObtenida);
                        cmd.Parameters.AddWithValue("@fecha", partida.Fecha);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1452) // Error de clave foránea
                {
                    MessageBox.Show(
                        "No se pudo registrar la partida porque el usuario o la palabra no existen.",
                        "Error de Integridad Referencial",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                }
                else
                {
                    MessageBox.Show(
                        "Error de base de datos al registrar la partida:\n" + ex.Message,
                        "Error SQL",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error inesperado al registrar la partida:\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // ----------------------------------------------------------
        // Obtener el historial de partidas de un usuario
        // ----------------------------------------------------------
        public List<HistorialPartida> ObtenerPorUsuario(int usuarioId)
        {
            List<HistorialPartida> lista = new List<HistorialPartida>();

            try
            {
                using (var conn = conexion.ObtenerConexion())
                {
                    conn.Open();

                    string sql = @"SELECT * FROM partidas 
                                   WHERE usuario_id = @usuario_id
                                   ORDER BY fecha DESC";

                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@usuario_id", usuarioId);

                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                lista.Add(new HistorialPartida
                                {
                                    Id = reader.GetInt32("id"),
                                    UsuarioId = reader.GetInt32("usuario_id"),
                                    PalabraId = reader.GetInt32("palabra_id"),
                                    Resultado = reader.GetString("resultado"),
                                    PuntuacionObtenida = reader.GetInt32("puntuacion_obtenida"),
                                    Fecha = reader.GetDateTime("fecha")
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al obtener el historial de partidas:\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }

            return lista;
        }
    }
}