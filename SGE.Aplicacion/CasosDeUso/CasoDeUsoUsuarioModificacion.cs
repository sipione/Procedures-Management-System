namespace SGE.Aplicacion.CasosDeUso;

public class CasoDeUsoUsuarioModificacion(
    IUsuarioRepositorio _repositorioUsuarios,
    UsuarioValidador _usuarioValidador,
    IServicioAutenticacion _servicioAutenticacion
)
{
    public void Ejecutar(Usuario usuario, int idUsuarioQueModifica)
    {        
        PrepararNuevoUsuario(usuario, idUsuarioQueModifica);

        _usuarioValidador.Validar(usuario);

        Console.WriteLine("usuario prepado: " + usuario);
        _repositorioUsuarios.ActualizarUsuario(usuario);
    }

    private Usuario PrepararNuevoUsuario(Usuario nuevoUsuario, int idUsuarioQueModifica)
    {
        Usuario? usuarioQueModifica = _repositorioUsuarios.ObtenerUsuarioPorId(idUsuarioQueModifica);

        if(usuarioQueModifica == null){
            throw new Exception($"Error 404. El usuario con id {idUsuarioQueModifica} no fue encontrado.");
        }

        if (idUsuarioQueModifica != nuevoUsuario.Id && !usuarioQueModifica.Permisos.Contains(Permiso.UsuarioModificacion)){
            throw new AutorizacionException($"Error 403. El usuario con id {idUsuarioQueModifica} no tiene permisos para modificar a otros usuarios.");
        }
        
        Usuario? usuarioAModificar = _repositorioUsuarios.ObtenerUsuarioPorId(nuevoUsuario.Id);
        if(usuarioAModificar == null){
            throw new Exception($"Error 404. El usuario con id {nuevoUsuario.Id} no fue encontrado.");
        }

        if(idUsuarioQueModifica == usuarioAModificar.Id){
            nuevoUsuario.Permisos = usuarioAModificar.Permisos;
        }

        if(nuevoUsuario.Email != usuarioAModificar.Email){
            Usuario? usuarioConMismoEmail = _repositorioUsuarios.ObtenerUsuarioPorEmail(nuevoUsuario.Email);
            if(usuarioConMismoEmail != null){
                throw new Exception($"Error 409. Ya existe un usuario con el email {nuevoUsuario.Email}.");
            }
        }
        
        if(string.IsNullOrEmpty(nuevoUsuario.Password)){
            nuevoUsuario.Password = usuarioAModificar.Password;
        }else{
            nuevoUsuario.Password = _servicioAutenticacion.EncriptarPassword(nuevoUsuario.Password);
        }

        return nuevoUsuario;
    }

    public OperationResult Ejecutar(Usuario usuario, int idUsuarioQueModifica, bool toApi)
    {
        try
        {
            Ejecutar(usuario, idUsuarioQueModifica);
            return OperationResult.Ok("Usuario modificado con exito");
        }
        catch (Exception ex)
        {
            return OperationResult.BadRequest(ex.Message);
        }
    }
}