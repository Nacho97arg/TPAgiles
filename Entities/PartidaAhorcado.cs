using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Auxiliares;

namespace Entities
{
    public class PartidaAhorcado
    {
        private const int NUMERO_INTENTOS_MAX = 10;

        public readonly string PalabraAAdivinar;
        public int Intentos;
        public enum Estados { Jugando, Ganada, Perdida }

        public Estados Estado { get; private set; }

        public List<string> LetrasAcertadas = new List<string>();

        public List<string> LetrasIncorrectas = new List<string>();

        public PartidaAhorcado(string palabraAAdivinar)
        {
            this.PalabraAAdivinar = palabraAAdivinar;
            this.Intentos = NUMERO_INTENTOS_MAX;
            this.Estado = Estados.Jugando;
        }

        public bool RealizarIntento(string letra)
        {

            if (Validaciones.ValidarLetra(letra))
            {
                if (PalabraAAdivinar.Contains(letra))
                {
                    LetrasAcertadas.Add(letra);
                    PartidaGanada();
                    return true;
                }

                LetrasIncorrectas.Add(letra);
                Intentos--;
                PartidaPerdida();
                return false;
            }
            else
            {
                //TODO: Excepcion letra invalida
                return false;
            }
        }

        private void PartidaGanada()
        {
            foreach (char letra in PalabraAAdivinar)
            {
                if (!LetrasAcertadas.Contains(letra.ToString()))
                {
                    return;
                }
            }
            Estado = Estados.Ganada;
        }

        private void PartidaPerdida()
        {
            if (this.Intentos == 0)
                Estado = Estados.Perdida;
        }
       
    }
}
