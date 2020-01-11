using AplicacionEventos2.Servicios.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace AplicacionEventos2.Servicios.Comparadores
{
    public class ComparadorDia : IComparadorTiempo
    {
        public string Comparar(DateTime dt1, DateTime dt2)
        {
            string texto = string.Empty;
            double diasTranscurridos = (dt1 - dt2).TotalDays;
            if (Math.Round((dt1 - dt2).TotalHours) >= 24 && Math.Round(diasTranscurridos) < 30)
            {
                texto = " ocurrira en " + Math.Round(diasTranscurridos).ToString() + " día(s).";
            }
            else if (Math.Round(-(dt1 - dt2).TotalHours) >= 24 && Math.Round(- diasTranscurridos) < 30)
            {
                texto = " ocurrió hace " + Math.Round(-diasTranscurridos).ToString() + " día(s).";
            }
            return texto;
        }
    }
}
