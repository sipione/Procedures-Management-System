namespace SGE.Aplicacion.CasosDeUso
{
    public class CasoDeUsoTramiteBaja
    {
        private readonly ITramiteRepositorio _tramiteRepositorio;
        private readonly IServicioAutorizacion _servicioAutorizacion;

        public CasoDeUsoTramiteBaja(ITramiteRepositorio tramiteRepositorio, IServicioAutorizacion servicioAutorizacion)
        {
            _tramiteRepositorio = tramiteRepositorio;
            _servicioAutorizacion = servicioAutorizacion;
        }

        public void Ejecutar(int tramiteId, int usuarioId)
        {
            if (!_servicioAutorizacion.PoseeElPermiso(usuarioId, Permiso.TramiteBaja))
            {
                throw new UnauthorizedAccessException("El usuario no tiene permiso para eliminar tramites.");
            }
            _tramiteRepositorio.Eliminar(tramiteId);
        }
    }
}
