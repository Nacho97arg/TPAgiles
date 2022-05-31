using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entities;
using System;


namespace Tests
{
    [TestClass]
    public class AhorcadoTest
    {
        [TestMethod]
        public void PalabraSeleccionada_Test()
        {
            Ahorcado ahorcado = new Ahorcado("casa");
            string palabraEsperada = "casa";
            Assert.AreEqual(palabraEsperada, ahorcado.PalabraAAdivinar);          
        }

        //[TestMethod]
        //public void IngresaLetraValida_Test()
        //{
        //    Ahorcado ahorcado = new Ahorcado("casa");   
        //    bool letraValida  = ahorcado.IngresarLetra('a');
        //    Assert.AreEqual(true, letraValida); 

        //}


        [TestMethod]
        public void IngresaUnaSolaLetra_Test()
        {
            Ahorcado ahorcado = new Ahorcado("casa");
            bool letraValida = ahorcado.RealizarIntento("a");
            Assert.AreEqual(true, letraValida);
        }

        [TestMethod]
        public void EliminarLetra_Test()
        {
            Ahorcado ahorcado = new Ahorcado("casa");
            ahorcado.RealizarIntento("a");
            bool letraEsta = ahorcado.Abecedario.Contains("a");
            Assert.AreEqual(false, letraEsta);
        }
        
        [TestMethod]
        public void RestarIntento_Test()
        {
            Ahorcado ahorcado = new Ahorcado("casa");
            ahorcado.RealizarIntento("a");
            Assert.AreEqual(9, ahorcado.Intentos);
        }

        [TestMethod]
        public void SeEncuentraEnPalabra_Test()
        {
            Ahorcado ahorcado = new Ahorcado("casa");
            bool resultado = ahorcado.RealizarIntento("a");
            Assert.AreEqual(true, resultado);
        }
    }
}
