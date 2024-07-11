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
    }
}