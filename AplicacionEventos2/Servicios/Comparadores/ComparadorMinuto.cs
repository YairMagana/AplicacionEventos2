using AplicacionEventos2.Servicios.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace AplicacionEventos2.Servicios.Comparadores
{
    class ComparadorMinuto : IComparadorTiempo
    {
        public string Comparar(DateTime dt1, DateTime dt2)
        {
            string texto = string.Empty;
            double minutosTranscurridos = (dt1 - dt2).TotalMinutes;
            if (minutosTranscurridos >= 0 && minutosTranscurridos < 60)
            {
                texto = " ocurrira en " + Math.Ceiling(Math.Abs(minutosTranscurridos)).ToString() + " minuto(s).";
            }
            else if (-minutosTranscurridos >= 0 && -minutosTranscurridos <60)
            {
                texto = " ocurrió hace " + Math.Floor(Math.Abs(minutosTranscurridos)).ToString() + " minuto(s).";
            }
            return texto;
        }
    }
}
