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
        var usuario = _repositorioUsuarios.ObtenerUsuarioPorEmail(email) ?? throw new Exception($"El email {email} no se encuentra registrado o la contraseña es incorrecta.");

        if (!_servicioAutenticacion.VerificarPassword(password, usuario.Password)) 
            throw new Exception($"El email {email} no se encuentra registrado o la contraseña es incorrecta.");

        return usuario;
    }
}