public class CasoDeUsoUsuarioAlta
{
    private readonly IUsuarioRepositorio _repositorioUsuarios;
    private readonly IServicioAutenticacion _servicioAutenticacion;
    private readonly IServicioAutorizacion _servicioAutorizacion;

    public CasoDeUsoUsuarioAlta(IUsuarioRepositorio repositorioUsuarios, IServicioAutenticacion servicioAutenticacion, IServicioAutorizacion servicioAutorizacion)
    {
        _repositorioUsuarios = repositorioUsuarios;
        _servicioAutenticacion = servicioAutenticacion;
        _servicioAutorizacion = servicioAutorizacion;
    }

    public void Ejecutar(Usuario usuario)
    {
        if (_repositorioUsuarios.ObtenerUsuarioPorEmail(usuario.Email) != null)
            throw new Exception($"El email {usuario.Email} ya se encuentra registrado.");

        if(_repositorioUsuarios.IsEmpty()){
            usuario.Permisos = _servicioAutorizacion.AdminitradorPermisos();
        }else{
            usuario.Permisos = new List<Permiso>();
        }

        usuario.Password = _servicioAutenticacion.EncriptarPassword(usuario.Password);

        _repositorioUsuarios.GuardarUsuario(usuario);
    }
}