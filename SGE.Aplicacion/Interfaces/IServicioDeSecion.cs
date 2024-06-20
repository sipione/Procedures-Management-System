public interface IServicioDeSecion
{
    void registrarSesion(Usuario usuario);
    void cerrarSesion(Usuario usuario);
    Usuario? obtenerUsuarioRegistrado();
    EstadoUsuario obtenerEstadoUsuario();
}