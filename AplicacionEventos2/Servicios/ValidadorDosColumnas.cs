using AplicacionEventos2.Servicios.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace AplicacionEventos2.Servicios
{
    class ValidadorDosColumnas : IValidadorColumnas
    {
        public bool ValidarColumnas(string[] columnas)
        {
            bool v = false;
            if (ValidarTamano(columnas))
            {
                if (ValidarFecha(columnas[1]))
                {
                    v = true;
                }
            }
            return v;
        }

        private bool ValidarTamano(string[] columnas)
        {
            if (columnas.Length == 2)   // Validación específica de la clase
                return true;
            return false;
        }

        private bool ValidarFecha(string texto)
        {
            DateTime dt;
            return DateTime.TryParse(texto, out dt);
        }
    }
}
