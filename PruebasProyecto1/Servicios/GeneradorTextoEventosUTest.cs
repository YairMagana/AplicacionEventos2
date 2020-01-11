using Microsoft.VisualStudio.TestTools.UnitTesting;
using AplicacionEventos2.Servicios;
using AplicacionEventos2.Servicios.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Moq;

namespace PruebasUnitarias
{
    [TestClass()]
    public class GeneradorTextoEventosUTest
    {
        [TestMethod()]
        public void GenerarTextoPorLinea_ObtenerUnaLineaDeTextoEventoCompleta_TextoDeLineaCompleto()
        {
            var DOCValidarColumnas = new Mock<IValidadorColumnas>();
            var DOCRealizadorComparaciones = new Mock<IRealizadorComparaciones>();

            DOCValidarColumnas.Setup(s => s.ValidarColumnas(It.IsAny<string[]>())).Returns(true);
            DOCRealizadorComparaciones.Setup(s => s.Comparar(It.IsAny<DateTime>(), It.IsAny<DateTime>())).Returns(" x");

            var SUT = new GeneradorTextoEventos(DOCValidarColumnas.Object, DOCRealizadorComparaciones.Object);
             
            var resultado = SUT.GenerarTextoPorLinea(new string[] { "Dia Pasado","01/20/2020" });
            Assert.AreEqual("\nEl evento Dia Pasado x", resultado);
        }
    }
}