public class ServicioDeSecionInterna : IServicioDeSecion
{
    private Usuario? usuarioRegistrado;
    private EstadoUsuario estadoUsuario;

    public ServicioDeSecionInterna()
    {
        estadoUsuario = EstadoUsuario.Desconectado;
    }

    public void registrarSesion(Usuario usuario)
    {
        if (estadoUsuario == EstadoUsuario.Conectado)
        {
            throw new Exception("Ya hay una sesión activa.");
        }

        usuarioRegistrado = usuario;
        estadoUsuario = EstadoUsuario.Conectado;
    }

    public void cerrarSesion(Usuario usuario)
    {
        if (estadoUsuario == EstadoUsuario.Desconectado)
        {
            throw new Exception("No hay una sesión activa.");
        }

        if (usuarioRegistrado?.Id != usuario.Id)
        {
            throw new Exception($"Error 404. El usuario con id {usuario.Id} no fue encontrado.");
        }

        usuarioRegistrado = null;
        estadoUsuario = EstadoUsuario.Desconectado;
    }

    public Usuario? obtenerUsuarioRegistrado()
    {
        return this.usuarioRegistrado;
    }

    public EstadoUsuario obtenerEstadoUsuario()
    {
        return this.estadoUsuario;
    }
}