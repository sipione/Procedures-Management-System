namespace SGE.Aplicacion.CasosDeUso
{
    public class CasoDeUsoExpedienteModificacion
    {
        private readonly IExpedienteRepositorio _expedienteRepositorio;
        private readonly IServicioAutorizacion _servicioAutorizacion;
        private readonly ExpedienteValidador _expedienteValidador;

        public CasoDeUsoExpedienteModificacion(IExpedienteRepositorio expedienteRepositorio, IServicioAutorizacion servicioAutorizacion, ExpedienteValidador expedienteValidador)
        {
            _expedienteRepositorio = expedienteRepositorio;
            _servicioAutorizacion = servicioAutorizacion;
            _expedienteValidador = expedienteValidador;
        }

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
