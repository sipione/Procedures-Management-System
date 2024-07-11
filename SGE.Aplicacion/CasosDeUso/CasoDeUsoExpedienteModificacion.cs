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
    }
}
