using JuegoAhorcado.Modelos;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoAhorcado.Repositorios
{
    public class RepositorioPalabras
    {
        private ConexionBD conexion = new ConexionBD();

        // ----------------------------------------------------------
        // Obtener todas las palabras con el nombre de categoría
        // (ideal para el DataGridView del panel de administración)
        // ----------------------------------------------------------
        public List<EntradaPalabra> ObtenerTodas()
        {
            List<EntradaPalabra> lista = new List<EntradaPalabra>();

            using (var conn = conexion.ObtenerConexion())
            {
                conn.Open();

                string sql = @"SELECT p.id, p.palabra, p.categoria_id, c.nombre AS categoria_nombre
                               FROM palabras p
                               INNER JOIN categoria c ON c.id = p.categoria_id
                               ORDER BY p.id";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    EntradaPalabra palabra = new EntradaPalabra();
                    palabra.Id = reader.GetInt32("id");
                    palabra.Palabra = reader.GetString("palabra");
                    palabra.CategoriaId = reader.GetInt32("categoria_id");
                    palabra.CategoriaNombre = reader.GetString("categoria_nombre");

                    lista.Add(palabra);
                }
            }

            return lista;
        }

        // ----------------------------------------------------------
        // Obtener palabras filtradas por categoría
        // ----------------------------------------------------------
        public List<EntradaPalabra> ObtenerPorCategoria(int categoriaId)
        {
            List<EntradaPalabra> lista = new List<EntradaPalabra>();

            using (var conn = conexion.ObtenerConexion())
            {
                conn.Open();

                string sql = @"SELECT p.id, p.palabra, p.categoria_id, c.nombre AS categoria_nombre
                               FROM palabras p
                               INNER JOIN categoria c ON c.id = p.categoria_id
                               WHERE p.categoria_id = @categoria_id
                               ORDER BY p.id";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@categoria_id", categoriaId);

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    EntradaPalabra palabra = new EntradaPalabra();
                    palabra.Id = reader.GetInt32("id");
                    palabra.Palabra = reader.GetString("palabra");
                    palabra.CategoriaId = reader.GetInt32("categoria_id");
                    palabra.CategoriaNombre = reader.GetString("categoria_nombre");

                    lista.Add(palabra);
                }
            }

            return lista;
        }

        // ----------------------------------------------------------
        // Obtener una palabra aleatoria dentro de la categoría (para el juego)
        // ----------------------------------------------------------
        public EntradaPalabra ObtenerAleatoria(int categoriaId)
        {
            var lista = ObtenerPorCategoria(categoriaId);

            if (lista.Count == 0)
                return null;

            Random rnd = new Random();
            return lista[rnd.Next(lista.Count)];
        }

        // ----------------------------------------------------------
        // Obtener palabra por ID
        // ----------------------------------------------------------
        public EntradaPalabra ObtenerPorId(int id)
        {
            EntradaPalabra palabra = null;

            using (var conn = conexion.ObtenerConexion())
            {
                conn.Open();

                string sql = @"SELECT p.id, p.palabra, p.categoria_id, c.nombre AS categoria_nombre
                               FROM palabras p
                               INNER JOIN categoria c ON c.id = p.categoria_id
                               WHERE p.id = @id";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", id);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        palabra = new EntradaPalabra()
                        {
                            Id = reader.GetInt32("id"),
                            Palabra = reader.GetString("palabra"),
                            CategoriaId = reader.GetInt32("categoria_id"),
                            CategoriaNombre = reader.GetString("categoria_nombre")
                        };
                    }
                }
            }

            return palabra;
        }

        // ----------------------------------------------------------
        // Insertar palabra nueva
        // ----------------------------------------------------------
        public void Insertar(EntradaPalabra palabra)
        {
            using (var conn = conexion.ObtenerConexion())
            {
                conn.Open();

                string sql = @"INSERT INTO palabras (palabra, categoria_id)
                               VALUES (@palabra, @categoria_id)";

                MySqlCommand cmd = new MySqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@palabra", palabra.Palabra);
                cmd.Parameters.AddWithValue("@categoria_id", palabra.CategoriaId);

                cmd.ExecuteNonQuery();
            }
        }

        // ----------------------------------------------------------
        // Modificar palabra existente
        // ----------------------------------------------------------
        public void Modificar(EntradaPalabra palabra)
        {
            using (var conn = conexion.ObtenerConexion())
            {
                conn.Open();

                string sql = @"UPDATE palabras
                               SET palabra = @palabra,
                                   categoria_id = @categoria_id
                               WHERE id = @id";

                MySqlCommand cmd = new MySqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@id", palabra.Id);
                cmd.Parameters.AddWithValue("@palabra", palabra.Palabra);
                cmd.Parameters.AddWithValue("@categoria_id", palabra.CategoriaId);

                cmd.ExecuteNonQuery();
            }
        }

        // ----------------------------------------------------------
        // Eliminar palabra
        // ----------------------------------------------------------
        public void Eliminar(int id)
        {
            using (var conn = conexion.ObtenerConexion())
            {
                conn.Open();

                string sql = "DELETE FROM palabras WHERE id = @id";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery();
            }
        }
    }
}