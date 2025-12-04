using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoAhorcado.Modelos
{
    public class Usuario
    {
        public int Id { get; set; }
        public string NombreUsuario { get; set; }
        public string Contrasena { get; set; }
        public bool EsAdministrador { get; set; }
        public int PuntuacionTotal { get; set; }
        public int RachaMaxima { get; set; }

    }
}
