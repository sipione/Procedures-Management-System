public class ServicioAutorizacion : IServicioAutorizacion
{
    private readonly IUsuarioRepositorio _repositorioUsuarios;

    public ServicioAutorizacion(IUsuarioRepositorio repositorioUsuarios)
    {
        _repositorioUsuarios = repositorioUsuarios;
    }

    public bool PoseeElPermiso(int idUsuario, Permiso permiso)
    {
        Usuario? usuario = _repositorioUsuarios.ObtenerUsuarioPorId(idUsuario) ?? throw new Exception($"Error 404. El usuario con id {idUsuario} no fue encontrado.");
        return usuario.Permisos.Contains(permiso);
    }
}