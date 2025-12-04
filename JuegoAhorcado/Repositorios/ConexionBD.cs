using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoAhorcado.Repositorios
{
    public class ConexionBD
    {
        private readonly string cadenaConexion =
            "server=localhost;database=ahorcado;user=root;password=1234;";

        public MySqlConnection ObtenerConexion()
        {
            return new MySqlConnection(cadenaConexion);
        }
    }
}
