namespace SGE.Aplicacion.CasosDeUso;

public class CasoDeUsoUsuarioConsultaTodos(
    IUsuarioRepositorio _repositorioUsuarios,
    IServicioAutorizacion _servicioAutorizacion
)
{
    public List<Usuario> Ejecutar()
    {
        return _repositorioUsuarios.ObtenerTodosLosUsuarios();
    }

    public OperationResult Ejecutar(int usuarioId, bool toApi)
    {
        try
        {
            if (!_servicioAutorizacion.PoseeElPermiso(usuarioId, Permiso.UsuarioConsulta))
            {
                return OperationResult.Unauthorized("El usuario no tiene permiso para consultar usuarios.");
            }
            var usuarios = Ejecutar();
            return OperationResult.Ok(usuarios);
        }
        catch (Exception ex)
        {
            return OperationResult.InternalServerError(ex.Message);
        }
    }
}