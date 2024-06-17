namespace SGE.Aplicacion.CasosDeUso
{
    public class CasoDeUsoTramiteConsultaTodos
    {
        private readonly ITramiteRepositorio _tramiteRepositorio;

        public CasoDeUsoTramiteConsultaTodos(ITramiteRepositorio tramiteRepositorio)
        {
            _tramiteRepositorio = tramiteRepositorio;
        }

        public IEnumerable<Tramite> Ejecutar()
        {
            return _tramiteRepositorio.ObtenerTodos();
        }
    }
}