using SGE.Aplicacion.Entidades;
namespace SGE.Aplicacion;

public class ServicioActualizacionEstado
{
    public static EstadoExpediente? EstadoPorEtiqueta(EtiquetaTramite etiqueta)
    {
        switch (etiqueta)
        {
            case EtiquetaTramite.Resolucion:
                return EstadoExpediente.ConResolucion;
            case EtiquetaTramite.PaseAEstudio:
                return EstadoExpediente.ParaResolver;
            case EtiquetaTramite.PaseAlArchivo:
                return EstadoExpediente.Finalizado;
            default:
                return null;
        }
    }
}
