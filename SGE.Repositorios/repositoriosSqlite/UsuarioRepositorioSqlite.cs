public class UsuarioRepositorioSqlite : IUsuarioRepositorio
{
    private readonly SGEContexto _contexto;

    public UsuarioRepositorioSqlite(SGEContexto contexto)
    {
        _contexto = contexto;
    }

    public Usuario? ObtenerUsuarioPorEmail(string email)
    {
        return _contexto.Usuarios.FirstOrDefault(u => u.Email == email);
    }

    public Usuario? ObtenerUsuarioPorId(int id)
    {
        return _contexto.Usuarios.FirstOrDefault(u => u.Id == id);
    }

    public void GuardarUsuario(Usuario usuario)
    {
        _contexto.Usuarios.Add(usuario);
        _contexto.SaveChanges();
    }

    public void ActualizarUsuario(Usuario usuario)
    {
        _contexto.Usuarios.Update(usuario);
        _contexto.SaveChanges();
    }

    public void EliminarUsuario(Usuario usuario)
    {
        _contexto.Usuarios.Remove(usuario);
        _contexto.SaveChanges();
    }

    public List<Usuario> ObtenerTodosLosUsuarios()
    {
        return _contexto.Usuarios.ToList();
    }

    public bool IsEmpty()
    {
        return !_contexto.Usuarios.Any();
    }
}
