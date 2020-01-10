using AplicacionEventos2.Controladores.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace AplicacionEventos2.Controladores
{
    class DesplegadorPantalla : IDesplegador
    {
        public void Desplegar(string _texto)
        {
            Console.WriteLine(_texto);
            Console.ReadKey();
        }
    }
}
