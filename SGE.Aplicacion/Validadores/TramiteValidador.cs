public class TramiteValidador
{
    public void Validar(Tramite tramite)
    {
        if (string.IsNullOrWhiteSpace(tramite.Contenido))
            throw new ValidacionException("El contenido del trámite no puede estar vacío.");

        if (tramite.UsuarioUltimaModificacionId <= 0)
            throw new ValidacionException("El id del usuario debe ser válido.");
    }
}
