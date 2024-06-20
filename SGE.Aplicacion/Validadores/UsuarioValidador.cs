public class UsuarioValidador
{
    public void Validar(Usuario usuario, bool primeroUsuario)
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

        if(!primeroUsuario && usuario.Permisos != null && usuario.Permisos.Count > 0){
            throw new ValidacionException("Los demás usuario no pueden tener permisos.");
        }

        if(primeroUsuario && (usuario.Permisos == null || usuario.Permisos.Count == 0)){
            throw new ValidacionException("El primer usuario debe tener permisos.");
        }
    }         
}