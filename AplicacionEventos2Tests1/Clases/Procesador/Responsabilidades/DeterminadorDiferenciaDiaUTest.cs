using Microsoft.VisualStudio.TestTools.UnitTesting;
using AplicacionEventos2.Clases.Procesador.Responsabilidades;
using System;
using System.Collections.Generic;
using System.Text;
using Moq;

namespace AplicacionEventos2.Clases.Procesador.Responsabilidades.Tests
{
    [TestClass()]
    public class DeterminadorDiferenciaDiaUTest
    {
        [TestMethod()]
        public void DeterminarDiferenciaTiempo_DeterminarDiferenciaEnDiasPasados_TextoConDiferenciaEnDias()
        {
            //Arrange
            var DOCDeterminadorDiferenciaTiempoSiguiente = new Mock<IDeterminadorDiferenciaTiempo>();
            DOCDeterminadorDiferenciaTiempoSiguiente.Setup(s => s.DeterminarDiferenciaTiempo(It.IsAny<DateTime>(), It.IsAny<DateTime>())).Returns("MESES");

            DateTime dt1 = new DateTime(2019, 01, 01);
            DateTime dt2 = new DateTime(2019, 01, 10);

            var SUT = new DeterminadorDiferenciaDia(DOCDeterminadorDiferenciaTiempoSiguiente.Object);

            //Act
            var resultado = SUT.DeterminarDiferenciaTiempo(dt1, dt2);

            //Assert
            Assert.AreEqual(" ocurrió hace 9 día(s).", resultado);
        }

        [TestMethod()]
        public void DeterminarDiferenciaTiempo_DeterminarDiferenciaEnDiasFuturos_TextoConDiferenciaEnDias()
        {
            //Arrange
            var DOCDeterminadorDiferenciaTiempoSiguiente = new Mock<IDeterminadorDiferenciaTiempo>();
            DOCDeterminadorDiferenciaTiempoSiguiente.Setup(s => s.DeterminarDiferenciaTiempo(It.IsAny<DateTime>(), It.IsAny<DateTime>())).Returns("MESES");

            DateTime dt1 = new DateTime(2019, 01, 10);
            DateTime dt2 = new DateTime(2019, 01, 01);

            var SUT = new DeterminadorDiferenciaDia(DOCDeterminadorDiferenciaTiempoSiguiente.Object);

            //Act
            var resultado = SUT.DeterminarDiferenciaTiempo(dt1, dt2);

            //Assert
            Assert.AreEqual(" ocurrirá en 9 día(s).", resultado);
        }

        [TestMethod()]
        public void DeterminarDiferenciaTiempo_PeriodoDeTiempoExede30Dias_UsarSiguientesResponsabilidades()
        {
            //Arrange
            var DOCDeterminadorDiferenciaTiempoSiguiente = new Mock<IDeterminadorDiferenciaTiempo>();
            DOCDeterminadorDiferenciaTiempoSiguiente.Setup(s => s.DeterminarDiferenciaTiempo(It.IsAny<DateTime>(), It.IsAny<DateTime>())).Returns("MESES");

            DateTime dt1 = new DateTime(2019, 01, 01);
            DateTime dt2 = new DateTime(2019, 03, 15);

            var SUT = new DeterminadorDiferenciaDia(DOCDeterminadorDiferenciaTiempoSiguiente.Object);

            //Act
            var resultado = SUT.DeterminarDiferenciaTiempo(dt1, dt2);

            //Assert
            Assert.AreEqual("MESES", resultado);
        }
    }
}