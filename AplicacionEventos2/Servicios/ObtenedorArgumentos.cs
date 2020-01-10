using AplicacionEventos2.Controladores.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace AplicacionEventos2.Servicios
{
    class ObtenedorArgumentos : IObtenedorArgumentos
    {
        private string[] args;

        public ObtenedorArgumentos(string[] args)
        {
            this.args = args;
        }

        public string ObtenerTextoArgumento()
        {
            string archivo = "prueba.csv";
            if (args.Length > 0)
                archivo = args[0];
            return archivo;
        }
    }
}
