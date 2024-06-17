public interface IUsuarioRepositorio
{
    Usuario? ObtenerUsuarioPorId(int id);
    Usuario? ObtenerUsuarioPorEmail(string email);
    List<Usuario> ObtenerTodosLosUsuarios();
    void GuardarUsuario(Usuario usuario);
    void ActualizarUsuario(Usuario usuario);
    void EliminarUsuario(Usuario usuario);
    bool IsEmpty();
}