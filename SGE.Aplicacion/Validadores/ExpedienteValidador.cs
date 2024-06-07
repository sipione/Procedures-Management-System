

public class ExpedienteValidador
{
    public void Validar(Expediente expediente)
    {
        if (string.IsNullOrWhiteSpace(expediente.Caratula))
            throw new ValidacionException("La carátula del expediente no puede estar vacía.");

        if (expediente.UsuarioUltimaModificacionId <= 0)
            throw new ValidacionException("El id del usuario debe ser válido.");
    }
}
