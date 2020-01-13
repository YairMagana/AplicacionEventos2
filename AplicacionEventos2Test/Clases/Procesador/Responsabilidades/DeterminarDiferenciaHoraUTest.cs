using Microsoft.VisualStudio.TestTools.UnitTesting;
using AplicacionEventos2.Servicios.Comparadores;
using System;
using Moq;
using AplicacionEventos2.Servicios.Interfaces;

namespace AplicacionEventos2.Clases.Procesador.Responsabilidades
{
    [TestClass()]
    public class DeterminarDiferenciaHoraUTest
    {
        [TestMethod()]
        public void DeterminarDiferenciaTiempo_DeterminarDiferenciaEnHorasPasadas_TextoConDiferenciaEnHoras()
        {
            //Arrange
            var DOCDeterminadorDiferenciaTiempoSiguiente = new Mock<IDeterminadorDiferenciaTiempo>();
            DOCDeterminadorDiferenciaTiempoSiguiente.Setup(s => s.DeterminarDiferenciaTiempo(It.IsAny<DateTime>(), It.IsAny<DateTime>())).Returns("DÍAS");

            DateTime dt1 = new DateTime(2019, 01, 01, 0, 0, 0);
            DateTime dt2 = new DateTime(2019, 01, 01, 10, 0, 0);

            var SUT = new DeterminadorDiferenciaHora(DOCDeterminadorDiferenciaTiempoSiguiente.Object);

            //Act
            var resultado = SUT.DeterminarDiferenciaTiempo(dt1, dt2);

            //Assert
            Assert.AreEqual(" ocurrió hace 10 hora(s).", resultado);
        }

        [TestMethod()]
        public void DeterminarDiferenciaTiempo_DeterminarDiferenciaEnHorasFuturas_TextoConDiferenciaEnHoras()
        {
            //Arrange
            var DOCDeterminadorDiferenciaTiempoSiguiente = new Mock<IDeterminadorDiferenciaTiempo>();
            DOCDeterminadorDiferenciaTiempoSiguiente.Setup(s => s.DeterminarDiferenciaTiempo(It.IsAny<DateTime>(), It.IsAny<DateTime>())).Returns("DÍAS");

            DateTime dt1 = new DateTime(2019, 01, 01, 10, 0, 0);
            DateTime dt2 = new DateTime(2019, 01, 01, 0, 0, 0);

            var SUT = new DeterminadorDiferenciaHora(DOCDeterminadorDiferenciaTiempoSiguiente.Object);

            //Act
            var resultado = SUT.DeterminarDiferenciaTiempo(dt1, dt2);

            //Assert
            Assert.AreEqual(" ocurrirá en 10 hora(s).", resultado);
        }

        [TestMethod()]
        public void DeterminarDiferenciaTiempo_PeriodoDeTiempoExede24Horas_UsarLaSiguientesResponsabilidades()
        {
            //Arrange
            var DOCDeterminadorDiferenciaTiempoSiguiente = new Mock<IDeterminadorDiferenciaTiempo>();
            DOCDeterminadorDiferenciaTiempoSiguiente.Setup(s => s.DeterminarDiferenciaTiempo(It.IsAny<DateTime>(), It.IsAny<DateTime>())).Returns("DÍAS");

            DateTime dt1 = new DateTime(2019, 01, 01);
            DateTime dt2 = new DateTime(2019, 01, 05);

            var SUT = new DeterminadorDiferenciaHora(DOCDeterminadorDiferenciaTiempoSiguiente.Object);

            //Act
            var resultado = SUT.DeterminarDiferenciaTiempo(dt1, dt2);

            //Assert
            Assert.AreEqual("DÍAS", resultado);
        }
    }
}