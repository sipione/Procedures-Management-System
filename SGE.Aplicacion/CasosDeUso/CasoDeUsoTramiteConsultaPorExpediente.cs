namespace SGE.Aplicacion.CasosDeUso
{
    public class CasoDeUsoTramiteConsultaPorExpediente(
        ITramiteRepositorio _tramiteRepositorio
    )
    {
        public IEnumerable<Tramite> Ejecutar(int expedienteId)
        {
            return _tramiteRepositorio.ObtenerPorExpediente(expedienteId);
        }
    }
}