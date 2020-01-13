using AplicacionEventos2.Clases.Archivos;
using AplicacionEventos2.Clases.Argumentos;
using AplicacionEventos2.Clases.Desplegadores;
using AplicacionEventos2.Clases.Procesador;
using AplicacionEventos2.Clases.Procesador.Responsabilidades;
using AplicacionEventos2.Clases.Procesador.Utilidades;
using System;

namespace AplicacionEventos2
{
    class Program
    {
        static void Main(string[] args)
        {
            string texto;
            try
            {
                /*** SERVICIOS ***/
                // * Argumento
                IObtenedorTextoArgumentos obtenedorTextoPrimerArgumento = new ObtenedorTextoPrimerArgumento(args);
                // Archivo
                IValidadorArchivo validadorArchivo = new ValidarArchivoTexto();
                ILectorArchivoTexto lectorArchivoTexto = new LectorArchivoTexto(obtenedorTextoPrimerArgumento.ObtenerTextoArgumentos(), validadorArchivo);
                IObtenedorRegistrosArchivoListaStrings obtenedorContenidoArchivoListaStrings = new ObtenedorRegistrosArchivoListaStrings(lectorArchivoTexto);

                // * Procesamiento
                IDivisorLinea divisorLinea = new DivisorLineaDosCampos();
                IValidadorCamposCVS validadorCamposCVS = new ValidadorCamposEventos();
                //   Cadena de comparaciones
                IDeterminadorDiferenciaTiempo determinadorDiferenciaMes = new DeterminadorDiferenciaMes(null);
                IDeterminadorDiferenciaTiempo determinadorDiferenciaDia = new DeterminadorDiferenciaDia(determinadorDiferenciaMes);
                IDeterminadorDiferenciaTiempo determinadorDiferenciaHora = new DeterminadorDiferenciaHora(determinadorDiferenciaDia);
                IDeterminadorDiferenciaTiempo determinadorDiferenciaMinuto = new DeterminadorDiferenciaMinuto(determinadorDiferenciaHora);
                IAnalizadorTextoEvento analizadorEvento = new AnalizadorTextoEvento(divisorLinea, validadorCamposCVS, determinadorDiferenciaMinuto);
                IPresentadorEventos presentadorEventos = new PresentadorEventos(obtenedorContenidoArchivoListaStrings.ObtenerRegistrosArchivo(), analizadorEvento);
                texto = presentadorEventos.PresentarEventos();
            }
            catch (Exception ex)
            {
                texto = $"Ha ocurrido un error: {ex.Message}";
            }
            //// Capa de presentación
            IDesplegador desplegador = new DesplegadorPantalla();
            desplegador.Desplegar(texto);
        }
    }
}
