using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoAhorcado.Modelos
{
    public class EntradaPalabra
    {
        public int Id { get; set; }
        public string Palabra { get; set; }
        public int CategoriaId { get; set; }
        public string CategoriaNombre { get; set; }
    }
}
