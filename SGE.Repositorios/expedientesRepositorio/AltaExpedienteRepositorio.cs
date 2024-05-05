namespace SGE.Repositorios;
using SGE.Aplicacion;
using SGE.Aplicacion.Entidades;
using System;
using System.IO;
using System.Text.Json;



public class AltaExpedienteRepositorio{
    private static JsonSerializerOptions GetOptions()
    {
        return new JsonSerializerOptions { WriteIndented = true, PropertyNameCaseInsensitive = true };
    }
    public async Task<string> CrearExpediente(string Caratula, int UsuarioId)
    {
        try{
            string filePath = "../SGE.Repositorios/expedientesRepositorio/Expedientes.json"; // Specify the file path where you want to save the object
            List<Expediente> expedientes = GetAllExpedientesFromTheFile(filePath);
            int Id = GenerateExpedienteId(expedientes);
            Expediente expediente = CasoDeUsoExpedienteAlta.CrearNuevoExpediente(Caratula, UsuarioId, Id);
            
            await GuardarExpediente(expediente, filePath, expedientes);
            return "Expediente creado con éxito";
        }catch(Exception ex){
            Console.WriteLine($"Error al crear expediente: {ex.Message}");
            return $"No fue posible crear el Expediente. Error: {ex.Message}";
        }
    }
    private static List<Expediente> GetAllExpedientesFromTheFile(string filePath)
    {
        List<Expediente> expedientes = new();
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            try
            {
                // Deserialize JSON string into 'Expediente' object
                expedientes = JsonSerializer.Deserialize<List<Expediente>>(json, GetOptions());
            }
            catch (JsonException ex)
            {
                // Handle JSON deserialization error
                Console.WriteLine($"Error deserializing JSON: {ex.Message}");
                throw new Exception(ex.Message);
            }
        }
        return expedientes;
    }
    private static int GenerateExpedienteId(List<Expediente> expedientes)
    {
        int id = 1;
        if (expedientes.Count > 0)
        {
            id = expedientes.Max(expediente => expediente.Id) + 1;
        }
        return id;
    }
    async private static Task<Task> GuardarExpediente(Expediente expediente, string filePath, List<Expediente> expedientes)
    {
        expedientes.Add(expediente);

        if(!File.Exists(filePath))
        {
            File.Create(filePath).Dispose();
        }
        try{
            string jsonString = JsonSerializer.Serialize(expedientes, GetOptions());
            await File.WriteAllTextAsync(filePath, jsonString);
            return Task.CompletedTask;

        }catch(Exception ex){
            Console.WriteLine($"Error al guardar expediente: {ex.Message}");
            throw new Exception(ex.Message);
        }
    }
}
