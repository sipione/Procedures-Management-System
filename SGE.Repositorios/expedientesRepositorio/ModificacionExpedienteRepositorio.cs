using System.Text.Json;
using SGE.Aplicacion;
using SGE.Aplicacion.Entidades;

namespace SGE.Repositorios;

public class ModificacionExpedienteRepositorio
{
    private static string GetFilePath()
    {
        return "../SGE.Repositorios/expedientesRepositorio/Expedientes.json";
    }

    async public static Task ModificarCaratula(string caratula, int expedienteId, int usuarioId)
    {
        Expediente? expedienteRegistrado = ConsultaExpediente.ConsultarPorId(expedienteId) ?? throw GeneralExcepcion.NotFoundExcepcion("Expediente no encontrado");


        try{
            Expediente expedienteModificado = CasoDeUsoExpedienteModificacion.ModificarCaratula(expedienteRegistrado, caratula, usuarioId);
            await AtualizarExpediente(expedienteModificado, GetFilePath());

        }catch(Exception){
            throw;
        }
    }

    async public static Task ModificarEstado(EstadoExpediente estado, int expedienteId, int usuarioId)
    {
        Expediente? expedienteRegistrado = ConsultaExpediente.ConsultarPorId(expedienteId) ?? throw GeneralExcepcion.NotFoundExcepcion("Expediente no encontrado");

        try{
            Expediente expedienteModificado = CasoDeUsoExpedienteModificacion.ModificacionEstado(expedienteRegistrado, estado, usuarioId);
            await AtualizarExpediente(expedienteModificado, GetFilePath());

        }catch(Exception){
            throw;
        }
    }
    async public static Task ModificarEstado(EtiquetaTramite etiqueta, int expedienteId, int usuarioId)
    {
        Expediente? expedienteRegistrado = ConsultaExpediente.ConsultarPorId(expedienteId) ?? throw GeneralExcepcion.NotFoundExcepcion("Expediente no encontrado");

        try{
            Expediente expedienteModificado = CasoDeUsoExpedienteModificacion.ModificacionEstado(expedienteRegistrado, etiqueta, usuarioId);
            await AtualizarExpediente(expedienteRegistrado, GetFilePath());

        }catch(Exception){
            throw;
        }
    }

    async public static Task AtualizarExpediente(Expediente expediente, string filePath)
    {
        List<Expediente> expedientes = ConsultaExpediente.ConsultarTodos();
        expedientes.RemoveAll(e => e.Id == expediente.Id);
        expedientes.Add(expediente);
        expedientes.Sort((e1, e2) => e1.Id.CompareTo(e2.Id));

        string json = JsonSerializer.Serialize(expedientes, new JsonSerializerOptions { WriteIndented = true });
        await File.WriteAllTextAsync(filePath, json);
    }
}
