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

        // ----------------------------------------------------------
        // Obtener todas las categorías disponibles en la base de datos
        // ----------------------------------------------------------
        public List<Categoria> ObtenerTodas()
        {
            List<Categoria> lista = new List<Categoria>();

            using (var conn = conexion.ObtenerConexion())
            {
                conn.Open();
                string sql = "SELECT * FROM categoria ORDER BY id";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Categoria cat = new Categoria();
                    cat.Id = reader.GetInt32("id");
                    cat.Nombre = reader.GetString("nombre");

                    lista.Add(cat);
                }
            }

            return lista;
        }

        // ----------------------------------------------------------
        // Obtener una categoría por su ID
        // ----------------------------------------------------------
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

        // ----------------------------------------------------------
        // Insertar una nueva categoría
        // ----------------------------------------------------------
        public void Insertar(Categoria categoria)
        {
            using (var conn = conexion.ObtenerConexion())
            {
                conn.Open();
                string sql = "INSERT INTO categoria (nombre) VALUES (@nombre)";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@nombre", categoria.Nombre);

                cmd.ExecuteNonQuery();
            }
        }

        // ----------------------------------------------------------
        // Modificar el nombre de una categoría existente
        // ----------------------------------------------------------
        public void Modificar(Categoria categoria)
        {
            using (var conn = conexion.ObtenerConexion())
            {
                conn.Open();
                string sql = "UPDATE categoria SET nombre = @nombre WHERE id = @id";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@nombre", categoria.Nombre);
                cmd.Parameters.AddWithValue("@id", categoria.Id);

                cmd.ExecuteNonQuery();
            }
        }

        // ----------------------------------------------------------
        // Eliminar una categoría por su ID
        // ----------------------------------------------------------
        public void Eliminar(int id)
        {
            using (var conn = conexion.ObtenerConexion())
            {
                conn.Open();
                string sql = "DELETE FROM categoria WHERE id = @id";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery();
            }
        }
    }
}
