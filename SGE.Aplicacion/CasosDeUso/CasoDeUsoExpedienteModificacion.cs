namespace SGE.Aplicacion.CasosDeUso
{
    public class CasoDeUsoExpedienteModificacion
    {
        private readonly IExpedienteRepositorio _expedienteRepositorio;
        private readonly IServicioAutorizacion _servicioAutorizacion;

        public CasoDeUsoExpedienteModificacion(IExpedienteRepositorio expedienteRepositorio, IServicioAutorizacion servicioAutorizacion)
        {
            _expedienteRepositorio = expedienteRepositorio;
            _servicioAutorizacion = servicioAutorizacion;
        }

        public void Ejecutar(Expediente expediente, int usuarioId)
        {
            if (!_servicioAutorizacion.PoseeElPermiso(usuarioId, Permiso.ExpedienteModificacion))
            {
                throw new UnauthorizedAccessException("El usuario no tiene permiso para modificar expedientes.");
            }
            _expedienteRepositorio.Actualizar(expediente);
        }
    }
}
