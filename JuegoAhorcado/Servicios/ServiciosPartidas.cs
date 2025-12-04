using JuegoAhorcado.Modelos;
using JuegoAhorcado.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoAhorcado.Servicios
{
    public class ServiciosPartidas
    {
        private RepositorioPartidas repo = new RepositorioPartidas();

        public void RegistrarPartida(HistorialPartida partida)
        {
            repo.RegistrarPartida(partida);
        }

        public List<HistorialPartida> ObtenerHistorialPorUsuario(int usuarioId)
        {
            return repo.ObtenerPorUsuario(usuarioId);
        }
    }
}
