public class Expediente
{
    public int Id { get; set; }
    public string Caratula { get; set; }
    public DateTime FechaCreacion { get; set; }
    public DateTime FechaUltimaModificacion { get; set; }
    public int UsuarioUltimaModificacionId { get; set; }
    public EstadoExpediente Estado { get; set; }
    public List<Tramite> Tramites { get; set; }

    public Expediente()
    {
        Caratula = "";
        FechaCreacion = DateTime.Now;
        FechaUltimaModificacion = DateTime.Now;
        UsuarioUltimaModificacionId = 0;
        Estado = EstadoExpediente.RecienIniciado;
        Tramites = new List<Tramite>();
    }

    public override string ToString() =>
        $"Expediente(Id: {Id}, Caratula: {Caratula}, Estado: {Estado}, FechaCreacion: {FechaCreacion}, FechaUltimaModificacion: {FechaUltimaModificacion})";

    public Expediente Clone()
    {
        return new Expediente
        {
            Id = this.Id,
            Caratula = this.Caratula,
            FechaCreacion = this.FechaCreacion,
            FechaUltimaModificacion = this.FechaUltimaModificacion,
            UsuarioUltimaModificacionId = this.UsuarioUltimaModificacionId,
            Estado = this.Estado,
            Tramites = new List<Tramite>(this.Tramites)
        };
    }
}
