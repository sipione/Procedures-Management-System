public class CasoDeUsoUsuarioConsultaTodos(
    IUsuarioRepositorio _repositorioUsuarios
)
{
    public List<Usuario> Ejecutar()
    {
        return _repositorioUsuarios.ObtenerTodosLosUsuarios();
    }
}