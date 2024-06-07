namespace SGE.Aplicacion.CasosDeUso
{
    public class CasoDeUsoTramiteConsultaPorEtiqueta
    {
        private readonly ITramiteRepositorio _tramiteRepositorio;

        public CasoDeUsoTramiteConsultaPorEtiqueta(ITramiteRepositorio tramiteRepositorio)
        {
            _tramiteRepositorio = tramiteRepositorio;
        }

        public IEnumerable<Tramite> Ejecutar(EtiquetaTramite etiquetaTramite)
        {
            return _tramiteRepositorio.ObtenerPorEtiqueta(etiquetaTramite);
        }
    }
}
