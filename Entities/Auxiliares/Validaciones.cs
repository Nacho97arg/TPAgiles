using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Auxiliares
{
    public static class Validaciones
    {
        public static bool ValidarLetra(string letra)
        {
            return !(letra.Length > 1 || letra.Length == 0);
        }
    }
}
