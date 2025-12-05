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
    public class RepositorioPalabras
    {
        private readonly ConexionBD conexion = new ConexionBD();

        // Obtener todas las palabras
        public List<EntradaPalabra> ObtenerTodas()
        {
            List<EntradaPalabra> lista = new List<EntradaPalabra>();

            try
            {
                using (var conn = conexion.ObtenerConexion())
                {
                    conn.Open();

                    string sql =
                        @"SELECT p.id, p.palabra, p.categoria_id, c.nombre AS categoria_nombre
                          FROM palabras p
                          INNER JOIN categoria c ON c.id = p.categoria_id
                          ORDER BY p.id";

                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        lista.Add(new EntradaPalabra
                        {
                            Id = reader.GetInt32("id"),
                            Palabra = reader.GetString("palabra"),
                            CategoriaId = reader.GetInt32("categoria_id"),
                            CategoriaNombre = reader.GetString("categoria_nombre")
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener palabras:\n" + ex.Message);
            }

            return lista;
        }

        // Obtener palabras por categoría
        public List<EntradaPalabra> ObtenerPorCategoria(int categoriaId)
        {
            List<EntradaPalabra> lista = new List<EntradaPalabra>();

            try
            {
                using (var conn = conexion.ObtenerConexion())
                {
                    conn.Open();

                    string sql =
                        @"SELECT p.id, p.palabra, p.categoria_id, c.nombre AS categoria_nombre
                          FROM palabras p
                          INNER JOIN categoria c ON c.id = p.categoria_id
                          WHERE p.categoria_id = @categoria_id
                          ORDER BY p.id";

                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@categoria_id", categoriaId);

                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        lista.Add(new EntradaPalabra
                        {
                            Id = reader.GetInt32("id"),
                            Palabra = reader.GetString("palabra"),
                            CategoriaId = reader.GetInt32("categoria_id"),
                            CategoriaNombre = reader.GetString("categoria_nombre")
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener palabras por categoría:\n" + ex.Message);
            }

            return lista;
        }

        // Obtener palabra aleatoria
        public EntradaPalabra ObtenerAleatoria(int categoriaId)
        {
            try
            {
                var lista = ObtenerPorCategoria(categoriaId);
                if (lista.Count == 0) return null;

                Random rnd = new Random();
                return lista[rnd.Next(lista.Count)];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener palabra aleatoria:\n" + ex.Message);
                return null;
            }
        }

        // Obtener palabra por ID (CORREGIDO)
        public EntradaPalabra ObtenerPorId(int id)
        {
            try
            {
                using (var conn = conexion.ObtenerConexion())
                {
                    conn.Open();

                    string sql =
                        @"SELECT p.id, p.palabra, p.categoria_id, c.nombre AS categoria_nombre
                          FROM palabras p
                          INNER JOIN categoria c ON c.id = p.categoria_id
                          WHERE p.id = @id";

                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@id", id);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new EntradaPalabra
                            {
                                Id = reader.GetInt32("id"),
                                Palabra = reader.GetString("palabra"),
                                CategoriaId = reader.GetInt32("categoria_id"),
                                CategoriaNombre = reader.GetString("categoria_nombre")
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener palabra por ID:\n" + ex.Message);
            }

            return null;
        }

        // Insertar
        public void Insertar(EntradaPalabra palabra)
        {
            try
            {
                using (var conn = conexion.ObtenerConexion())
                {
                    conn.Open();

                    string sql =
                        @"INSERT INTO palabras (palabra, categoria_id)
                          VALUES (@palabra, @categoria_id)";

                    MySqlCommand cmd = new MySqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@palabra", palabra.Palabra);
                    cmd.Parameters.AddWithValue("@categoria_id", palabra.CategoriaId);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar palabra:\n" + ex.Message);
            }
        }

        // Modificar
        public void Modificar(EntradaPalabra palabra)
        {
            try
            {
                using (var conn = conexion.ObtenerConexion())
                {
                    conn.Open();

                    string sql =
                        @"UPDATE palabras
                          SET palabra = @palabra, categoria_id = @categoria_id
                          WHERE id = @id";

                    MySqlCommand cmd = new MySqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@id", palabra.Id);
                    cmd.Parameters.AddWithValue("@palabra", palabra.Palabra);
                    cmd.Parameters.AddWithValue("@categoria_id", palabra.CategoriaId);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar palabra:\n" + ex.Message);
            }
        }

        // Eliminar
        public void Eliminar(int id)
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar palabra:\n" + ex.Message);
            }
        }
    }
}