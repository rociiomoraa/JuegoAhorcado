using JuegoAhorcado.Modelos;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoAhorcado.Repositorios
{
    public class RepositorioPartidas
    {
        private ConexionBD conexion = new ConexionBD();

        public void RegistrarPartida(HistorialPartida partida)
        {
            MySqlConnection conn = conexion.ObtenerConexion();
            conn.Open();

            string sql = @"INSERT INTO partidas 
                           (usuario_id, palabra_id, resultado, puntuacion, fecha)
                           VALUES (@usuario_id, @palabra_id, @resultado, @puntuacion, @fecha)";

            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@usuario_id", partida.UsuarioId);
            cmd.Parameters.AddWithValue("@palabra_id", partida.PalabraId);
            cmd.Parameters.AddWithValue("@resultado", partida.Resultado);
            cmd.Parameters.AddWithValue("@puntuacion", partida.PuntuacionObtenida);
            cmd.Parameters.AddWithValue("@fecha", partida.Fecha);

            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public List<HistorialPartida> ObtenerPorUsuario(int usuarioId)
        {
            List<HistorialPartida> lista = new List<HistorialPartida>();

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
                                PuntuacionObtenida = reader.GetInt32("puntuacion_obtenida"), // AJUSTAR AQUÍ
                                Fecha = reader.GetDateTime("fecha")
                            });
                        }
                    }
                }
            }

            return lista;
        }

    }
}
