using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entities;
using System;


namespace Tests
{
    [TestClass]
    public class AhorcadoTest
    {
        private Ahorcado ahorcado = new Ahorcado("casa");
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
        public void EliminarLetra_Test()
        {
            ahorcado.RealizarIntento("a");
            bool letraEsta = ahorcado.Abecedario.Contains("a");
            Assert.AreEqual(false, letraEsta);
        }
        
        [TestMethod]
        public void RestarIntento_Test()
        {
            ahorcado.RealizarIntento("a");
            Assert.AreEqual(9, ahorcado.Intentos);
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

            Assert.AreEqual(Ahorcado.Estados.Ganada , ahorcado.Estado);
        }
    }
}
