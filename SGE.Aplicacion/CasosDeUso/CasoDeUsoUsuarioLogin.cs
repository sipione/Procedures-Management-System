public class CasoDeUsoUsuarioLogin
{
    private readonly IUsuarioRepositorio _repositorioUsuarios;
    private readonly IServicioCriptografiaPassword _servicioCriptografia;

    public CasoDeUsoUsuarioLogin(IUsuarioRepositorio repositorioUsuarios, IServicioCriptografiaPassword servicioCriptografia)
    {
        _repositorioUsuarios = repositorioUsuarios;
        _servicioCriptografia = servicioCriptografia;
    }

    public Usuario Ejecutar(string email, string password)
    {
        var usuario = _repositorioUsuarios.ObtenerUsuarioPorEmail(email) ?? throw new Exception($"El email {email} no se encuentra registrado o la contraseña es incorrecta.");

        if (!_servicioCriptografia.VerificarPassword(password, usuario.Password)) 
            throw new Exception($"El email {email} no se encuentra registrado o la contraseña es incorrecta.");
        
        return usuario;
    }
}