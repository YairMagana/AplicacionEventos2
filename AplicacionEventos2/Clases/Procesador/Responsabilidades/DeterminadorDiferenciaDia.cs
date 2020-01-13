using System;

namespace AplicacionEventos2.Clases.Procesador.Responsabilidades
{
    public class DeterminadorDiferenciaDia : IDeterminadorDiferenciaTiempo
    {
        private readonly IDeterminadorDiferenciaTiempo determinadorDiferenciaTiempoSiguiente;

        public DeterminadorDiferenciaDia(IDeterminadorDiferenciaTiempo _determinadorDiferenciaTiempoSiguiente)
        {
            determinadorDiferenciaTiempoSiguiente = _determinadorDiferenciaTiempoSiguiente;
        }

        public string DeterminarDiferenciaTiempo(DateTime dt1, DateTime dt2)
        {
            string texto;
            double diasTranscurridos = (dt1 - dt2).TotalDays;
            if (Math.Round(Math.Abs(diasTranscurridos)) < 30)
                if (diasTranscurridos >= 0)
                    texto = " ocurrirá en " + Math.Round(diasTranscurridos).ToString() + " día(s).";
                else
                    texto = " ocurrió hace " + Math.Round(-diasTranscurridos).ToString() + " día(s).";
            else
                texto = determinadorDiferenciaTiempoSiguiente.DeterminarDiferenciaTiempo(dt1, dt2);
            return texto;
        }
    }
}
