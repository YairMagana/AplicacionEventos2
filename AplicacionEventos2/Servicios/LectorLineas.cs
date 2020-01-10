using AplicacionEventos2.Servicios.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AplicacionEventos2.Servicios
{
    class LectorLineas : ILectorLineas
    {
        private ILectorArchivo lectorArchivos;
        private IParseadorLinea parseadorLinea;
        private IGeneradorTextos generadorTextos;

        public LectorLineas(ILectorArchivo _lectorArchivos, IParseadorLinea _parseadorLinea, IGeneradorTextos _generadorTextos)
        {
            lectorArchivos = _lectorArchivos;
            parseadorLinea = _parseadorLinea;
            generadorTextos = _generadorTextos;
        }

        public string ObtenerTextos()
        {
            string texto = String.Empty;
            string[] arrEvento;
            try
            {
                using (StreamReader sr = lectorArchivos.ObtenerStream())
                {
                    string linea;
                    while (null != (linea = sr.ReadLine()))
                    {
                        arrEvento = parseadorLinea.ObtenerValoresLinea(linea);
                        texto += generadorTextos.GenerarTextoPorLinea(arrEvento);
                    }
                }
            }
            catch (Exception ex)
            {
                texto = ex.Message;
            }
            return texto;
        }
    }
}
