using SGE.Aplicacion;

public class CambioEstadoExpedienteService
{

    public static void ActualizarEstado(int expedienteId, IExpedienteRepositorio _expedienteRepositorio, ITramiteRepositorio _tramiteRepositorio)
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
