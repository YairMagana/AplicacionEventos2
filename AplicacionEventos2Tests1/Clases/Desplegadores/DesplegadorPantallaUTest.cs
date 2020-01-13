using Microsoft.VisualStudio.TestTools.UnitTesting;
using AplicacionEventos2.Clases.Desplegadores;
using System;
using System.Collections.Generic;
using System.Text;
using Moq;

namespace AplicacionEventos2.Clases.Desplegadores.Tests
{
    [TestClass()]
    public class DesplegadorPantallaUTest
    {
        [TestMethod()]
        public void Desplegar_ProbarQueSeAccedioADesplegar_MetodoAccedidoCorrectamente()
        {
            //Arrange
            var DOCDesplegadorPantalla = new Mock<IDesplegador>();

            //Act
            DOCDesplegadorPantalla.Object.Desplegar("Texto");

            //Assert
            DOCDesplegadorPantalla.Verify(v => v.Desplegar(It.IsAny<string>()), Times.Once());
        }
    }
}