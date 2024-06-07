namespace SGE.Aplicacion.CasosDeUso
{
    public class CasoDeUsoExpedienteConsultaPorld
    {
        private readonly IExpedienteRepositorio _expedienteRepositorio;

        public CasoDeUsoExpedienteConsultaPorld(IExpedienteRepositorio expedienteRepositorio)
        {
            _expedienteRepositorio = expedienteRepositorio;
        }

        public Expediente Ejecutar(int expedienteId)
        {
            return _expedienteRepositorio.ObtenerPorId(expedienteId);
        }
    }
}
