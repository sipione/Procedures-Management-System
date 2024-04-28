using System.Runtime.CompilerServices;
using SGE.Aplicacion.Entidades;
namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteAlta
{
    public Expediente expediente;

    public CasoDeUsoExpedienteAlta(Expediente expediente){
        this.expediente = expediente;
    }

    public void CrearNuevoExpediente(string usuario){
        bool isAuthorized = ServicioAutorizacionProvisorio.VerifyAuthorization(usuario, Permiso.ExpedienteAlta);
        if(!isAuthorized) throw AutorizacionExcepcion.NotAuthorizedException("Usuario no autorizado");

        bool isValid = ExpedienteValidador.IsValidExpedienteCreation(this.expediente);
        if(!isValid) throw ValidacionExcepcion.AltaExpedienteNotValid("Fields do not match with the validation requirements.");
    } 
}
