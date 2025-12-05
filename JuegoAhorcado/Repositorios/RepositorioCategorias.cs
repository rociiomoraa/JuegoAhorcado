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
    public class RepositorioCategorias
    {
        private readonly ConexionBD conexion = new ConexionBD();

        // ----------------------------------------------------------
        // Obtener todas las categorías disponibles
        // ----------------------------------------------------------
        public List<Categoria> ObtenerTodas()
        {
            List<Categoria> lista = new List<Categoria>();

            try
            {
                using (var conn = conexion.ObtenerConexion())
                {
                    conn.Open();

                    string sql = "SELECT * FROM categoria ORDER BY id";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        lista.Add(new Categoria
                        {
                            Id = reader.GetInt32("id"),
                            Nombre = reader.GetString("nombre")
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al obtener categorías:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error
                );
            }

            return lista;
        }

        // ----------------------------------------------------------
        // Obtener categoría por ID
        // ----------------------------------------------------------
        public Categoria ObtenerPorId(int id)
        {
            Categoria categoria = null;

            try
            {
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al obtener la categoría por ID:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error
                );
            }

            return categoria;
        }

        // ----------------------------------------------------------
        // Insertar nueva categoría
        // ----------------------------------------------------------
        public void Insertar(Categoria categoria)
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al insertar categoría:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error
                );
            }
        }

        // ----------------------------------------------------------
        // Modificar categoría existente
        // ----------------------------------------------------------
        public void Modificar(Categoria categoria)
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al modificar la categoría:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error
                );
            }
        }

        // ----------------------------------------------------------
        // Eliminar categoría
        // ----------------------------------------------------------
        public void Eliminar(int id)
        {
            try
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
            catch (MySqlException ex) when (ex.Number == 1451)
            {
                MessageBox.Show(
                    "No se puede eliminar la categoría porque está siendo usada por palabras.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al eliminar la categoría:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error
                );
            }
        }
    }
}