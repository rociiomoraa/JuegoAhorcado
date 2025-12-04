using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoAhorcado.Servicios
{
    public class ServicioPuntuacion
    {
        public int SumarLetraAcertada()
        {
            return 2;
        }

        public int RestarLetraFallada()
        {
            return -1;
        }

        public int SumarPalabraAcertada()
        {
            return 10;
        }

        public int RestarPalabraFallada()
        {
            return -5;
        }
    }
}
