using AplicacionEventos2.Servicios.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace AplicacionEventos2.Servicios
{
    class GeneradorTextoEventos : IGeneradorTextos
    {
        IValidadorColumnas validadorColumnas;
        IRealizadorComparaciones realizadorComparaciones;

        public GeneradorTextoEventos(IValidadorColumnas _validadorColumnas, IRealizadorComparaciones _realizadorComparaciones)
        {
            validadorColumnas = _validadorColumnas;
            realizadorComparaciones = _realizadorComparaciones;
        }
        public string GenerarTextoPorLinea(string[] columnas)
        {
            string texto = string.Empty;
            DateTime dt;
            DateTime ahora = DateTime.Now;
            if (validadorColumnas.ValidarColumnas(columnas))
            {
                DateTime.TryParse(columnas[1], out dt);
                texto = "\nEl evento " + columnas[0] + realizadorComparaciones.Comparar(dt, ahora);
            }
            else
            {
                texto = "¡Formato de línea incorrecto!";
            }
            return texto;
        }
    }
}
