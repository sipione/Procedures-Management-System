namespace SGE.Aplicacion.CasosDeUso
{
    public class CasoDeUsoExpedienteBaja
    {
        private readonly IExpedienteRepositorio _expedienteRepositorio;
        private readonly IServicioAutorizacion _servicioAutorizacion;
        private readonly ITramiteRepositorio _tramiteRepositorio;

        public CasoDeUsoExpedienteBaja(IExpedienteRepositorio expedienteRepositorio, IServicioAutorizacion servicioAutorizacion, ITramiteRepositorio tramiteRepositorio)
        {
            _expedienteRepositorio = expedienteRepositorio;
            _servicioAutorizacion = servicioAutorizacion;
            _tramiteRepositorio = tramiteRepositorio;
        }

        public void Ejecutar(int expedienteId, int usuarioId)
        {
            if (!_servicioAutorizacion.PoseeElPermiso(usuarioId, Permiso.ExpedienteBaja))
            {
                throw new UnauthorizedAccessException("El usuario no tiene permiso para eliminar expedientes.");
            }
            _expedienteRepositorio.Eliminar(expedienteId);

            //Elimina Los tramites asociados al expediente
            var tramites = _tramiteRepositorio.ObtenerPorExpediente(expedienteId);
            foreach (var tramite in tramites)
            {
                _tramiteRepositorio.Eliminar(tramite.Id);
            }
        }
    }
}
