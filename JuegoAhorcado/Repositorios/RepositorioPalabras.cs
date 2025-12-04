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

        public List<EntradaPalabra> ObtenerPorCategoria(int categoriaId)
        {
            List<EntradaPalabra> lista = new List<EntradaPalabra>();

            MySqlConnection conn = conexion.ObtenerConexion();
            conn.Open();

            string sql = "SELECT * FROM palabras WHERE categoria_id = @categoria_id";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@categoria_id", categoriaId);

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                EntradaPalabra palabra = new EntradaPalabra();
                palabra.Id = reader.GetInt32("id");
                palabra.Palabra = reader.GetString("palabra");
                palabra.CategoriaId = reader.GetInt32("categoria_id");

                lista.Add(palabra);
            }

            reader.Close();
            conn.Close();

            return lista;
        }

        public EntradaPalabra ObtenerAleatoria(int categoriaId)
        {
            List<EntradaPalabra> lista = ObtenerPorCategoria(categoriaId);

            if (lista.Count == 0)
                return null;

            Random rnd = new Random();
            return lista[rnd.Next(lista.Count)];
        }

        public EntradaPalabra ObtenerPorId(int id)
        {
            EntradaPalabra palabra = null;

            using (var conn = conexion.ObtenerConexion())
            {
                conn.Open();
                string sql = "SELECT * FROM palabras WHERE id = @id";

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
                            CategoriaId = reader.GetInt32("categoria_id")
                        };
                    }
                }
            }

            return palabra;
        }

    }
}
