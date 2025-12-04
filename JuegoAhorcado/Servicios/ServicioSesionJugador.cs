using JuegoAhorcado.Modelos;
using JuegoAhorcado.Motor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoAhorcado.Servicios
{
    public class ServicioSesionJugador
    {
        public Usuario UsuarioActual { get; private set; }
        public Categoria CategoriaActual { get; private set; }
        public EntradaPalabra PalabraActual { get; private set; }
        public Motor.MotorAhorcado Motor { get; private set; }
        public int Puntuacion { get; private set; }

        private ServicioPuntuacion servicioPuntuacion = new ServicioPuntuacion();

        public void IniciarSesion(Usuario usuario)
        {
            UsuarioActual = usuario;
        }

        public void IniciarPartida(Categoria categoria, EntradaPalabra palabra)
        {
            CategoriaActual = categoria;
            PalabraActual = palabra;
            Motor = new Motor.JuegoAhorcado(palabra.Palabra);
            Puntuacion = 0;
        }

        public void LetraAcertada()
        {
            Puntuacion += servicioPuntuacion.SumarLetraAcertada();
        }

        public void LetraFallada()
        {
            Puntuacion += servicioPuntuacion.RestarLetraFallada();
        }

        public void PalabraAcertada()
        {
            Puntuacion += servicioPuntuacion.SumarPalabraAcertada();
        }

        public void PalabraFallada()
        {
            Puntuacion += servicioPuntuacion.RestarPalabraFallada();
        }
    }
}
