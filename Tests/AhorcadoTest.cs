using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entities;
using System;


namespace Tests
{
    [TestClass]
    public class AhorcadoTest
    {
        private PartidaAhorcado ahorcado = new PartidaAhorcado("casa");

        [TestMethod]
        public void PalabraSeleccionada_Test()
        {
            string palabraEsperada = "casa";
            Assert.AreEqual(palabraEsperada, ahorcado.PalabraAAdivinar);
        }

        [TestMethod]
        public void IngresaUnaSolaLetra_Test()
        {
            bool letraValida = ahorcado.RealizarIntento("a");
            Assert.AreEqual(true, letraValida);
        }
        
        [TestMethod]
        public void RestarIntento_Test()
        {
            ahorcado.RealizarIntento("t");
            Assert.AreEqual(8, ahorcado.Intentos);
        }

        [TestMethod]
        public void SeEncuentraEnPalabra_Test()
        {
            bool resultado = ahorcado.RealizarIntento("a");
            Assert.AreEqual(true, resultado);
        }

        [TestMethod]
        public void NoSeEncuentraEnPalabra_Test()
        {
            bool resultado = ahorcado.RealizarIntento("h");
            Assert.AreEqual(false, resultado);
        }

        [TestMethod]
        public void PalabraCompleta_Test()
        {
            ahorcado.RealizarIntento("c");
            ahorcado.RealizarIntento("a");
            ahorcado.RealizarIntento("s");

            Assert.AreEqual(PartidaAhorcado.Estados.Ganada , ahorcado.Estado);
        }

        [TestMethod]
        public void GuardaLetraValida_Test()
        {
            ahorcado.RealizarIntento("c");

            Assert.AreEqual("c", ahorcado.LetrasAcertadas[0]);
        }

        [TestMethod]
        public void GuardaLetraInvalida_Test()
        {
            ahorcado.RealizarIntento("j");

            Assert.AreEqual("j", ahorcado.LetrasIncorrectas[0]);
        }

        [TestMethod]
        public void ComprobarEstado_Test()
        {
            ahorcado.RealizarIntento("b");
            ahorcado.RealizarIntento("d");
            ahorcado.RealizarIntento("e");
            ahorcado.RealizarIntento("f");
            ahorcado.RealizarIntento("g");
            ahorcado.RealizarIntento("h");
            ahorcado.RealizarIntento("i");
            ahorcado.RealizarIntento("j");
            ahorcado.RealizarIntento("k");
            ahorcado.RealizarIntento("l");
            ahorcado.RealizarIntento("m");

            Assert.AreEqual(PartidaAhorcado.Estados.Perdida, ahorcado.Estado);
        }
    }
}
