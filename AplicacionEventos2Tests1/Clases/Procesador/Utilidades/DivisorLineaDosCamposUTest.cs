using Microsoft.VisualStudio.TestTools.UnitTesting;
using AplicacionEventos2.Clases.Procesador.Utilidades;
using System;
using System.Collections.Generic;
using System.Text;
using Moq;

namespace AplicacionEventos2.Clases.Procesador.Utilidades.Tests
{
    [TestClass()]
    public class DivisorLineaDosCamposUTest
    {
        [TestMethod()]
        public void DividirLinea_DividirCadenaVacia_ArregloConDosElementosNulos()
        {
            //Arrange
            string DOC = string.Empty;
            var SUT = new DivisorLineaDosCampos();

            //Act
            var resultado = SUT.DividirLinea(DOC);

            //Assert
            CollectionAssert.AreEqual(new string[] { null, null }, resultado);
        }

        [TestMethod()]
        public void DividirLinea_DividirCadenaConValorSinComa_ArregloConDosPrimerosElementosSeparadosPorComa()
        {
            //Arrange
            string DOC = "abc";
            var SUT = new DivisorLineaDosCampos();

            //Act
            var resultado = SUT.DividirLinea(DOC);

            //Assert
            CollectionAssert.AreEqual(new string[] { "abc", null }, resultado);
        }

        [TestMethod()]
        public void DividirLinea_DividirCadenaCon2ValoresSeparadosPorComa_ArregloConDosElementosSeparadosPorComa()
        {
            //Arrange
            string DOC = "a,b";
            var SUT = new DivisorLineaDosCampos();

            //Act
            var resultado = SUT.DividirLinea(DOC);

            //Assert
            CollectionAssert.AreEqual(new string[] { "a", "b" }, resultado);
        }

        [TestMethod()]
        public void DividirLinea_DividirCadenaCon3ValoresSeparadosPorComa_ArregloConDosPrimerosElementosSeparadosPorComa()
        {
            //Arrange
            string DOC = "a,b,c";
            var SUT = new DivisorLineaDosCampos();

            //Act
            var resultado = SUT.DividirLinea(DOC);

            //Assert
            CollectionAssert.AreEqual(new string[] { "a", "b" }, resultado);
        }
    }
}