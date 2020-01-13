using System.Collections.Generic;

namespace AplicacionEventos2.Clases.Procesador
{
    public class PresentadorEventos : IPresentadorEventos
    {
        private readonly List<string> lstEventos;
        private readonly IAnalizadorTextoEvento analizadorEvento;

        public PresentadorEventos(List<string> _lstEventos, IAnalizadorTextoEvento _analizadorEvento)
        {
            lstEventos = _lstEventos;
            analizadorEvento = _analizadorEvento;
        }

        public string PresentarEventos()
        {
            string texto = string.Empty;
            if (lstEventos != null)
            {
                foreach (string evento in lstEventos)
                {
                    texto += $"\n{analizadorEvento.AnalizarTextoEvento(evento)}";
                }
            }
            return texto;
        }
    }
}
