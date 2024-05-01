using System.Runtime.CompilerServices;
using SGE.Aplicacion.Entidades;
namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteAlta
{
    internal Expediente CrearNuevoExpediente(string caratula, int usuarioId, int id){

        ServicioAutorizacionProvisorio servicioAutorizacion = new ServicioAutorizacionProvisorio();
        bool isAuthorized = servicioAutorizacion.PoseeElPermiso(usuarioId, Permiso.ExpedienteAlta);
        if(!isAuthorized) throw AutorizacionExcepcion.NotAuthorizedException("Usuario no autorizado");

        Expediente nuevoExpediente = new Expediente(caratula, usuarioId, id);
        bool isValid = ExpedienteValidador.IsValidExpedienteCreation(nuevoExpediente);
        if(!isValid) throw ValidacionExcepcion.AltaExpedienteNotValid("Fields do not match with the validation requirements.");

        return nuevoExpediente;        
    }
}
