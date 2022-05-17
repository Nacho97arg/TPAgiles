using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Entities
{
    public class Ahorcado
    {
        public string PalabraAAdivinar { get; set; }

        public string Abecedario { get; set; }

        public int Intentos { get; set; }

        public Ahorcado(string palabra)
        {
            PalabraAAdivinar = palabra;
            Abecedario = "abcdefghijklmnñopqrstuvwxyz";
            Intentos = 10;
        }

        public bool RealizarIntento(string letra)
        {
            Intentos -= 1;
            if(!(letra.Length > 1))
            {
                Abecedario = Abecedario.Remove(Abecedario.IndexOf(letra));
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
