using AplicacionEventos2.Servicios.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace AplicacionEventos2.Servicios.Comparadores
{
    class ComparadorHora : IComparadorTiempo
    {
        public string Comparar(DateTime dt1, DateTime dt2)
        {
            string texto = string.Empty;
            double horasTranscurridas = (dt1 - dt2).TotalHours;
            if (horasTranscurridas >= 1 && horasTranscurridas < 24)
            {
                texto = " ocurrira en " + Math.Ceiling(Math.Abs(horasTranscurridas)).ToString() + " hora(s).";
            }
            else if (-horasTranscurridas >= 1 && -horasTranscurridas < 24)
            {
                texto = " ocurrió hace " + Math.Floor(Math.Abs(horasTranscurridas)).ToString() + " hora(s).";
            }
            return texto;
        }
    }
}
