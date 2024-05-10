using System.Text.Json;
using SGE.Aplicacion;
using SGE.Aplicacion.Entidades;

public class ConsultaExpediente
{
    private static JsonSerializerOptions GetOptions()
    {
        return new JsonSerializerOptions { WriteIndented = true, PropertyNameCaseInsensitive = true };
    }
    async public static Task<Expediente?> ConsultarPorId(int id)
    {
        string filePath = "../SGE.Repositorios/expedientesRepositorio/Expedientes.json"; // Specify the file path where you want to save the object
        try{
            List<Expediente> expedientes = GetAllExpedientesFromTheFile(filePath) ?? new List<Expediente>();
            Expediente encontrado = CasoDeUsoExpedienteConsultaPorld.ConsultarPorId(expedientes, id);
            return encontrado;
        }catch(Exception e){
            Console.WriteLine(e.Message);
            return null;
        }
    }
    private static List<Expediente> GetAllExpedientesFromTheFile(string filePath)
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            if (!string.IsNullOrEmpty(json))
            {
                try
                {
                    // Deserialize JSON string into 'Expediente' object
                    List<Expediente>? expedientes = JsonSerializer.Deserialize<List<Expediente>>(json, GetOptions());
                    return expedientes == null ? new List<Expediente>() : expedientes;
                }
                catch (JsonException ex)
                {
                    // Handle JSON deserialization error
                    Console.WriteLine($"Error deserializing JSON: {ex.Message}");
                    throw new Exception(ex.Message);
                }
            }
        }
        return new List<Expediente>();
    }
}