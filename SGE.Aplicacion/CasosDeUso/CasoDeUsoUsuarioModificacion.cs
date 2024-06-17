public class CasoDeUsoUsuarioModificacion
{
    private readonly IUsuarioRepositorio _repositorioUsuarios;

    public CasoDeUsoUsuarioModificacion(IUsuarioRepositorio repositorioUsuarios)
    {
        _repositorioUsuarios = repositorioUsuarios;
    }

    public void Ejecutar(Usuario usuario, int idUsuarioQueModifica)
    {
        Usuario? usuarioQueModifica = _repositorioUsuarios.ObtenerUsuarioPorId(idUsuarioQueModifica) ?? throw new Exception($"Error 404. El usuario con id {idUsuarioQueModifica} no fue encontrado.");

        if (!usuarioQueModifica.Permisos.Contains(Permiso.UsuarioModificacion))
            throw new Exception($"Error 403. El usuario con id {idUsuarioQueModifica} no tiene permisos para modificar a otros usuarios.");
        
        Usuario? usuarioAModificar = _repositorioUsuarios.ObtenerUsuarioPorId(usuario.Id) ?? throw new Exception($"Error 404. El usuario con id {usuario.Id} no fue encontrado.");

        if (_repositorioUsuarios.ObtenerUsuarioPorEmail(usuario.Email) != null && usuario.Email != usuarioAModificar.Email)
            throw new Exception($"El email {usuario.Email} ya se encuentra registrado.");

        _repositorioUsuarios.ActualizarUsuario(usuario);
    }
}