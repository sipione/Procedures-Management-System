using System;
namespace SGE.Aplicacion.Entidades;

public class Tramite
{
    public int Id { get; set; }
    public string IdExpediente { get; set; }
    public EtiquetaTramite Etiqueta { get; set; }
    public string Contenido { get; set; }
    public DateTime FechaCreacion { get; set; }
    public DateTime FechaModificacion { get; set; }
    public int UsuarioModificacionId { get; set; }
    public string Estado { get; set; }

    public Tramite(string idExpediente, string contenido, int usuarioId, int id)
    {
        this.Id = id;
        this.IdExpediente = idExpediente;
        this.Etiqueta = EtiquetaTramite.EscritoPresentado;
        this.Contenido = contenido;
        this.FechaCreacion = DateTime.Now;
        this.FechaModificacion = DateTime.Now;
        this.UsuarioModificacionId = usuarioId;
        this.Estado = "RecienIniciado";
    }

    public Tramite(){}
}
