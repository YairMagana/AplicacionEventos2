using Microsoft.VisualStudio.TestTools.UnitTesting;
using AplicacionEventos2.Clases.Procesador.Utilidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace AplicacionEventos2.Clases.Procesador.Utilidades.Tests
{
    [TestClass()]
    public class ValidadorCamposEventosUTest
    {
        [TestMethod()]
        public void ValidarCamposCVS_ValidarCamposNulos_Falso()
        {
            //Arrange
            string[] v = new string[] { null, null };
            var SUT = new ValidadorCamposEventos();

            //Act
            var resultado = SUT.ValidarCamposCVS(v);

            //Assert
            Assert.IsFalse(resultado);
        }

        [TestMethod()]
        public void ValidarCamposCVS_ValidarCamposConValoresSinFormatoDeEvento_Falso()
        {
            //Arrange
            string[] v = new string[] { "a", "b" };
            var SUT = new ValidadorCamposEventos();

            //Act
            var resultado = SUT.ValidarCamposCVS(v);

            //Assert
            Assert.IsFalse(resultado);
        }

        [TestMethod()]
        public void ValidarCamposCVS_ValidarCamposConValoresConFormatoDeEvento_Verdadero()
        {
            //Arrange
            string[] v = new string[] { "a", "2019/12/01" };
            var SUT = new ValidadorCamposEventos();

            //Act
            var resultado = SUT.ValidarCamposCVS(v);

            //Assert
            Assert.IsTrue(resultado);
        }
    }
}