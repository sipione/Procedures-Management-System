namespace SGE.Aplicacion.CasosDeUso
{
    public class CasoDeUsoExpedienteAlta
    {
        private readonly IExpedienteRepositorio _expedienteRepositorio;
        private readonly IServicioAutorizacion _servicioAutorizacion;
        private readonly ExpedienteValidador _expedienteValidador;

        public CasoDeUsoExpedienteAlta(IExpedienteRepositorio expedienteRepositorio, IServicioAutorizacion servicioAutorizacion, ExpedienteValidador expedienteValidador)
        {
            _expedienteRepositorio = expedienteRepositorio;
            _servicioAutorizacion = servicioAutorizacion;
            _expedienteValidador = expedienteValidador;
        }

        public void Ejecutar(Expediente expediente, int usuarioId)
        {
            if (!_servicioAutorizacion.PoseeElPermiso(usuarioId, Permiso.ExpedienteAlta))
            {
                throw new UnauthorizedAccessException("El usuario no tiene permiso para crear expedientes.");
            }

            expediente.FechaCreacion = DateTime.Now;
            expediente.FechaUltimaModificacion = DateTime.Now;
            expediente.UsuarioUltimaModificacionId = usuarioId;
            expediente.Estado = EstadoExpediente.RecienIniciado;

            _expedienteValidador.Validar(expediente);

            _expedienteRepositorio.Crear(expediente);
        }
    }
}
