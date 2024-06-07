namespace SGE.Aplicacion.CasosDeUso
{
    public class CasoDeUsoTramiteAlta
    {
        private readonly ITramiteRepositorio _tramiteRepositorio;
        private readonly IServicioAutorizacion _servicioAutorizacion;
        private readonly IExpedienteRepositorio _expedienteRepositorio;

        public CasoDeUsoTramiteAlta(ITramiteRepositorio tramiteRepositorio, IServicioAutorizacion servicioAutorizacion, IExpedienteRepositorio expedienteRepositorio)
        {
            _tramiteRepositorio = tramiteRepositorio;
            _servicioAutorizacion = servicioAutorizacion;
            _expedienteRepositorio = expedienteRepositorio;
        }

        public void Ejecutar(Tramite tramite, int usuarioId)
        {
            if (!_servicioAutorizacion.PoseeElPermiso(usuarioId, Permiso.TramiteAlta))
            {
                throw new UnauthorizedAccessException("El usuario no tiene permiso para crear tramites.");
            }

            //verificar si el expediente existe
            var expediente = _expedienteRepositorio.ObtenerPorId(tramite.ExpedienteId);
            if (expediente == null)
            {
                throw new Exception("El expediente no existe");
            }

            _tramiteRepositorio.Crear(tramite);
        }
    }
}
