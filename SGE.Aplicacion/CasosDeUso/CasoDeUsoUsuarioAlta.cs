public class CasoDeUsoUsuarioAlta
{
    private readonly IUsuarioRepositorio _repositorioUsuarios;
    private readonly IServicioAutenticacion _servicioAutenticacion;
    private readonly IServicioAutorizacion _servicioAutorizacion;
    private readonly UsuarioValidador _usuarioValidador;

    public CasoDeUsoUsuarioAlta(IUsuarioRepositorio repositorioUsuarios, IServicioAutenticacion servicioAutenticacion, IServicioAutorizacion servicioAutorizacion, UsuarioValidador usuarioValidador)
    {
        _repositorioUsuarios = repositorioUsuarios;
        _servicioAutenticacion = servicioAutenticacion;
        _servicioAutorizacion = servicioAutorizacion;
        _usuarioValidador = usuarioValidador;
    }

    public Usuario Ejecutar(Usuario usuario)
    {
        if (_repositorioUsuarios.ObtenerUsuarioPorEmail(usuario.Email) != null)
            throw new Exception($"El email {usuario.Email} ya se encuentra registrado.");

        if(_repositorioUsuarios.IsEmpty()){
            usuario.Permisos = _servicioAutorizacion.AdminitradorPermisos();
        }else{
            usuario.Permisos = new List<Permiso>();
        }

        usuario.Password = _servicioAutenticacion.EncriptarPassword(usuario.Password);

        _usuarioValidador.Validar(usuario);

        _repositorioUsuarios.GuardarUsuario(usuario);

        return usuario;
    }

    public void Ejecutar(Usuario usuario, int idUsuarioCreador)
    {
        if (!_servicioAutorizacion.PoseeElPermiso(idUsuarioCreador, Permiso.UsuarioAlta))
            throw new Exception("No tiene permisos para realizar esta acción.");

        if (_repositorioUsuarios.ObtenerUsuarioPorEmail(usuario.Email) != null)
            throw new Exception($"El email {usuario.Email} ya se encuentra registrado.");

        usuario.Permisos = new List<Permiso>();

        usuario.Password = _servicioAutenticacion.EncriptarPassword(usuario.Password);

        _usuarioValidador.Validar(usuario);

        _repositorioUsuarios.GuardarUsuario(usuario);
    }
}