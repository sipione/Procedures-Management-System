using System;
namespace SGE.Aplicacion.Entidades;

public class Expediente{
   public int Id { get; set; }
    public string Caratula { get; set; }
    public DateTime FechaCreacion { get; set; }
    public DateTime FechaModificacion { get; set; }
    public int UsuarioModificacionId { get; set; }
    public EstadoExpediente Estado { get; set; }
    
    //Defualt constructor
    public Expediente(string caratula, int usuarioId, int id)
    {
        this.Caratula = caratula;
        this.UsuarioModificacionId = usuarioId;
        this.Id = id;
        this.FechaCreacion = DateTime.Now;
        this.FechaModificacion = DateTime.Now;
        this.Estado = EstadoExpediente.RecienIniciado;
    }
    
    // Deserialization constructor
    public Expediente(){}

    public void SetCaratula(string caratula, int usuarioId)
    {
        this.Caratula = caratula;
        this.UsuarioModificacionId = usuarioId;
        this.FechaModificacion = DateTime.Now;
    }

    public void SetEstado(EstadoExpediente estado, int usuarioId)
    {
        this.Estado = estado;
        this.UsuarioModificacionId = usuarioId;
        this.FechaModificacion = DateTime.Now;
    }

    public void SetEstado(EtiquetaTramite etiqueta, int usuarioId)
    {
        EstadoExpediente? estado = ServicioActualizacionEstado.EstadoPorEtiqueta(etiqueta);

        if(estado != null){
            this.Estado = (EstadoExpediente)estado;
            this.UsuarioModificacionId = usuarioId;
            this.FechaModificacion = DateTime.Now;
        }
    }
}
