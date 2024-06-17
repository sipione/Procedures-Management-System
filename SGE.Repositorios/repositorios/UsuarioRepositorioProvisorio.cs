public class UsuarioRepositorioProvisorio : IUsuarioRepositorio
{
    private readonly string _path = "usuarios.csv";

    public Usuario? ObtenerUsuarioPorEmail(string email)
    {
        return ObtenerUsuarios().FirstOrDefault(u => u.Email == email) ?? null;
    }

    public Usuario? ObtenerUsuarioPorId(int id)
    {
        //Get the User by Id troutgh the csv file
        return ObtenerUsuarios().FirstOrDefault(u => u.Id == id) ?? null;
    }

    public void GuardarUsuario(Usuario usuario)
    {
        //Guardar Usuario en un archivo csv
        List<Usuario> usuarios = ObtenerUsuarios();
        usuario.Id = usuarios.Count == 0 ? 1 : usuarios.Max(u => u.Id) + 1;
        usuarios.Add(usuario);
        GuardarUsuarios(usuarios);
    }

    public void ActualizarUsuario(Usuario usuario)
    {
        Usuario? usuarioActual = ObtenerUsuarioPorId(usuario.Id);
        if (usuarioActual == null) throw new Exception("El usuario no existe");

        usuarioActual.Nombre = usuario.Nombre;
        usuarioActual.Apellido = usuario.Apellido;
        usuarioActual.Email = usuario.Email;
        usuarioActual.Password = usuario.Password;
        usuarioActual.Permisos = usuario.Permisos;

        GuardarUsuario(usuarioActual);
    }

    public void EliminarUsuario(Usuario usuario)
    {
        //Eliminar Usuario del archivo csv
        List<Usuario> usuarios = ObtenerUsuarios();
        Usuario? usuarioActual = usuarios.FirstOrDefault(u => u.Id == usuario.Id);
        if (usuarioActual == null) throw new Exception("El usuario no existe");

        usuarios.Remove(usuarioActual);
        GuardarUsuarios(usuarios);
    }

    public List<Usuario> ObtenerTodosLosUsuarios()
    {
        // Obtener todos los usuarios del archivo csv
        return ObtenerUsuarios();
    }

    private List<Usuario> ObtenerUsuarios()
    {
        // Leer archivo csv y devolver lista de usuarios
        var usuarios = new List<Usuario>();
        if (!File.Exists(_path)) return usuarios;

        var lineas = File.ReadAllLines(_path).Skip(1);
        foreach (var linea in lineas)
        {
            var campos = linea.Split(',');
            var usuario = new Usuario
            {
                Id = int.Parse(campos[0]),
                Nombre = campos[1],
                Apellido = campos[2],
                Email = campos[3],
                Password = campos[4],
                Permisos = campos[5].Split(',').Select(p => (Permiso)Enum.Parse(typeof(Permiso), p)).ToList()
            };
            usuarios.Add(usuario);
        }
        return usuarios;
    }

    private void GuardarUsuarios(List<Usuario> usuarios)
    {
        var lineas = new List<string>();
        lineas.Add("Id,Nombre,Apellido,Email,Password");
        foreach (var usuario in usuarios)
        {
            lineas.Add($"{usuario.Id},{usuario.Nombre},{usuario.Apellido},{usuario.Email},{usuario.Password},{string.Join(",", usuario.Permisos)}");
        }
        File.WriteAllLines(_path, lineas);
    }
}