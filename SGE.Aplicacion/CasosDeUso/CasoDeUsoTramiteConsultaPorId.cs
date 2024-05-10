using SGE.Aplicacion.Entidades;

public class CasoDeUsoTramiteConsultaPorId{
    public static Tramite? ConsultarPorId(List<Tramite> tramites, int id){
        return tramites.Find(tramite => tramite.Id == id);
    }
}