using Microsoft.VisualStudio.TestTools.UnitTesting;
using AplicacionEventos2.Clases.Procesador.Responsabilidades;
using System;
using System.Collections.Generic;
using System.Text;
using Moq;

namespace AplicacionEventos2.Clases.Procesador.Responsabilidades.Tests
{
    [TestClass()]
    public class DeterminadorDiferenciaMesUTest
    {
        [TestMethod()]
        public void DeterminarDiferenciaTiempo_DeterminarDiferenciaEnMesesPasados_TextoConDiferenciaEnMeses()
        {
            //Arrange
            DateTime dt1 = new DateTime(2020, 01, 01);
            DateTime dt2 = new DateTime(2020, 06, 01);

            var SUT = new DeterminadorDiferenciaMes(null);

            //Act
            var resultado = SUT.DeterminarDiferenciaTiempo(dt1, dt2);

            //Assert
            Assert.AreEqual(" ocurrió hace 5 mes(es).", resultado);
        }

        [TestMethod()]
        public void DeterminarDiferenciaTiempo_DeterminarDiferenciaEnMesesFuturos_TextoConDiferenciaEnMeses()
        {
            //Arrange
            DateTime dt1 = new DateTime(2020, 06, 01);
            DateTime dt2 = new DateTime(2020, 01, 01);

            var SUT = new DeterminadorDiferenciaMes(null);

            //Act
            var resultado = SUT.DeterminarDiferenciaTiempo(dt1, dt2);

            //Assert
            Assert.AreEqual(" ocurrirá en 5 mes(es).", resultado);
        }

        [TestMethod()]
        public void DeterminarDiferenciaTiempo_PeriodoDeTiempoExede12Meses_UsarSiguientesResponsabilidades()
        {
            //Arrange
            DateTime dt1 = new DateTime(2021, 01, 01);
            DateTime dt2 = new DateTime(2019, 01, 01);

            var SUT = new DeterminadorDiferenciaMes(null);

            //Act
            var resultado = SUT.DeterminarDiferenciaTiempo(dt1, dt2);

            //Assert
            Assert.AreEqual(" ocurrirá en 24 mes(es).", resultado);
        }
    }
}