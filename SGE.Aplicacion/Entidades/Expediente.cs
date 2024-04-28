using System;
namespace SGE.Aplicacion.Entidades;

public class Expediente
{
    public int Id { get; set; }
    public string Caratula { get; set; }
    private DateTime FechaCreacion { get; set; }
    private DateTime FechaModificacion { get; set; }
    private int UsuarioModificacionId { get; set; }
    private EstadoExpediente Estado { get; set; }
}
