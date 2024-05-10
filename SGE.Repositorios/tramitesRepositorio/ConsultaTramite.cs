using System.Text.Json;
using SGE.Aplicacion.Entidades;

public class ConsultaTramite{
    private static string GetFilePath(){
        return "../SGE.Repositorios/tramitesRepositorio/Tramites.json";
    }
    public static Tramite? ConsultarPorId(int id){
        List<Tramite> tramites = GetAllTramitesFromFile(GetFilePath());
        return CasoDeUsoTramiteConsultaPorId.ConsultarPorId(tramites, id);
    }

    public static List<Tramite>? ConsultarPorExpediente(int idExpediente){
        List<Tramite> tramites = GetAllTramitesFromFile(GetFilePath());
        return CasoDeUsoTramiteConsultaPorExpediente.ConsultarPorExpediente(tramites, idExpediente);
    }

    public static List<Tramite>? ConsultaTodosTramites(){
        List<Tramite> tramites = GetAllTramitesFromFile(GetFilePath());
        return CasoDeUsoTramiteConsultaTodos.ConsultaTodosTramites(tramites);
    }

    private static List<Tramite> GetAllTramitesFromFile(string filePath){
        if(File.Exists(filePath)){
            string json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<Tramite>>(json) ?? new List<Tramite>();
        }
        return new List<Tramite>();
    }
}