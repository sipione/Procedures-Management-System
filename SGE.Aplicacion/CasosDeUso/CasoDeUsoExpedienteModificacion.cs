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

        Expediente expedienteModificado = expedienteRegistrado;
        expedienteModificado.Estado = estado;
        expedienteModificado.UsuarioModificacionId = usuarioId;
        expedienteModificado.FechaModificacion = DateTime.Now;
        bool esValido = ExpedienteValidador.IsValidExpedienteCreation(expedienteModificado);
        if (!esValido)
        {
            throw ValidacionExcepcion.ExpedienteNotValid("El estado no puede ser nulo");
        }

        return expedienteModificado;
    }
}
