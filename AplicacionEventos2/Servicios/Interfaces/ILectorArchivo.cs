using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AplicacionEventos2.Servicios.Interfaces
{
    public interface ILectorArchivo
    {
        StreamReader ObtenerStream();
    }
}
