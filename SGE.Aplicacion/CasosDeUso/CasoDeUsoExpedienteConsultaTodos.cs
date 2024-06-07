namespace SGE.Aplicacion.CasosDeUso
{
    public class CasoDeUsoExpedienteConsultaTodos
    {
        private readonly IExpedienteRepositorio _expedienteRepositorio;

        public CasoDeUsoExpedienteConsultaTodos(IExpedienteRepositorio expedienteRepositorio)
        {
            _expedienteRepositorio = expedienteRepositorio;
        }

        public IEnumerable<Expediente> Ejecutar()
        {
            return _expedienteRepositorio.Listar();
        }
    }
}
