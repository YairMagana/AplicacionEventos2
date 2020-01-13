using Microsoft.VisualStudio.TestTools.UnitTesting;
using AplicacionEventos2.Clases.Procesador;
using System;
using System.Collections.Generic;
using System.Text;
using AplicacionEventos2.Clases.Procesador.Utilidades;
using AplicacionEventos2.Clases.Procesador.Responsabilidades;
using Moq;

namespace AplicacionEventos2.Clases.Procesador.Tests
{
    [TestClass()]
    public class AnalizadorTextoEventoUTest
    {
        [TestMethod()]
        public void AnalizarTextoEvento_AnalizarEventoCadenaNula_TextoEventoInvalido()
        {
            // Arrange
            var DOCdivisorLinea = new Mock<IDivisorLinea>();
            DOCdivisorLinea.Setup(s => s.DividirLinea(It.IsAny<string>())).Returns(new string[] { null, null });
            var DOCvalidadorCamposCVS = new Mock<IValidadorCamposCVS>();
            DOCvalidadorCamposCVS.Setup(s => s.ValidarCamposCVS(It.IsAny<string[]>())).Returns(false);
            var DOCdeterminadorDiferenciaTiempo = new Mock<IDeterminadorDiferenciaTiempo>();

            string v = null;
            string s = "-- Evento Inválido --";

            // Act
            var SUT = new AnalizadorTextoEvento(DOCdivisorLinea.Object, DOCvalidadorCamposCVS.Object, DOCdeterminadorDiferenciaTiempo.Object);
            var resultado = SUT.AnalizarTextoEvento(v);
            // Assert
            Assert.AreEqual(s, resultado);
        }

        [TestMethod()]
        public void AnalizarTextoEvento_AnalizarEventoCadenaVacia_TextoEventoInvalido()
        {
            // Arrange
            var DOCdivisorLinea = new Mock<IDivisorLinea>();
            DOCdivisorLinea.Setup(s => s.DividirLinea(It.IsAny<string>())).Returns(new string[] { null, null });
            var DOCvalidadorCamposCVS = new Mock<IValidadorCamposCVS>();
            DOCvalidadorCamposCVS.Setup(s => s.ValidarCamposCVS(It.IsAny<string[]>())).Returns(false);
            var DOCdeterminadorDiferenciaTiempo = new Mock<IDeterminadorDiferenciaTiempo>();

            string v = "";
            string s = "-- Evento Inválido --";

            // Act
            var SUT = new AnalizadorTextoEvento(DOCdivisorLinea.Object, DOCvalidadorCamposCVS.Object, DOCdeterminadorDiferenciaTiempo.Object);
            var resultado = SUT.AnalizarTextoEvento(v);
            // Assert
            Assert.AreEqual(s, resultado);
        }

        [TestMethod()]
        public void AnalizarTextoEvento_AnalizarEventoFormatoInvalido_TextoEventoInvalido()
        {
            // Arrange
            var DOCdivisorLinea = new Mock<IDivisorLinea>();
            DOCdivisorLinea.Setup(s => s.DividirLinea(It.IsAny<string>())).Returns(new string[] { "a", "b" });
            var DOCvalidadorCamposCVS = new Mock<IValidadorCamposCVS>();
            DOCvalidadorCamposCVS.Setup(s => s.ValidarCamposCVS(It.IsAny<string[]>())).Returns(false);
            var DOCdeterminadorDiferenciaTiempo = new Mock<IDeterminadorDiferenciaTiempo>();

            string v = "a,b";
            string s = "-- Evento Inválido --";

            // Act
            var SUT = new AnalizadorTextoEvento(DOCdivisorLinea.Object, DOCvalidadorCamposCVS.Object, DOCdeterminadorDiferenciaTiempo.Object);
            var resultado = SUT.AnalizarTextoEvento(v);
            // Assert
            Assert.AreEqual(s, resultado);
        }

        [TestMethod()]
        public void AnalizarTextoEvento_AnalizarEventoFormatoValido_TextoEventoInvalido()
        {
            // Arrange
            var DOCdivisorLinea = new Mock<IDivisorLinea>();
            DOCdivisorLinea.Setup(s => s.DividirLinea(It.IsAny<string>())).Returns(new string[] { "a", "2020/07/01" });
            var DOCvalidadorCamposCVS = new Mock<IValidadorCamposCVS>();
            DOCvalidadorCamposCVS.Setup(s => s.ValidarCamposCVS(It.IsAny<string[]>())).Returns(true);
            var DOCdeterminadorDiferenciaTiempo = new Mock<IDeterminadorDiferenciaTiempo>();
            DOCdeterminadorDiferenciaTiempo.Setup(s => s.DeterminarDiferenciaTiempo(It.IsAny<DateTime>(), It.IsAny<DateTime>())).Returns(" ocurrirá en 6 mes(es)");

            string v = "a, 2020/07/01";

            // Act
            var SUT = new AnalizadorTextoEvento(DOCdivisorLinea.Object, DOCvalidadorCamposCVS.Object, DOCdeterminadorDiferenciaTiempo.Object);
            var resultado = SUT.AnalizarTextoEvento(v);
            // Assert
            Assert.AreEqual("El evento a, ocurrirá en 6 mes(es)", resultado);
        }
    }
}