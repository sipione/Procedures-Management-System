using System;
namespace SGE.Aplicacion.Entidades;

public class Expediente{
    public int Id { get; }
    public string Caratula { get; set; }
    public DateTime FechaCreacion { get; }
    public DateTime FechaModificacion { get; set; }
    public int UsuarioModificacionId { get; set; }
    public EstadoExpediente Estado { get; set; }

    public Expediente(string caratula, int usuarioId, int id)
    {
        this.Caratula = caratula;
        this.UsuarioModificacionId = usuarioId;
        this.Id = id;
        this.FechaCreacion = DateTime.Now;
        this.FechaModificacion = DateTime.Now;
        this.Estado = EstadoExpediente.RecienIniciado;
    }

    public void SetCaratula(string caratula, int usuarioId)
    {
        this.Caratula = caratula;
        this.UsuarioModificacionId = usuarioId;
        this.FechaModificacion = DateTime.Now;
    }
}
