using Microsoft.EntityFrameworkCore;

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
        var existingEntity = _contexto.Usuarios.Local.FirstOrDefault(e => e.Id == usuario.Id);
        if (existingEntity != null)
        {
            existingEntity.Nombre = usuario.Nombre;
            existingEntity.Apellido = usuario.Apellido;
            existingEntity.Email = usuario.Email;
            existingEntity.Password = usuario.Password;
            existingEntity.Permisos = new List<Permiso>(usuario.Permisos);
            _contexto.SaveChanges();
        }
        else
        {
            throw new Exception("El usuario no existe");
        }
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
