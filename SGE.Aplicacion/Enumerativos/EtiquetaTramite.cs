using System.ComponentModel;

public enum EtiquetaTramite
{
    [Description("Escrito Presentado")]
    EscritoPresentado,
    
    [Description("Pase a Estudio")]
    PaseAEstudio,
    
    [Description("Despacho")]
    Despacho,
    
    [Description("Resolución")]
    Resolucion,
    
    [Description("Notificación")]
    Notificacion,
    
    [Description("Pase al Archivo")]
    PaseAlArchivo
}