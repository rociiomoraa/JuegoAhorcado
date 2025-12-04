using JuegoAhorcado.Modelos;
using JuegoAhorcado.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoAhorcado.Servicios
{
    public class ServicioPalabras
    {
        private RepositorioPalabras repo = new RepositorioPalabras();

        public List<EntradaPalabra> ObtenerPalabrasPorCategoria(int categoriaId)
        {
            return repo.ObtenerPorCategoria(categoriaId);
        }

        public EntradaPalabra ObtenerPalabraAleatoria(int categoriaId)
        {
            return repo.ObtenerAleatoria(categoriaId);
        }
    }
}
