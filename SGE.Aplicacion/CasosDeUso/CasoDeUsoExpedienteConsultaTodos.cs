namespace SGE.Aplicacion.CasosDeUso
{
    public class CasoDeUsoExpedienteConsultaTodos(
        IExpedienteRepositorio _expedienteRepositorio
    )
    {
        public IEnumerable<Expediente> Ejecutar()
        {
            return _expedienteRepositorio.Listar();
        }

        public OperationResult Ejecutar(bool toApi)
        {
            try
            {
                var expedientes = Ejecutar();
                return OperationResult.Ok(expedientes);
            }
            catch (Exception ex)
            {
                return OperationResult.InternalServerError(ex.Message);
            }
        }
    }
}
