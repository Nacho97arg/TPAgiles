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

        public int Intentos { get; set; }

        public Estados Estado { get; private set; }

        public List<string> LetrasAcertadas = new List<string>();

        public List<string> LetrasIncorrectas = new List<string>();

        public enum Estados { Jugando, Ganada, Perdida }

        public Ahorcado(string palabra)
        {
            PalabraAAdivinar = palabra;
            Intentos = 10;
            Estado = Estados.Jugando;
        }

        public bool RealizarIntento(string letra)
        {
            if (Intentos == 0 && Estado != Estados.Ganada)
            {
                Estado = Estados.Perdida;
                return false;
            }
           
            Intentos -= 1;

            if(!(letra.Length > 1) && PalabraAAdivinar.Contains(letra) && Estado == Estados.Jugando)
            {
                LetrasAcertadas.Add(letra);
                if (PartidaGanada())
                {
                    Estado = Estados.Ganada;
                }
                return true;
            }
            else
            {
                LetrasIncorrectas.Add(letra);
                return false;
            }
        }
    

        private bool PartidaGanada()
        {
            foreach (char letra in PalabraAAdivinar)
            {
                if (!LetrasAcertadas.Contains(letra.ToString()))
                {
                    return false;
                }
            }
            return true;
        }

    }
}
