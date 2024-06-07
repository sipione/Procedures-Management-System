public interface ITramiteRepositorio
{
    Tramite ObtenerPorId(int id);
    void Crear(Tramite tramite);
    void Actualizar(Tramite tramite);
    void Eliminar(int id);
    IEnumerable<Tramite> ObtenerPorExpediente(int expedienteId);
    Tramite ObtenerUltimoTramitePorExpediente(int expedienteId);
    IEnumerable<Tramite> ObtenerPorEtiqueta(EtiquetaTramite etiquetaTramite);
}
