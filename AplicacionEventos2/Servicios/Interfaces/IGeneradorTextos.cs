using System;
using System.Collections.Generic;
using System.Text;

namespace AplicacionEventos2.Servicios.Interfaces
{
    interface IGeneradorTextos
    {
        string GenerarTextoPorLinea(string[] columnas);
    }
}
