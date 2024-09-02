namespace SGE.Aplicacion.CasosDeUso
{
    public class CasoDeUsoExpedienteBaja(
        IExpedienteRepositorio _expedienteRepositorio,
        IServicioAutorizacion _servicioAutorizacion
    )
    {
        public void Ejecutar(int expedienteId, int usuarioId)
        {
            if (!_servicioAutorizacion.PoseeElPermiso(usuarioId, Permiso.ExpedienteBaja))
            {
                throw new UnauthorizedAccessException("El usuario no tiene permiso para eliminar expedientes.");
            }
            _expedienteRepositorio.Eliminar(expedienteId);
        }

        public OperationResult Ejecutar(int expedienteId, int usuarioId, bool toApi)
        {
            try
            {
                Ejecutar(expedienteId, usuarioId);
                return OperationResult.Ok("Expediente eliminado con exito");
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
