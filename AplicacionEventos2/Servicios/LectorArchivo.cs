using AplicacionEventos2.Controladores.Interfaces;
using AplicacionEventos2.Servicios.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AplicacionEventos2.Servicios
{
    class LectorArchivo : ILectorArchivo
    {
        private IObtenedorArgumentos obtenedorArgumentos;

        public LectorArchivo(IObtenedorArgumentos obtenedorArgumentos)
        {
            this.obtenedorArgumentos = obtenedorArgumentos;
        }

        public StreamReader ObtenerStream()
        {
            StreamReader sr = new StreamReader(obtenedorArgumentos.ObtenerTextoArgumento());
            return sr;
        }
    }
}
