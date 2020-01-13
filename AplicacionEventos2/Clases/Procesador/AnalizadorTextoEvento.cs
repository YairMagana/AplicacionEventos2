using AplicacionEventos2.Clases.Procesador.Responsabilidades;
using AplicacionEventos2.Clases.Procesador.Utilidades;
using System;

namespace AplicacionEventos2.Clases.Procesador
{
    public class AnalizadorTextoEvento : IAnalizadorTextoEvento
    {
        private readonly IDivisorLinea divisorLinea;
        private readonly IValidadorCamposCVS validadorCamposCVS;
        private readonly IDeterminadorDiferenciaTiempo determinadorDiferenciaTiempo;

        public AnalizadorTextoEvento(IDivisorLinea _divisorLinea, IValidadorCamposCVS _validadorCamposCVS, IDeterminadorDiferenciaTiempo _determinadorDiferenciaTiempo)
        {
            divisorLinea = _divisorLinea;
            validadorCamposCVS = _validadorCamposCVS;
            determinadorDiferenciaTiempo = _determinadorDiferenciaTiempo;
        }

        public string AnalizarTextoEvento(string evento)
        {
            string nombreEvento = string.Empty;
            string texto = "-- Evento Inválido --";
            DateTime fechaEvento, fechaReferencia = DateTime.Now;

            string[] campos = divisorLinea.DividirLinea(evento);

            if (validadorCamposCVS.ValidarCamposCVS(campos))
            {
                nombreEvento = campos[0];
                fechaEvento = ObtenerFecha(campos[1]);
                texto = $"El evento {nombreEvento},{determinadorDiferenciaTiempo.DeterminarDiferenciaTiempo(fechaEvento, fechaReferencia)}";
            }
            return texto;
        }

        private DateTime ObtenerFecha(string fecha)
        {
            DateTime dt;
            DateTime.TryParse(fecha, out dt);
            return dt;
        }

    }
}
