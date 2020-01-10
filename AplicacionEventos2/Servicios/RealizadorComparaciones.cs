using AplicacionEventos2.Servicios.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace AplicacionEventos2.Servicios
{
    class RealizadorComparaciones : IRealizadorComparaciones
    {
        private List<IComparadorTiempo> lstComparadores;

        public RealizadorComparaciones(List<IComparadorTiempo> lstComparadores)
        {
            this.lstComparadores = lstComparadores;
        }

        public string Comparar(DateTime dt1, DateTime dt2)
        {
            string texto = string.Empty;
            foreach (IComparadorTiempo comparadorTiempo in lstComparadores)
            {
                texto = comparadorTiempo.Comparar(dt1, dt2);
                if (!string.IsNullOrEmpty(texto)) break;
            }
            return texto;
        }
    }
}
