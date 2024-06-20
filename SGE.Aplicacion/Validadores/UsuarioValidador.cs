public class UsuarioValidador
{
    public void Validar(Usuario usuario)
    {
        if (string.IsNullOrWhiteSpace(usuario.Nombre)){
            throw new ValidacionException("El nombre del usuario no puede estar vacío.");
        }

        if (string.IsNullOrWhiteSpace(usuario.Apellido)){
            throw new ValidacionException("El apellido del usuario no puede estar vacío.");
        }

        if (string.IsNullOrWhiteSpace(usuario.Email)){
            throw new ValidacionException("El email del usuario no puede estar vacío.");
        }

        if (string.IsNullOrWhiteSpace(usuario.Password)){
            throw new ValidacionException("La contraseña del usuario no puede estar vacía.");
        }
    }         
}