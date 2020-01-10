using AplicacionEventos2.Controladores;
using AplicacionEventos2.Controladores.Interfaces;
using AplicacionEventos2.Servicios;
using AplicacionEventos2.Servicios.Interfaces;
using System;

namespace AplicacionEventos2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Servicios
            IObtenedorArgumentos obtenedorArgumentos = new ObtenedorArgumentos(args);
            ILectorArchivo lectorArchivos = new LectorArchivo(obtenedorArgumentos);

            // Capa de procesamiento
            ObtenedorTextoTiempos mostradorContenidoEventos = new ObtenedorTextoTiempos(obtenedorArgumentos, lectorArchivos);
            mostradorContenidoEventos.ObtenerContenidoFormateadoArchivos();

            // Capa de salida
            IDesplegador desplegador = new DesplegadorPantalla();
            desplegador.Desplegar(mostradorContenidoEventos.Texto);
        }
    }
}
