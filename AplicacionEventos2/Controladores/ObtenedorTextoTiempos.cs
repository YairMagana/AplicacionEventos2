using AplicacionEventos2.Controladores.Interfaces;
using AplicacionEventos2.Servicios;
using AplicacionEventos2.Servicios.Comparadores;
using AplicacionEventos2.Servicios.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AplicacionEventos2.Controladores
{
    class ObtenedorTextoTiempos : IObtenedorContenidoArchivo
    {
        IObtenedorArgumentos obtenedorArgumentos;
        ILectorArchivo lectorArchivos;

        private string texto;

        public string Texto { get => texto; set => texto = value; }

        public ObtenedorTextoTiempos(IObtenedorArgumentos _obtenedorArgumentos, ILectorArchivo _lectorArchivos)
        {
            obtenedorArgumentos = _obtenedorArgumentos;
            lectorArchivos = _lectorArchivos;
        }

        public void ObtenerContenidoFormateadoArchivos()
        {
            // Servicios que solo le importan al caso del Lector de Eventos
            IParseadorLinea parseadorLinea = new ParseadorLinea();
            IValidadorColumnas validadorColumnas = new ValidadorDosColumnas();

            List<IComparadorTiempo> lstComparadores = new List<IComparadorTiempo>();
            IComparadorTiempo comparadorMes = new ComparadorMes();
            IComparadorTiempo comparadorDia = new ComparadorDia();
            IComparadorTiempo comparadorHora = new ComparadorHora();
            IComparadorTiempo comparadorMinuto = new ComparadorMinuto();

            lstComparadores.Add(comparadorMes);
            lstComparadores.Add(comparadorDia);
            lstComparadores.Add(comparadorHora);
            lstComparadores.Add(comparadorMinuto);

            IRealizadorComparaciones realizadorComparaciones = new RealizadorComparaciones(lstComparadores);
            IGeneradorTextos generadorTextos = new GeneradorTextoEventos(validadorColumnas, realizadorComparaciones);

            ILectorLineas lectorLineas = new LectorLineas(lectorArchivos, parseadorLinea, generadorTextos);
            texto = lectorLineas.ObtenerTextos();
        }

    }
}
