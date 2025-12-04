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

        public void IniciarSesion(Usuario usuario)
        {
            UsuarioActual = usuario;
        }
    }
}

