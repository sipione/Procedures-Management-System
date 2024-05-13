using System.Text.Json;
using SGE.Aplicacion.Entidades;

namespace SGE.Repositorios;

public class BajaTramiteRepositorio
{
    private static string GetFilePath()
    {
        return "../SGE.Repositorios/tramitesRepositorio/Tramites.json";
    }

    private static JsonSerializerOptions GetOptions()
    {
        return new JsonSerializerOptions { WriteIndented = true, PropertyNameCaseInsensitive = true };
    }

    public async static Task DeleteTramitesByExpedienteId(int IdExpediente, int UsuarioId){
        List<Tramite>? tramites = ConsultaTramite.ConsultaTodosTramites() ??  throw GeneralExcepcion.NotFoundExcepcion("Tramites no encontrados.");
        
        try
        {
            tramites = CasoDeUsoTramiteBaja.DeleteTramitesByExpedienteId(IdExpediente, tramites, UsuarioId);
            //save tramites to file
            await SaveTramites(tramites, GetFilePath());
            Console.WriteLine("Tramites eliminados con exito.");
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async static Task DeleteTramite(int id, int UsuarioId){
        List<Tramite>? tramites = ConsultaTramite.ConsultaTodosTramites() ??  throw GeneralExcepcion.NotFoundExcepcion("Tramites no encontrados.");
        
        try
        {
            tramites = CasoDeUsoTramiteBaja.DeleteTramite(id, tramites, UsuarioId);
            //save tramites to file
            await SaveTramites(tramites, GetFilePath());
            Console.WriteLine("Tramite eliminado con exito.");
        }
        catch (Exception)
        {
            throw;
        }
    }

    private static async Task SaveTramites(List<Tramite> tramites, string filePath)
    {
        if (!File.Exists(filePath))
        {
            File.Create(filePath).Dispose();
        }
        try
        {
            string jsonString = JsonSerializer.Serialize(tramites, GetOptions());
            await File.WriteAllTextAsync(filePath, jsonString);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al guardar tramites: {ex.Message}");
            throw new Exception(ex.Message);
        }
    }
}
