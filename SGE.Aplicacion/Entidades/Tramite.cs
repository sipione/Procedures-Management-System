public class Tramite
{
    public int Id { get; set; }
    public int ExpedienteId { get; set; }
    public EtiquetaTramite Etiqueta { get; set; }
    public string Contenido { get; set; }
    public DateTime FechaCreacion { get; set; }
    public DateTime FechaUltimaModificacion { get; set; }
    public int UsuarioUltimaModificacionId { get; set; }

    public override string ToString() =>
        $"Tramite(Id: {Id}, ExpedienteId: {ExpedienteId}, Etiqueta: {Etiqueta}, FechaCreacion: {FechaCreacion}, FechaUltimaModificacion: {FechaUltimaModificacion})";
}
