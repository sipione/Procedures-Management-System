using SGE.Aplicacion.Entidades;

namespace SGE.Aplicacion;

public class CasoDeUsoTramiteModificacion
{
    public static Tramite ModificarContenido(Tramite tramiteRegistrado, string contenido, int usuarioId)
    {
        ServicioAutorizacionProvisorio servicioAutorizacionProvisorio = new ServicioAutorizacionProvisorio();
        bool autorizado = servicioAutorizacionProvisorio.PoseeElPermiso(usuarioId, Permiso.TramiteModificacion);
        if (!autorizado)
        {
            throw AutorizacionExcepcion.NotAuthorizedException("No posee permisos para modificar el tramite");
        }

        Tramite tramiteModificado = tramiteRegistrado;
        tramiteModificado.Contenido = contenido;
        tramiteModificado.UsuarioModificacionId = usuarioId;
        tramiteModificado.FechaModificacion = DateTime.Now;
        bool esValido = TramiteValidador.Validar(tramiteModificado);
        if (!esValido)
        {
            throw ValidacionExcepcion.TramiteNotValid("El contenido no puede ser vacio");
        }

        return tramiteModificado;
    }

    public static Tramite ModificarEtiqueta(Tramite tramiteRegistrado, EtiquetaTramite etiqueta, int usuarioId)
    {
        ServicioAutorizacionProvisorio servicioAutorizacionProvisorio = new ServicioAutorizacionProvisorio();
        bool autorizado = servicioAutorizacionProvisorio.PoseeElPermiso(usuarioId, Permiso.TramiteModificacion);
        if (!autorizado)
        {
            throw AutorizacionExcepcion.NotAuthorizedException("No posee permisos para modificar el tramite");
        }

        Tramite tramiteModificado = tramiteRegistrado;
        tramiteModificado.Etiqueta = etiqueta;
        tramiteModificado.UsuarioModificacionId = usuarioId;
        tramiteModificado.FechaModificacion = DateTime.Now;
        bool esValido = TramiteValidador.Validar(tramiteModificado);
        if (!esValido)
        {
            throw ValidacionExcepcion.TramiteNotValid("La etiqueta no puede ser nula");
        }

        return tramiteModificado;
    }
}
