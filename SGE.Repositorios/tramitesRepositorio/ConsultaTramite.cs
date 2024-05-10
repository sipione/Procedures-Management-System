using System.Text.Json;
using SGE.Aplicacion.Entidades;

public class ConsultaTramite{
    public static Tramite? ConsultarPorId(int id){
        List<Tramite> tramites = GetAllTramitesFromFile("Tramites.json");
        return CasoDeUsoTramiteConsultaPorId.ConsultarPorId(tramites, id);
    }

    public static List<Tramite>? ConsultarPorExpediente(int idExpediente){
        List<Tramite> tramites = GetAllTramitesFromFile("Tramites.json");
        return CasoDeUsoTramiteConsultaPorExpediente.ConsultarPorExpediente(tramites, idExpediente);
    }

    private static List<Tramite> GetAllTramitesFromFile(string filePath){
        if(File.Exists(filePath)){
            string json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<Tramite>>(json);
        }
        return new List<Tramite>();
    }
}