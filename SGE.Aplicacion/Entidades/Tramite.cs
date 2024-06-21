public class Tramite
{
    public int Id { get; set; }
    public int ExpedienteId { get; set; }
    public EtiquetaTramite Etiqueta { get; set; }
    public string Contenido { get; set; }
    public DateTime FechaCreacion { get; set; }
    public DateTime FechaUltimaModificacion { get; set; }
    public int UsuarioUltimaModificacionId { get; set; }

    public Tramite()
    {
        Etiqueta = EtiquetaTramite.EscritoPresentado;
        Contenido = "";
        FechaCreacion = DateTime.Now;
        FechaUltimaModificacion = DateTime.Now;
        UsuarioUltimaModificacionId = 0;
    }

    public override string ToString() =>
        $"Tramite(Id: {Id}, ExpedienteId: {ExpedienteId}, Etiqueta: {Etiqueta}, FechaCreacion: {FechaCreacion}, FechaUltimaModificacion: {FechaUltimaModificacion})";

    public Tramite Clone()
    {
        return new Tramite{
            Id = this.Id,
            ExpedienteId = this.ExpedienteId,
            Etiqueta = this.Etiqueta,
            Contenido = this.Contenido,
            FechaCreacion = this.FechaCreacion,
            FechaUltimaModificacion = this.FechaUltimaModificacion,
            UsuarioUltimaModificacionId = this.UsuarioUltimaModificacionId
        };
    }
}
