namespace SGE.Aplicacion.CasosDeUso;

public class CasoDeUsoUsuarioAlta(
    IUsuarioRepositorio _repositorioUsuarios,
    IServicioAutenticacion _servicioAutenticacion,
    IServicioAutorizacion _servicioAutorizacion,
    UsuarioValidador _usuarioValidador
)
{
    public Usuario Ejecutar(Usuario usuario)
    {
        if (_repositorioUsuarios.ObtenerUsuarioPorEmail(usuario.Email) != null){
            throw new Exception($"El email {usuario.Email} ya se encuentra registrado.");
        }

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

    public OperationResult Ejecutar(Usuario usuario, int idUsuarioCreador, bool toApi)
    {
        try
        {
            Ejecutar(usuario, idUsuarioCreador);
            return OperationResult.Created(usuario, "Usuario creado con exito");
        }
        catch (Exception ex)
        {
            return OperationResult.BadRequest(ex.Message);
        }
    }

    public OperationResult Ejecutar(Usuario usuario, bool toApi)
    {
        try
        {
            var usuarioCreado = Ejecutar(usuario);
            return OperationResult.Created(usuarioCreado, "Usuario creado con exito");
        }
        catch (Exception ex)
        {
            return OperationResult.BadRequest(ex.Message);
        }
    }
}