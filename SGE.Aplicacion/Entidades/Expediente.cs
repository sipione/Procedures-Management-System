using System;
namespace SGE.Aplicacion.Entidades;

internal class Expediente{
    public int Id { get; }
    public string Caratula { get; set; }
    private DateTime FechaCreacion { get; }
    private DateTime FechaModificacion { get; set;}
    private int UsuarioModificacionId { get; set;}
    private EstadoExpediente Estado { get; set; }

    internal Expediente(string caratula, int usuarioId, int id)
    {
        this.Id = id;
        this.Caratula = caratula;
        this.FechaCreacion = DateTime.Now;
        this.FechaModificacion = DateTime.Now;
        this.UsuarioModificacionId = usuarioId;
        this.Estado = EstadoExpediente.RecienIniciado;
    }

    internal void setCaratula(string caratula, int usuarioId)
    {
        this.Caratula = caratula;
        this.FechaModificacion = DateTime.Now;
        this.UsuarioModificacionId = usuarioId;
    }
}
