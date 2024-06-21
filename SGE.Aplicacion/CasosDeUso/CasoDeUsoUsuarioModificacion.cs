public class CasoDeUsoUsuarioModificacion
{
    private readonly IUsuarioRepositorio _repositorioUsuarios;
    private readonly UsuarioValidador _usuarioValidador;
    private readonly IServicioAutenticacion _servicioAutenticacion;

    public CasoDeUsoUsuarioModificacion(IUsuarioRepositorio repositorioUsuarios, UsuarioValidador usuarioValidador, IServicioAutenticacion servicioAutenticacion)
    {
        _repositorioUsuarios = repositorioUsuarios;
        _usuarioValidador = usuarioValidador;
        _servicioAutenticacion = servicioAutenticacion;
    }

    public void Ejecutar(Usuario usuario, int idUsuarioQueModifica)
    {        
        PrepararNuevoUsuario(usuario, idUsuarioQueModifica);


        _usuarioValidador.Validar(usuario);

        Console.WriteLine("usuario prepado: " + usuario);
        _repositorioUsuarios.ActualizarUsuario(usuario);
    }

    private Usuario PrepararNuevoUsuario(Usuario usuario, int idUsuarioQueModifica)
    {
        Usuario? usuarioQueModifica = _repositorioUsuarios.ObtenerUsuarioPorId(idUsuarioQueModifica);

        if(usuarioQueModifica == null){
            throw new Exception($"Error 404. El usuario con id {idUsuarioQueModifica} no fue encontrado.");
        }

        if (idUsuarioQueModifica != usuario.Id && !usuarioQueModifica.Permisos.Contains(Permiso.UsuarioModificacion)){
            throw new Exception($"Error 403. El usuario con id {idUsuarioQueModifica} no tiene permisos para modificar a otros usuarios.");
        }
        
        Usuario? usuarioAModificar = _repositorioUsuarios.ObtenerUsuarioPorId(usuario.Id);
        if(usuarioAModificar == null){
            throw new Exception($"Error 404. El usuario con id {usuario.Id} no fue encontrado.");
        }

        if(idUsuarioQueModifica == usuarioAModificar.Id){
            usuario.Permisos = usuarioAModificar.Permisos;
        }

        Console.WriteLine("usuarioAModificar: " + usuarioAModificar);
        Console.WriteLine("usuario: " + usuario);
        
        if(string.IsNullOrEmpty(usuario.Password)){
            usuario.Password = usuarioAModificar.Password;
        }else{
            usuario.Password = _servicioAutenticacion.EncriptarPassword(usuario.Password);
        }

        return usuario;
    }
}