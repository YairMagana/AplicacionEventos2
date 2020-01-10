using AplicacionEventos2.Servicios.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace AplicacionEventos2.Servicios
{
    class ParseadorLinea : IParseadorLinea
    {
        public string[] ObtenerValoresLinea(string l)
        {
            string[] columnas;
            columnas = l.Split(new char[] { ',' });
            if (columnas.Length < 2)
            {
                columnas = new string[2];
            }
            return columnas;
        }
    }
}
