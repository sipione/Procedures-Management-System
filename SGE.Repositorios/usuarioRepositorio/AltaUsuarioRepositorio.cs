using System.Text.Json;
using SGE.Aplicacion;
namespace SGE.Repositorios;
using System.IO;


public class AltaUsuarioRepositorio
{
    private static JsonSerializerOptions GetOptions()
    {
        return new JsonSerializerOptions { WriteIndented = true };
    }
    public async Task<string> CrearUsuario(string Nombre, string Apellido, string Email, string Password, string Rol)
    {
        string filePath = "../SGE.Repositorios/usuarioRepositorio/Usuarios.json";
        try
        {
            List<Usuario> usuarios = getAllUsersFromTheFile(filePath);
            int Id = GenerarUsuarioId(usuarios);
            Usuario usuario = CasoDeUsoUsuarioAlta.CrearNuevoUsuario(Nombre, Apellido, Email, Password, Rol, Id);
            await GuardarUsuario(usuario, filePath, usuarios, GetOptions());
            return "Usuario creado con éxito";
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al crear usuario: {ex.Message}");
            return $"Error al crear usuario: {ex.Message}";
        }
    }

    private static List<Usuario> getAllUsersFromTheFile(string filePath)
    {
        List<Usuario> usuarios = new();
        if (File.Exists(filePath))
        {

            string json = File.ReadAllText(filePath);
            try
            {
                // Deserialize JSON string into 'Usuario' object
                usuarios = JsonSerializer.Deserialize<List<Usuario>>(json)!;
            }
            catch (JsonException ex)
            {
                // Handle JSON deserialization error
                Console.WriteLine($"Error deserializing JSON: {ex.Message}");
                throw new Exception(ex.Message);
            }
        }
        return usuarios;
    }

    private static Task GuardarUsuario(Usuario usuario, string filePath, List<Usuario> usuarios, JsonSerializerOptions options)
    {
        usuarios.Add(usuario);

        if(!File.Exists(filePath))
        {
            File.Create(filePath).Dispose();
        }

        try
        {
            string json = JsonSerializer.Serialize(usuarios, options);
            File.WriteAllText(filePath, json);
            return Task.CompletedTask;
        }
        catch (JsonException ex)
        {
            // Handle JSON serialization error
            Console.WriteLine($"Error serializing JSON: {ex.Message}");
            throw new Exception(ex.Message);;
        }
    }

    private static int GenerarUsuarioId(List<Usuario> usuarios)
    {
        int id = 1;
        if (usuarios.Count > 0)
        {
            id = usuarios.Max(usuario => usuario.Id) + 1;
        }
        return id;
    }

}
