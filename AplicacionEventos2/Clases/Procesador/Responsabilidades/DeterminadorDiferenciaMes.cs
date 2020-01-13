using System;

namespace AplicacionEventos2.Clases.Procesador.Responsabilidades
{
    public class DeterminadorDiferenciaMes : IDeterminadorDiferenciaTiempo
    {
        private readonly IDeterminadorDiferenciaTiempo determinadorDiferenciaTiempoSiguiente;

        public DeterminadorDiferenciaMes(IDeterminadorDiferenciaTiempo _determinadorDiferenciaTiempoSiguiente)
        {
            determinadorDiferenciaTiempoSiguiente = _determinadorDiferenciaTiempoSiguiente;
        }

        public string DeterminarDiferenciaTiempo(DateTime dt1, DateTime dt2)
        {
            string texto;
            double diasTranscurridos = (dt1 - dt2).TotalDays;

            if (true)
                if (diasTranscurridos >= 0)
                    texto = " ocurrirá en " + Math.Round(diasTranscurridos / 30).ToString() + " mes(es).";
                else
                    texto = " ocurrió hace " + Math.Round(-diasTranscurridos / 30).ToString() + " mes(es).";
            return texto;
        }
    }
}
