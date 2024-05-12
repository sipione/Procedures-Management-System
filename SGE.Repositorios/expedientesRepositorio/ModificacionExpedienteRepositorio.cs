using System.Text.Json;
using SGE.Aplicacion.Entidades;

namespace SGE.Repositorios;

public class ModificacionExpedienteRepositorio
{
    private static string GetFilePath()
    {
        return "../SGE.Repositorios/expedientesRepositorio/Expedientes.json";
    }

    async public static Task<Task> ModificarCaratula(string caratula, int expedienteId, int usuarioId)
    {
        Expediente? expedienteRegistrado = ConsultaExpediente.ConsultarPorId(expedienteId) ?? throw GeneralExcepcion.NotFoundExcepcion("Expediente no encontrado");

        expedienteRegistrado.SetCaratula(caratula, usuarioId);

        try{
            await AtualizarExpediente(expedienteRegistrado, GetFilePath());
            return Task.CompletedTask;

        }catch(Exception e){
            return Task.FromException(e);
        }
    }

    async public static Task<Task> ModificarEstado(EstadoExpediente estado, int expedienteId, int usuarioId)
    {
        Expediente? expedienteRegistrado = ConsultaExpediente.ConsultarPorId(expedienteId) ?? throw GeneralExcepcion.NotFoundExcepcion("Expediente no encontrado");

        expedienteRegistrado.SetEstado(estado, usuarioId);

        try{
            await AtualizarExpediente(expedienteRegistrado, GetFilePath());
            return Task.CompletedTask;

        }catch(Exception e){
            return Task.FromException(e);
        }
    }

    async private static Task AtualizarExpediente(Expediente expediente, string filePath)
    {
        List<Expediente> expedientes = ConsultaExpediente.ConsultarTodos();
        expedientes.RemoveAll(e => e.Id == expediente.Id);
        expedientes.Add(expediente);
        expedientes.Sort((e1, e2) => e1.Id.CompareTo(e2.Id));

        string json = JsonSerializer.Serialize(expedientes, new JsonSerializerOptions { WriteIndented = true });
        await File.WriteAllTextAsync(filePath, json);
    }
}
