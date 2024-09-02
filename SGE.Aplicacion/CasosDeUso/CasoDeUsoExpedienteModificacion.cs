namespace SGE.Aplicacion.CasosDeUso
{
    public class CasoDeUsoExpedienteModificacion(
        IExpedienteRepositorio _expedienteRepositorio,
        IServicioAutorizacion _servicioAutorizacion,
        ExpedienteValidador _expedienteValidador
    )
    {
        public void Ejecutar(Expediente expediente, int usuarioId)
        {
            if (!_servicioAutorizacion.PoseeElPermiso(usuarioId, Permiso.ExpedienteModificacion))
            {
                throw new UnauthorizedAccessException("El usuario no tiene permiso para modificar expedientes.");
            }

            expediente.FechaUltimaModificacion = DateTime.Now;
            expediente.UsuarioUltimaModificacionId = usuarioId;

            _expedienteValidador.Validar(expediente);
            _expedienteRepositorio.Actualizar(expediente);
        }

        public OperationResult Ejecutar(Expediente expediente, int usuarioId, bool toApi)
        {
            try
            {
                Ejecutar(expediente, usuarioId);
                return OperationResult.Ok("Expediente modificado con exito");
            }
            catch (UnauthorizedAccessException ex)
            {
                return OperationResult.Unauthorized(ex.Message);
            }
            catch (Exception ex)
            {
                return OperationResult.BadRequest(ex.Message);
            }
        }
    }
}
