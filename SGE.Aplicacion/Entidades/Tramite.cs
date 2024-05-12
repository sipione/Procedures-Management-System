using System;
namespace SGE.Aplicacion.Entidades;

public class Tramite
{
    public int Id { get; set; }
    public int IdExpediente { get; set; }
    public EtiquetaTramite Etiqueta { get; set; }
    public string Contenido { get; set; }
    public DateTime FechaCreacion { get; set; }
    public DateTime FechaModificacion { get; set; }
    public int UsuarioModificacionId { get; set; }

    public Tramite(int idExpediente, string contenido, int usuarioId, int id)
    {
        this.Id = id;
        this.IdExpediente = idExpediente;
        this.Etiqueta = EtiquetaTramite.EscritoPresentado;
        this.Contenido = contenido;
        this.FechaCreacion = DateTime.Now;
        this.FechaModificacion = DateTime.Now;
        this.UsuarioModificacionId = usuarioId;
    }

    public Tramite(){}

    public void SetContenido(string contenido, int usuarioId){
        this.Contenido = contenido;
        this.UsuarioModificacionId = usuarioId;
        this.FechaModificacion = DateTime.Now;
    }

    public void SetEtiqueta(EtiquetaTramite etiqueta, int usuarioId)
    {
        this.Etiqueta = etiqueta;
        this.UsuarioModificacionId = usuarioId;
        this.FechaModificacion = DateTime.Now;
    }
}
