public class CasoDeUsoUsuarioLogin(
    IUsuarioRepositorio _repositorioUsuarios,
    IServicioAutenticacion _servicioAutenticacion
)
{
    public Usuario Ejecutar(string email, string password)
    {
        Usuario? usuario = _repositorioUsuarios.ObtenerUsuarioPorEmail(email);
        
        if (usuario == null){
            throw new Exception($"El email {email} no se encuentra registrado o la contraseña es incorrecta.");
        }

        if (!_servicioAutenticacion.VerificarPassword(usuario.Password, password)){
            throw new Exception($"El email {email} no se encuentra registrado o la contraseña es incorrecta.");
        }

        usuario.Password = "";

        return usuario;
    }
}