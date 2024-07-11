namespace SGE.Aplicacion.CasosDeUso
{
    public class CasoDeUsoTramiteConsultaPorEtiqueta(
        ITramiteRepositorio _tramiteRepositorio
    )
    {
        public IEnumerable<Tramite> Ejecutar(EtiquetaTramite etiquetaTramite)
        {
            return _tramiteRepositorio.ObtenerPorEtiqueta(etiquetaTramite);
        }
    }
}
