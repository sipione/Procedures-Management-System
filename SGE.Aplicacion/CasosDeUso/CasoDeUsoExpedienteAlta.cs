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
            bool autorizado;
            try{
                autorizado = _servicioAutorizacion.PoseeElPermiso(usuarioId, Permiso.ExpedienteAlta);
            }
            catch (Exception)
            {
                throw;
            }
            
            if (!autorizado)
            {
                throw new UnauthorizedAccessException("El usuario no tiene permiso para crear expedientes.");
            }

            expediente.FechaCreacion = DateTime.Now;
            expediente.FechaUltimaModificacion = DateTime.Now;
            expediente.UsuarioUltimaModificacionId = usuarioId;
            expediente.Estado = EstadoExpediente.RecienIniciado;

            _expedienteRepositorio.Crear(expediente);
        }
    }
}
