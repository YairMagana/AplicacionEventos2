using System;

namespace AplicacionEventos2.Clases.Procesador.Responsabilidades
{
    public interface IDeterminadorDiferenciaTiempo
    {
        string DeterminarDiferenciaTiempo(DateTime dt1, DateTime dt2);
    }
}
