namespace SGE.Aplicacion.CasosDeUso
{
    public class CasoDeUsoTramiteModificacion
    {
        private readonly ITramiteRepositorio _tramiteRepositorio;
        private readonly IServicioAutorizacion _servicioAutorizacion;
        private readonly IExpedienteRepositorio _expedienteRepositorio;
        private readonly TramiteValidador _tramiteValidador;

        public CasoDeUsoTramiteModificacion(ITramiteRepositorio tramiteRepositorio, IServicioAutorizacion servicioAutorizacion, IExpedienteRepositorio expedienteRepositorio, TramiteValidador tramiteValidador)
        {
            _tramiteRepositorio = tramiteRepositorio;
            _servicioAutorizacion = servicioAutorizacion;
            _expedienteRepositorio = expedienteRepositorio;
            _tramiteValidador = tramiteValidador;
        }

        public void Ejecutar(Tramite tramite, int usuarioId)
        {
            if (!_servicioAutorizacion.PoseeElPermiso(usuarioId, Permiso.TramiteModificacion))
            {
                throw new UnauthorizedAccessException("El usuario no tiene permiso para modificar tramites.");
            }

            tramite.FechaUltimaModificacion = DateTime.Now;
            tramite.UsuarioUltimaModificacionId = usuarioId;

            _tramiteValidador.Validar(tramite);
            _tramiteRepositorio.Actualizar(tramite);

            CambioEstadoExpedienteService cambioEstadoExpedienteService = new CambioEstadoExpedienteService(_expedienteRepositorio, _tramiteRepositorio);
            cambioEstadoExpedienteService.ActualizarEstado(tramite.ExpedienteId);
        }
    }
}
