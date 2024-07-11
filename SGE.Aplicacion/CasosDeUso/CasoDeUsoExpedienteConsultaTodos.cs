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
    }
}
