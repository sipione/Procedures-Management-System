namespace SGE.Aplicacion.CasosDeUso
{
    public class CasoDeUsoExpedienteConsultaPorld(
        IExpedienteRepositorio _expedienteRepositorio
    )
    {

        public Expediente Ejecutar(int expedienteId)
        {
            return _expedienteRepositorio.ObtenerPorId(expedienteId);
        }
    }
}
