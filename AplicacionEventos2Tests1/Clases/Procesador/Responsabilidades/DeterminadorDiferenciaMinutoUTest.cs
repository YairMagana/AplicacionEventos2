using Microsoft.VisualStudio.TestTools.UnitTesting;
using AplicacionEventos2.Clases.Procesador.Responsabilidades;
using System;
using System.Collections.Generic;
using System.Text;
using Moq;

namespace AplicacionEventos2.Clases.Procesador.Responsabilidades.Tests
{
    [TestClass()]
    public class DeterminadorDiferenciaMinutoUTest
    {
        [TestMethod()]
        public void DeterminarDiferenciaTiempo_DeterminarDiferenciaEnMinutosPasados_TextoConDiferenciaEnMinutos()
        {
            //Arrange
            var DOCDeterminadorDiferenciaTiempoSiguiente = new Mock<IDeterminadorDiferenciaTiempo>();
            DOCDeterminadorDiferenciaTiempoSiguiente.Setup(s => s.DeterminarDiferenciaTiempo(It.IsAny<DateTime>(), It.IsAny<DateTime>())).Returns("HORAS");

            DateTime dt1 = new DateTime(2019, 01, 01, 10, 0, 0);
            DateTime dt2 = new DateTime(2019, 01, 01, 10, 10, 0);

            var SUT = new DeterminadorDiferenciaMinuto(DOCDeterminadorDiferenciaTiempoSiguiente.Object);

            //Act
            var resultado = SUT.DeterminarDiferenciaTiempo(dt1, dt2);

            //Assert
            Assert.AreEqual(" ocurrió hace 10 minuto(s).", resultado);
        }

        [TestMethod()]
        public void DeterminarDiferenciaTiempo_DeterminarDiferenciaEnMinutosFuturos_TextoConDiferenciaEnMinutos()
        {
            //Arrange
            var DOCDeterminadorDiferenciaTiempoSiguiente = new Mock<IDeterminadorDiferenciaTiempo>();
            DOCDeterminadorDiferenciaTiempoSiguiente.Setup(s => s.DeterminarDiferenciaTiempo(It.IsAny<DateTime>(), It.IsAny<DateTime>())).Returns("HORAS");

            DateTime dt1 = new DateTime(2019, 01, 01, 10, 10, 0);
            DateTime dt2 = new DateTime(2019, 01, 01, 10, 0, 0);

            var SUT = new DeterminadorDiferenciaMinuto(DOCDeterminadorDiferenciaTiempoSiguiente.Object);

            //Act
            var resultado = SUT.DeterminarDiferenciaTiempo(dt1, dt2);

            //Assert
            Assert.AreEqual(" ocurrirá en 10 minuto(s).", resultado);
        }

        [TestMethod()]
        public void DeterminarDiferenciaTiempo_PeriodoDeTiempoExede60Minutos_UsarSiguientesResponsabilidades()
        {
            //Arrange
            var DOCDeterminadorDiferenciaTiempoSiguiente = new Mock<IDeterminadorDiferenciaTiempo>();
            DOCDeterminadorDiferenciaTiempoSiguiente.Setup(s => s.DeterminarDiferenciaTiempo(It.IsAny<DateTime>(), It.IsAny<DateTime>())).Returns("HORAS");

            DateTime dt1 = new DateTime(2019, 01, 01);
            DateTime dt2 = new DateTime(2019, 01, 02);

            var SUT = new DeterminadorDiferenciaMinuto(DOCDeterminadorDiferenciaTiempoSiguiente.Object);

            //Act
            var resultado = SUT.DeterminarDiferenciaTiempo(dt1, dt2);

            //Assert
            Assert.AreEqual("HORAS", resultado);
        }
    }
}