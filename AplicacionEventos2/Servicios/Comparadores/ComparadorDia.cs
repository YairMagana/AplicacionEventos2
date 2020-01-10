using AplicacionEventos2.Servicios.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace AplicacionEventos2.Servicios.Comparadores
{
    class ComparadorDia : IComparadorTiempo
    {
        public string Comparar(DateTime dt1, DateTime dt2)
        {
            string texto = string.Empty;
            double diasTranscurridos = (dt1 - dt2).TotalDays;
            if (diasTranscurridos >= 1 && diasTranscurridos < 30)
            {
                texto = " ocurrira en " + Math.Ceiling(Math.Abs(diasTranscurridos)).ToString() + " día(s).";
            }
            else if (-diasTranscurridos >= 1 && -diasTranscurridos < 30)
            {
                texto = " ocurrió hace " + Math.Floor(Math.Abs(diasTranscurridos)).ToString() + " día(s).";
            }
            return texto;
        }
    }
}
