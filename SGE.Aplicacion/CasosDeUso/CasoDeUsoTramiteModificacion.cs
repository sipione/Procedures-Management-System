namespace SGE.Aplicacion.CasosDeUso
{
    public class CasoDeUsoTramiteModificacion
    {
        private readonly ITramiteRepositorio _tramiteRepositorio;
        private readonly IServicioAutorizacion _servicioAutorizacion;
        private readonly IExpedienteRepositorio _expedienteRepositorio;

        public CasoDeUsoTramiteModificacion(ITramiteRepositorio tramiteRepositorio, IServicioAutorizacion servicioAutorizacion, IExpedienteRepositorio expedienteRepositorio)
        {
            _tramiteRepositorio = tramiteRepositorio;
            _servicioAutorizacion = servicioAutorizacion;
            _expedienteRepositorio = expedienteRepositorio;
        }

        public void Ejecutar(Tramite tramite, int usuarioId)
        {
            if (!_servicioAutorizacion.PoseeElPermiso(usuarioId, Permiso.TramiteModificacion))
            {
                throw new UnauthorizedAccessException("El usuario no tiene permiso para modificar tramites.");
            }

            _tramiteRepositorio.Actualizar(tramite);

            CambioEstadoExpedienteService cambioEstadoExpedienteService = new CambioEstadoExpedienteService(_expedienteRepositorio, _tramiteRepositorio);
            cambioEstadoExpedienteService.ActualizarEstado(tramite.ExpedienteId);
        }
    }
}
