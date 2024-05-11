using SGE.Aplicacion;

public class CasoDeUsoUsuarioAlta
{
    public static Usuario CrearNuevoUsuario(string nombre, string apellido, string email, string password, string role, int id)
    {
        ServicioAutorizacionProvisorio servicioAutorizacion = new();
        bool isAuthorized = servicioAutorizacion.PoseeElPermiso(1, Permiso.UsuarioAlta);
        if (!isAuthorized) throw AutorizacionExcepcion.NotAuthorizedException("Usuario no autorizado");

        Usuario nuevoUsuario = new(nombre, apellido, email, password, role, id);
        bool isValid = UsuarioValidador.IsValidUsuarioCreation(nuevoUsuario);
        if (!isValid) throw ValidacionExcepcion.AltaUsuarioNotValid("Fields do not match with the validation requirements.");

        return nuevoUsuario;
    }
}