namespace SGE.Aplicacion.CasosDeUso
{
    public class CasoDeUsoExpedienteAlta(
        IExpedienteRepositorio _expedienteRepositorio,
        IServicioAutorizacion _servicioAutorizacion,
        ExpedienteValidador _expedienteValidador
    )
    {
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
