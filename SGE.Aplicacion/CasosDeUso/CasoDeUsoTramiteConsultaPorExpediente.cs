namespace SGE.Aplicacion.CasosDeUso
{
    public class CasoDeUsoTramiteConsultaPorExpediente
    {
        private readonly ITramiteRepositorio _tramiteRepositorio;

        public CasoDeUsoTramiteConsultaPorExpediente(ITramiteRepositorio tramiteRepositorio)
        {
            _tramiteRepositorio = tramiteRepositorio;
        }

        public IEnumerable<Tramite> Ejecutar(int expedienteId)
        {
            return _tramiteRepositorio.ObtenerPorExpediente(expedienteId);
        }
    }
}