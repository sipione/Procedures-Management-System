public class CasoDeUsoUsuarioConsultaTodos
{
    private readonly IUsuarioRepositorio _repositorioUsuarios;

    public CasoDeUsoUsuarioConsultaTodos(IUsuarioRepositorio repositorioUsuarios)
    {
        _repositorioUsuarios = repositorioUsuarios;
    }

    public List<Usuario> Ejecutar()
    {
        return _repositorioUsuarios.ObtenerTodosLosUsuarios();
    }
}