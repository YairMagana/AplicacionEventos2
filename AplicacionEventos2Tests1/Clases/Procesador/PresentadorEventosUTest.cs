using Microsoft.VisualStudio.TestTools.UnitTesting;
using AplicacionEventos2.Clases.Procesador;
using System;
using System.Collections.Generic;
using System.Text;
using Moq;

namespace AplicacionEventos2.Clases.Procesador.Tests
{
    [TestClass()]
    public class PresentadorEventosUTest
    {
        [TestMethod()]
        public void PresentarEventos_PresentarUnaListaComoTexto_TextoConElementosDeLista()
        {
            //Arrange
            var DOCAnalizadorTextoEvento = new Mock<IAnalizadorTextoEvento>();
            DOCAnalizadorTextoEvento.Setup(s => s.AnalizarTextoEvento(It.IsAny<string>())).Returns<string>(r => r);

            List<string> v = new List<string> { "a", "b", "c" };

            var SUT = new PresentadorEventos(v, DOCAnalizadorTextoEvento.Object);

            //Act
            var resultado = SUT.PresentarEventos();

            //Assert
            Assert.AreEqual("\na\nb\nc", resultado);
        }

        [TestMethod()]
        public void PresentarEventos_PresentarUnaListaNula_CadenaVacia()
        {
            //Arrange
            var DOCAnalizadorTextoEvento = new Mock<IAnalizadorTextoEvento>();
            DOCAnalizadorTextoEvento.Setup(s => s.AnalizarTextoEvento(It.IsAny<string>())).Returns<string>(r => r);

            List<string> v = null;

            var SUT = new PresentadorEventos(v, DOCAnalizadorTextoEvento.Object);

            //Act
            var resultado = SUT.PresentarEventos();

            //Assert
            Assert.AreEqual(string.Empty, resultado);
        }
    }
}