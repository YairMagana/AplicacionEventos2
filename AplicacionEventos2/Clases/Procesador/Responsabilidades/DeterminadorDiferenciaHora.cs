using System;

namespace AplicacionEventos2.Clases.Procesador.Responsabilidades
{
    public class DeterminadorDiferenciaHora : IDeterminadorDiferenciaTiempo
    {
        private readonly IDeterminadorDiferenciaTiempo determinadorDiferenciaTiempoSiguiente;

        public DeterminadorDiferenciaHora(IDeterminadorDiferenciaTiempo _determinadorDiferenciaTiempoSiguiente)
        {
            determinadorDiferenciaTiempoSiguiente = _determinadorDiferenciaTiempoSiguiente;
        }

        public string DeterminarDiferenciaTiempo(DateTime dt1, DateTime dt2)
        {
            string texto;
            double horasTranscurridas = (dt1 - dt2).TotalHours;
            if (Math.Round(Math.Abs(horasTranscurridas)) < 24)
                if (horasTranscurridas >= 0)
                    texto = " ocurrirá en " + Math.Round(horasTranscurridas).ToString() + " hora(s).";
                else
                    texto = " ocurrió hace " + Math.Round(-horasTranscurridas).ToString() + " hora(s).";
            else
                texto = determinadorDiferenciaTiempoSiguiente.DeterminarDiferenciaTiempo(dt1, dt2);
            return texto;
        }
    }
}
