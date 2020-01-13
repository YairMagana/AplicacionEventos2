using System;

namespace AplicacionEventos2.Clases.Procesador.Utilidades
{
    public class ValidadorCamposEventos : IValidadorCamposCVS
    {
        string[] campos;

        public bool ValidarCamposCVS(string[] _campos)
        {
            campos = _campos;
            return (campos != null &&
                ValidarDosCampos() &&
                !ValidarCamposVacios() &&
                EsFechaValida());
        }

        // Validaciones Específicas
        private bool ValidarDosCampos()
        {
            return campos.Length == 2;
        }

        private bool ValidarCamposVacios()
        {
            return (string.IsNullOrEmpty(campos[0]) || string.IsNullOrEmpty(campos[1]));
        }

        private bool EsFechaValida()
        {
            return DateTime.TryParse(campos[1], out _);
        }
    }
}
