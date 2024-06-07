using SGE.Aplicacion;

public class CambioEstadoExpedienteService
{
    private readonly IExpedienteRepositorio _expedienteRepositorio;
    private readonly ITramiteRepositorio _tramiteRepositorio;

    public CambioEstadoExpedienteService(IExpedienteRepositorio expedienteRepositorio, ITramiteRepositorio tramiteRepositorio)
    {
        _expedienteRepositorio = expedienteRepositorio;
        _tramiteRepositorio = tramiteRepositorio;
    }

    public void ActualizarEstado(int expedienteId)
    {
        var expediente = _expedienteRepositorio.ObtenerPorId(expedienteId);
        var ultimoTramite = _tramiteRepositorio.ObtenerUltimoTramitePorExpediente(expedienteId);

        if (ultimoTramite == null) return;

        switch (ultimoTramite.Etiqueta)
        {
            case EtiquetaTramite.Resolucion:
                expediente.Estado = EstadoExpediente.ConResolucion;
                break;
            case EtiquetaTramite.PaseAEstudio:
                expediente.Estado = EstadoExpediente.ParaResolver;
                break;
            case EtiquetaTramite.PaseAlArchivo:
                expediente.Estado = EstadoExpediente.Finalizado;
                break;
            default:
                return;
        }

        _expedienteRepositorio.Actualizar(expediente);
    }
}
