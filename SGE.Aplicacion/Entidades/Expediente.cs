public class Expediente
{
    public int Id { get; set; }
    public string Caratula { get; set; }
    public DateTime FechaCreacion { get; set; }
    public DateTime FechaUltimaModificacion { get; set; }
    public int UsuarioUltimaModificacionId { get; set; }
    public EstadoExpediente Estado { get; set; }
    public List<Tramite> Tramites { get; set; }

    public override string ToString() =>
        $"Expediente(Id: {Id}, Caratula: {Caratula}, Estado: {Estado}, FechaCreacion: {FechaCreacion}, FechaUltimaModificacion: {FechaUltimaModificacion})";
}
