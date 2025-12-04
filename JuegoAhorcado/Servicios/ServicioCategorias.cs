using JuegoAhorcado.Modelos;
using JuegoAhorcado.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoAhorcado.Servicios
{
    public class ServicioCategorias
    {
        private RepositorioCategorias repo = new RepositorioCategorias();

        public List<Categoria> ObtenerCategorias()
        {
            return repo.ObtenerTodas();
        }
    }
}
