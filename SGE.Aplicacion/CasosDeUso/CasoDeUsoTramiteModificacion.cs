namespace SGE.Aplicacion.CasosDeUso
{
    public class CasoDeUsoTramiteModificacion(
        ITramiteRepositorio _tramiteRepositorio,
        IServicioAutorizacion _servicioAutorizacion,
        IExpedienteRepositorio _expedienteRepositorio,
        TramiteValidador _tramiteValidador
    )
    {
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

            CambioEstadoExpedienteService.ActualizarEstado(tramite.ExpedienteId, _expedienteRepositorio, _tramiteRepositorio);
        }

        public OperationResult Ejecutar(Tramite tramite, int usuarioId, bool toApi)
        {
            try
            {
                Ejecutar(tramite, usuarioId);
                return OperationResult.Ok("Tramite modificado con exito");
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
