using SGE.Aplicacion.Entidades;

namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteModificacion
{
    public static Expediente ModificarCaratula(Expediente expedienteRegistrado, string caratula, int usuarioId){

        ServicioAutorizacionProvisorio servicioAutorizacionProvisorio = new ServicioAutorizacionProvisorio();
        bool autorizado = servicioAutorizacionProvisorio.PoseeElPermiso(usuarioId, Permiso.ExpedienteModificacion);
        if (!autorizado)
        {
            throw AutorizacionExcepcion.NotAuthorizedException("No posee permisos para modificar el expediente");
        }
        
        Expediente expedienteModificado = expedienteRegistrado;
        expedienteModificado.SetCaratula(caratula, usuarioId);
        bool esValido = ExpedienteValidador.IsValidExpedienteCreation(expedienteModificado);
        if (!esValido)
        {
            throw ValidacionExcepcion.ExpedienteNotValid("La caratula no puede ser vacia");
        }

        return expedienteModificado;
    }

    public static Expediente ModificacionEstado(Expediente expedienteRegistrado, EstadoExpediente estado, int usuarioId)
    {
        ServicioAutorizacionProvisorio servicioAutorizacionProvisorio = new ServicioAutorizacionProvisorio();
        bool autorizado = servicioAutorizacionProvisorio.PoseeElPermiso(usuarioId, Permiso.ExpedienteModificacion);
        if (!autorizado)
        {
            throw AutorizacionExcepcion.NotAuthorizedException("No posee permisos para modificar el expediente");
        }

        expedienteRegistrado.SetEstado(estado, usuarioId);

        bool esValido = ExpedienteValidador.IsValidExpedienteCreation(expedienteRegistrado);
        if (!esValido)
        {
            throw ValidacionExcepcion.ExpedienteNotValid("El estado no puede ser nulo");
        }

        return expedienteRegistrado;
    }
    public static Expediente ModificacionEstado(Expediente expedienteRegistrado, EtiquetaTramite etiqueta, int usuarioId)
    {
        ServicioAutorizacionProvisorio servicioAutorizacionProvisorio = new ServicioAutorizacionProvisorio();
        bool autorizado = servicioAutorizacionProvisorio.PoseeElPermiso(usuarioId, Permiso.ExpedienteModificacion);
        if (!autorizado)
        {
            throw AutorizacionExcepcion.NotAuthorizedException("No posee permisos para modificar el expediente");
        }

        expedienteRegistrado.SetEstado(etiqueta, usuarioId);
        bool esValido = ExpedienteValidador.IsValidExpedienteCreation(expedienteRegistrado);
        if (!esValido)
        {
            throw ValidacionExcepcion.ExpedienteNotValid("El estado no puede ser nulo");
        }

        return expedienteRegistrado;
    }
}
