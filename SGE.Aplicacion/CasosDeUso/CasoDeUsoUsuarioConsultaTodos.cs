public class CasoDeUsoUsuarioConsultaTodos
{
    private readonly IUsuarioRepositorio _repositorioUsuarios;

    public CasoDeUsoUsuarioConsultaTodos(IUsuarioRepositorio repositorioUsuarios)
    {
        _repositorioUsuarios = repositorioUsuarios;
    }

    public List<Usuario> Ejecutar(int idUsuarioQueConsulta)
    {
        Usuario? usuarioQueConsulta = _repositorioUsuarios.ObtenerUsuarioPorId(idUsuarioQueConsulta) ?? throw new Exception($"Error 404. El usuario con id {idUsuarioQueConsulta} no fue encontrado.");

        if (!usuarioQueConsulta.Permisos.Contains(Permiso.UsuarioConsulta))
            throw new Exception($"Error 403. El usuario con id {idUsuarioQueConsulta} no tiene permisos para consultar usuarios.");

        return _repositorioUsuarios.ObtenerTodosLosUsuarios();
    }
}