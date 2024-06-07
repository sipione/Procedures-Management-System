public interface IExpedienteRepositorio
{
    Expediente ObtenerPorId(int id);
    void Crear(Expediente expediente);
    void Actualizar(Expediente expediente);
    void Eliminar(int id);
    IEnumerable<Expediente> Listar();
}
