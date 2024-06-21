public class CasoDeUsoUsuarioLogin
{
    private readonly IUsuarioRepositorio _repositorioUsuarios;
    private readonly IServicioAutenticacion _servicioAutenticacion;

    public CasoDeUsoUsuarioLogin(IUsuarioRepositorio repositorioUsuarios, IServicioAutenticacion servicioAutenticacion)
    {
        _repositorioUsuarios = repositorioUsuarios;
        _servicioAutenticacion = servicioAutenticacion;
    }

    public Usuario Ejecutar(string email, string password)
    {
        Usuario usuario = _repositorioUsuarios.ObtenerUsuarioPorEmail(email);
        
        if (usuario == null){
            throw new Exception($"El email {email} no se encuentra registrado o la contraseña es incorrecta.");
        }

        if (!_servicioAutenticacion.VerificarPassword(usuario.Password, password)){
            throw new Exception($"El email {email} no se encuentra registrado o la contraseña es incorrecta.");
        }

        return usuario;
    }
}