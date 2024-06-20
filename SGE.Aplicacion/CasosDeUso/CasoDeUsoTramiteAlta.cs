namespace SGE.Aplicacion.CasosDeUso
{
    public class CasoDeUsoTramiteAlta
    {
        private readonly ITramiteRepositorio _tramiteRepositorio;
        private readonly IServicioAutorizacion _servicioAutorizacion;
        private readonly IExpedienteRepositorio _expedienteRepositorio;
        private readonly TramiteValidador _tramiteValidador;

        public CasoDeUsoTramiteAlta(ITramiteRepositorio tramiteRepositorio, IServicioAutorizacion servicioAutorizacion, IExpedienteRepositorio expedienteRepositorio, TramiteValidador tramiteValidador)
        {
            _tramiteRepositorio = tramiteRepositorio;
            _servicioAutorizacion = servicioAutorizacion;
            _expedienteRepositorio = expedienteRepositorio;
            _tramiteValidador = tramiteValidador;
        }

        public void Ejecutar(Tramite tramite, int usuarioId)
        {
            if (!_servicioAutorizacion.PoseeElPermiso(usuarioId, Permiso.TramiteAlta))
            {
                throw new UnauthorizedAccessException("El usuario no tiene permiso para crear tramites.");
            }

            var expediente = _expedienteRepositorio.ObtenerPorId(tramite.ExpedienteId);
            if (expediente == null)
            {
                throw new Exception("El expediente no existe");
            }

            tramite.FechaCreacion = DateTime.Now;
            tramite.FechaUltimaModificacion = DateTime.Now;
            tramite.UsuarioUltimaModificacionId = usuarioId;
            tramite.Etiqueta = EtiquetaTramite.EscritoPresentado;

            _tramiteValidador.Validar(tramite);
            _tramiteRepositorio.Crear(tramite);
        }
    }
}
