namespace SGE.Aplicacion.CasosDeUso
{
    public class CasoDeUsoTramiteConsultaTodos(
        ITramiteRepositorio _tramiteRepositorio
    )
    {
        public IEnumerable<Tramite> Ejecutar()
        {
            return _tramiteRepositorio.ObtenerTodos();
        }

        public OperationResult Ejecutar(bool toApi)
        {
            try
            {
                var tramites = Ejecutar();
                return OperationResult.Ok(tramites);
            }
            catch (Exception ex)
            {
                return OperationResult.InternalServerError(ex.Message);
            }
        }
    }
}