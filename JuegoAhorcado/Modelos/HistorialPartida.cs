using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoAhorcado.Modelos
{
    public class HistorialPartida
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public int PalabraId { get; set; }
        public string Resultado { get; set; }    
        public int PuntuacionObtenida { get; set; }
        public DateTime Fecha { get; set; }
    }
}
