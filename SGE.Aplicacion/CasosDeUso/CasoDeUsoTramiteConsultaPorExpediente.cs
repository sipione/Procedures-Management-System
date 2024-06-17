namespace SGE.Aplicacion.CasosDeUso
{
    public class CasoDeUsoTramiteConsultaPorExpediente
    {
        private readonly ITramiteRepositorio _tramiteRepositorio;
        private readonly int _expedienteId;

        public CasoDeUsoTramiteConsultaPorExpediente(ITramiteRepositorio tramiteRepositorio, int expedienteId)
        {
            _tramiteRepositorio = tramiteRepositorio;
            _expedienteId = expedienteId;
        }

        public IEnumerable<Tramite> Ejecutar()
        {
            return _tramiteRepositorio.ObtenerPorExpediente(_expedienteId);
        }
    }
}