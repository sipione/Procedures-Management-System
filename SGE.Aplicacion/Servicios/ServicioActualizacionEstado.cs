using SGE.Aplicacion.Entidades;
namespace SGE.Aplicacion;

public class ServicioActualizacionEstado
{
    public static void ActualizarEstado(EtiquetaTramite etiqueta, Expediente expediente)
    {
        switch (etiqueta)
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
                break;
        }
    }
}
