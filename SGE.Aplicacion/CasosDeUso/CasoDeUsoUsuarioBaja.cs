namespace SGE.Aplicacion.CasosDeUso;

public class CasoDeUsoUsuarioBaja(
    IUsuarioRepositorio _repositorioUsuarios
)
{
    public void Ejecutar(int idUsuarioParaBajar, int idUsuarioQueBaja)
    {
        Usuario? usuarioQueBaja = _repositorioUsuarios.ObtenerUsuarioPorId(idUsuarioQueBaja) ?? throw new Exception($"Error 404. El usuario con id {idUsuarioQueBaja} no fue encontrado.");

        if (!usuarioQueBaja.Permisos.Contains(Permiso.UsuarioBaja))
            throw new Exception($"Error 403. El usuario con id {idUsuarioQueBaja} no tiene permisos para dar de baja a otros usuarios.");
        
        Usuario? usuarioParaBajar = _repositorioUsuarios.ObtenerUsuarioPorId(idUsuarioParaBajar) ?? throw new Exception($"Error 404. El usuario con id {idUsuarioParaBajar} no fue encontrado.");

        _repositorioUsuarios.EliminarUsuario(usuarioParaBajar);
    }

    public OperationResult Ejecutar(int idUsuarioParaBajar, int idUsuarioQueBaja, bool toApi)
    {
        try
        {
            Ejecutar(idUsuarioParaBajar, idUsuarioQueBaja);
            return OperationResult.Ok("Usuario dado de baja con exito");
        }
        catch (Exception ex)
        {
            return OperationResult.BadRequest(ex.Message);
        }
    }
}