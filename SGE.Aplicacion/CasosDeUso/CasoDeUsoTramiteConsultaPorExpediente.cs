using SGE.Aplicacion.Entidades;

public class CasoDeUsoTramiteConsultaPorExpediente{
    public static List<Tramite>? ConsultarPorExpediente(List<Tramite> tramites, int idExpediente){
        return tramites.FindAll(tramite => tramite.IdExpediente == idExpediente);
    }
}