using System.IO;
using System.Text.Json;
using SGE.Aplicacion;
using SGE.Aplicacion.Entidades;
namespace SGE.Repositorios;

public class AltaTramiteRepositorio
{
    private static JsonSerializerOptions GetOptions()
    {
        return new JsonSerializerOptions { WriteIndented = true };
    }
    public static async Task CrearTramite(int IdExpediente, string Contenido, int UsuarioId)
    {
        try
        {
            Expediente? expediente = ConsultaExpediente.ConsultarPorId(IdExpediente) ?? throw GeneralExcepcion.NotFoundExcepcion("Expediente no encontrado.");
            string filePath = "../SGE.Repositorios/tramitesRepositorio/Tramites.json"; // Specify the file path where you want to save the object
            List<Tramite> tramites = getAllTramitesFromTheFile(filePath);
            int Id = GenerateTramiteId(tramites);
            Tramite tramite = CasoDeUsoTramiteAlta.CrearTramite(IdExpediente, Contenido, UsuarioId, Id);
            await GuardarTramite(tramite, filePath, tramites);
            
            await ModificacionExpedienteRepositorio.ModificarEstado(tramite.Etiqueta, IdExpediente, UsuarioId);
        }
        catch (Exception)
        {
            throw;
        }
    }

    private static List<Tramite> getAllTramitesFromTheFile(string filePath)
    {
        List<Tramite> tramites = new();
        if (File.Exists(filePath))
        {

            string json = File.ReadAllText(filePath);
            try
            {
                tramites = JsonSerializer.Deserialize<List<Tramite>>(json)!;
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"Error deserializing JSON: {ex.Message}");
                throw new Exception(ex.Message);
            }
        }
        return tramites;
    }

    private static int GenerateTramiteId(List<Tramite> tramites)
    {
        int id = 1;
        if (tramites.Count > 0)
        {
            id = tramites.Max(tramite => tramite.Id) + 1;
        }
        return id;
    }

    private static Task<int> GuardarTramite(Tramite tramite, string filePath, List<Tramite> tramites)
    {
        tramites.Add(tramite);

        if (!File.Exists(filePath))
        {
            File.Create(filePath).Dispose();
        }

        try
        {
            string jsonString = JsonSerializer.Serialize(tramites, GetOptions());
            File.WriteAllText(filePath, jsonString);
            return Task.FromResult(tramite.Id);
        }
        catch (JsonException ex)
        {
            Console.WriteLine($"Error serializing JSON: {ex.Message}");
            throw new Exception(ex.Message);
        }
    }
}
