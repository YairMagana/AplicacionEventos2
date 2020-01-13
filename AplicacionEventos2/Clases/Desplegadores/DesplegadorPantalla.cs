using System;

namespace AplicacionEventos2.Clases.Desplegadores
{
    public class DesplegadorPantalla : IDesplegador
    {
        public void Desplegar(string _texto)
        {
            Console.WriteLine(_texto);
            Console.ReadKey();
        }
    }
}
