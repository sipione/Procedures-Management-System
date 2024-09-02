public class ServicioAutorizacion : IServicioAutorizacion
{
    private readonly IUsuarioRepositorio _repositorioUsuarios;

    public ServicioAutorizacion(IUsuarioRepositorio repositorioUsuarios)
    {
        _repositorioUsuarios = repositorioUsuarios;
    }

    public bool PoseeElPermiso(int idUsuario, Permiso permiso)
    {
        Usuario? usuario = _repositorioUsuarios.ObtenerUsuarioPorId(idUsuario);

        if (usuario == null)
        {
            return false;
        }
        
        return usuario.Permisos.Contains(permiso);
    }

    public List<Permiso> AdminitradorPermisos()
    {
        return new List<Permiso> (){ 
            Permiso.ExpedienteAlta,
            Permiso.ExpedienteBaja,
            Permiso.ExpedienteModificacion,
            Permiso.TramiteAlta,
            Permiso.TramiteBaja,
            Permiso.TramiteModificacion,
            Permiso.UsuarioAlta,
            Permiso.UsuarioBaja,
            Permiso.UsuarioModificacion,
            Permiso.UsuarioConsulta
        };
    }
}