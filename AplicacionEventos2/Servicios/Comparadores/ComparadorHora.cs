using AplicacionEventos2.Servicios.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace AplicacionEventos2.Servicios.Comparadores
{
    public class ComparadorHora : IComparadorTiempo
    {
        public string Comparar(DateTime dt1, DateTime dt2)
        {
            string texto = string.Empty;
            double horasTranscurridas = (dt1 - dt2).TotalHours;
            if (Math.Round((dt1 - dt2).TotalMinutes) >= 60 && Math.Round(horasTranscurridas) < 24)
            {
                texto = " ocurrirá en " + Math.Round(horasTranscurridas).ToString() + " hora(s).";
            }
            else if (Math.Round(-(dt1 - dt2).TotalMinutes) >= 60 && Math.Round(- horasTranscurridas) < 24)
            {
                texto = " ocurrió hace " + Math.Round(-horasTranscurridas).ToString() + " hora(s).";
            }
            return texto;
        }
    }
}
