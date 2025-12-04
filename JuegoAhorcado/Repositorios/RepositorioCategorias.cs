using JuegoAhorcado.Modelos;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoAhorcado.Repositorios
{
    public class RepositorioCategorias
    {
        private ConexionBD conexion = new ConexionBD();

        public List<Categoria> ObtenerTodas()
        {
            List<Categoria> lista = new List<Categoria>();

            MySqlConnection conn = conexion.ObtenerConexion();
            conn.Open();

            string sql = "SELECT * FROM categoria";
            MySqlCommand cmd = new MySqlCommand(sql, conn);

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Categoria cat = new Categoria();
                cat.Id = reader.GetInt32("id");
                cat.Nombre = reader.GetString("nombre");

                lista.Add(cat);
            }

            reader.Close();
            conn.Close();

            return lista;
        }

        public Categoria ObtenerPorId(int id)
        {
            Categoria categoria = null;

            using (var conn = conexion.ObtenerConexion())
            {
                conn.Open();
                string sql = "SELECT * FROM categoria WHERE id = @id";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", id);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        categoria = new Categoria()
                        {
                            Id = reader.GetInt32("id"),
                            Nombre = reader.GetString("nombre")
                        };
                    }
                }
            }

            return categoria;
        }

    }
}
