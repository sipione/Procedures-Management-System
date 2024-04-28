using System;
namespace SGE.Aplicacion.Entidades;

internal class Expediente
{
    private int Id { get; set; }
    private string Caratula { get; set; }
    private DateTime FechaCreacion { get; set; }
    private DateTime FechaModificacion { get; set; }
    private int UsuarioModificacionId { get; set; }
    private EstadoExpediente Estado { get; set; }
}
