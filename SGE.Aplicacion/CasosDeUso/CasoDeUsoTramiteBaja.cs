namespace SGE.Aplicacion.CasosDeUso
{
    public class CasoDeUsoTramiteBaja(
        ITramiteRepositorio _tramiteRepositorio,
        IServicioAutorizacion _servicioAutorizacion
    )
    {
        public void Ejecutar(int tramiteId, int usuarioId)
        {
            if (!_servicioAutorizacion.PoseeElPermiso(usuarioId, Permiso.TramiteBaja))
            {
                throw new UnauthorizedAccessException("El usuario no tiene permiso para eliminar tramites.");
            }
            _tramiteRepositorio.Eliminar(tramiteId);
        }

        public OperationResult Ejecutar(int tramiteId, int usuarioId, bool toApi)
        {
            try
            {
                Ejecutar(tramiteId, usuarioId);
                return OperationResult.Ok("Tramite eliminado con exito");
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
