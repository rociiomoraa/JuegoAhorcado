using JuegoAhorcado.Motor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoAhorcado.Modelos
{
    public class SesionPartida
    {
        public Usuario Jugador { get; set; }
        public Categoria Categoria { get; set; }
        public EntradaPalabra Palabra { get; set; }
        public Motor.MotorAhorcado Motor { get; set; }
        public int Puntuacion { get; set; } = 0;
    }
}
