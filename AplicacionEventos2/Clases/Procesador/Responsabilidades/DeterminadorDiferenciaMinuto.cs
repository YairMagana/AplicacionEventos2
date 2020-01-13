using System;

namespace AplicacionEventos2.Clases.Procesador.Responsabilidades
{
    public class DeterminadorDiferenciaMinuto : IDeterminadorDiferenciaTiempo
    {
        private readonly IDeterminadorDiferenciaTiempo determinadorDiferenciaTiempoSiguiente;

        public DeterminadorDiferenciaMinuto(IDeterminadorDiferenciaTiempo _determinadorDiferenciaTiempoSiguiente)
        {
            determinadorDiferenciaTiempoSiguiente = _determinadorDiferenciaTiempoSiguiente;
        }

        public string DeterminarDiferenciaTiempo(DateTime dt1, DateTime dt2)
        {
            string texto;
            double minutosTranscurridos = (dt1 - dt2).TotalMinutes;
            if (Math.Round(Math.Abs(minutosTranscurridos)) < 60)
                if (minutosTranscurridos >= 0)
                    texto = " ocurrirá en " + Math.Round(minutosTranscurridos).ToString() + " minuto(s).";
                else
                    texto = " ocurrió hace " + Math.Round(-minutosTranscurridos).ToString() + " minuto(s).";
            else
                texto = determinadorDiferenciaTiempoSiguiente.DeterminarDiferenciaTiempo(dt1, dt2);
            return texto;
        }
    }
}
