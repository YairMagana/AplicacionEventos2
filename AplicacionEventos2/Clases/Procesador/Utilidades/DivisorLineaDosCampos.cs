using System;

namespace AplicacionEventos2.Clases.Procesador.Utilidades
{
    public class DivisorLineaDosCampos : IDivisorLinea
    {
        public string[] DividirLinea(string _texto)
        {
            string[] v = new string[2];
            if (!string.IsNullOrEmpty(_texto))
            {
                string[] campos = _texto.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                if (campos.Length >= 2)
                {
                    v[0] = campos[0].Trim();
                    v[1] = campos[1].Trim();
                }

                if (campos.Length == 1)
                {
                    v[0] = campos[0];
                }
            }
            return v;
        }
    }
}
