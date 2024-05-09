using SGE.Aplicacion.Entidades;

namespace SGE.Aplicacion;

public class CasoDeUsoTramiteAlta
{
    public static Tramite CrearTramite(int idExpediente, string contenido, int usuarioId, int id)
    {
        ServicioAutorizacionProvisorio servicioAutorizacionProvisorio = new();
        bool isAuthorized = servicioAutorizacionProvisorio.PoseeElPermiso(usuarioId, Permiso.TramiteAlta);
        if (!isAuthorized)
        {
            throw AutorizacionExcepcion.NotAuthorizedException($"El usuário de id {usuarioId} no posee el permiso para crear un tramite.");
        }

        Tramite nuevotramite = new(idExpediente, contenido, usuarioId, id);
        bool isValid = TramiteValidador.Validar(nuevotramite);
        if (!isValid)
        {
            throw ValidacionExcepcion.AltaTramiteNotValid("Verifique los campos ingresados.");
        }

        return nuevotramite;
    }
}
