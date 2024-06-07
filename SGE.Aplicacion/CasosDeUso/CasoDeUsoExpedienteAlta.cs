namespace SGE.Aplicacion.CasosDeUso
{
    public class CasoDeUsoExpedienteAlta
    {
        private readonly IExpedienteRepositorio _expedienteRepositorio;
        private readonly IServicioAutorizacion _servicioAutorizacion;

        public CasoDeUsoExpedienteAlta(IExpedienteRepositorio expedienteRepositorio, IServicioAutorizacion servicioAutorizacion)
        {
            _expedienteRepositorio = expedienteRepositorio;
            _servicioAutorizacion = servicioAutorizacion;
        }

        public void Ejecutar(Expediente expediente, int usuarioId)
        {
            if (!_servicioAutorizacion.PoseeElPermiso(usuarioId, Permiso.ExpedienteAlta))
            {
                throw new UnauthorizedAccessException("El usuario no tiene permiso para crear expedientes.");
            }

            _expedienteRepositorio.Crear(expediente);
        }
    }
}
