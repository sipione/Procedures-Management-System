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
    }
}
