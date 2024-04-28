using System.ComponentModel;

internal enum EstadoExpediente
{
    [Description("Recién Iniciado")]
    RecienIniciado,
    
    [Description("Para Resolver")]
    ParaResolver,
    
    [Description("Con Resolución")]
    ConResolucion,
    
    [Description("En Notificación")]
    EnNotificacion,
    
    [Description("Finalizado")]
    Finalizado
}