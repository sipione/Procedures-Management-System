public class CasoDeUsoUsuarioAlta
{
    private readonly IUsuarioRepositorio _repositorioUsuarios;

    public CasoDeUsoUsuarioAlta(IUsuarioRepositorio repositorioUsuarios)
    {
        _repositorioUsuarios = repositorioUsuarios;
    }

    public void Ejecutar(Usuario usuario)
    {
        if (_repositorioUsuarios.ObtenerUsuarioPorEmail(usuario.Email) != null)
            throw new Exception($"El email {usuario.Email} ya se encuentra registrado.");

        _repositorioUsuarios.GuardarUsuario(usuario);
    }
}