using System.Text.Json;
using SGE.Aplicacion;
using SGE.Aplicacion.Entidades;

namespace SGE.Repositorios;

public class BajaExpedienteRepositorio
{
    private static string GetFilePath()
    {
        return "../SGE.Repositorios/expedientesRepositorio/Expedientes.json";
    }
    private static JsonSerializerOptions GetOptions()
    {
        return new JsonSerializerOptions { WriteIndented = true, PropertyNameCaseInsensitive = true };
    }
    public static async Task DeleteExpediente(int id, int UsuarioId)
    {
        List<Expediente> expedientes = ConsultaExpediente.GetAllExpedientesFromTheFile(GetFilePath());

        try
        {
            expedientes = CasoDeUsoExpedienteBaja.DeleteExpediente(id, expedientes, UsuarioId);
            //save expedientes to file
            await SaveExpedientes(expedientes);
            Console.WriteLine("Expediente eliminado con exito.");
        }
        catch (Exception)
        {
            throw;
        }

        try{
            await BajaTramiteRepositorio.DeleteTramitesByExpedienteId(id, UsuarioId);
        }
        catch (Exception)
        {
            throw;
        }
    }

    private static async Task SaveExpedientes(List<Expediente> expedientes)
    {
        string filePath = GetFilePath();
        if (!File.Exists(filePath))
        {
            File.Create(filePath).Dispose();
        }
        try
        {
            string jsonString = JsonSerializer.Serialize(expedientes, GetOptions());
            await File.WriteAllTextAsync(filePath, jsonString);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al guardar expediente: {ex.Message}");
            throw new Exception(ex.Message);
        }
    }
}
