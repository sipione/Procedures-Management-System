using System.ComponentModel;
using System.Text.Json;
using SGE.Aplicacion;
using SGE.Aplicacion.Entidades;

namespace SGE.Repositorios;

public class ModificacionTramiteRepositorio
{
    private static string GetFilePath()
    {
        return "../SGE.Repositorios/tramitesRepositorio/Tramites.json";
    }
    async public static Task ModificarContenido(string contenido, int tramiteId, int usuarioId)
    {
        Tramite? tramiteRegistrado = ConsultaTramite.ConsultarPorId(tramiteId) ?? throw GeneralExcepcion.NotFoundExcepcion("Tramite no encontrado");

        try{
            Tramite tramiteModificado = CasoDeUsoTramiteModificacion.ModificarContenido(tramiteRegistrado, contenido, usuarioId);
            await AtualizarTramite(tramiteModificado, GetFilePath());
        }catch(Exception){
            throw;
        }
    }

    async public static Task ModificarEtiqueta(EtiquetaTramite etiqueta, int tramiteId, int usuarioId)
    {
        Tramite? tramiteRegistrado = ConsultaTramite.ConsultarPorId(tramiteId) ?? throw GeneralExcepcion.NotFoundExcepcion("Tramite no encontrado");

        try{
            tramiteRegistrado = CasoDeUsoTramiteModificacion.ModificarEtiqueta(tramiteRegistrado, etiqueta, usuarioId);
            await AtualizarTramite(tramiteRegistrado, GetFilePath());
        }catch(Exception){
            throw;
        }

        if(EsUltimoTramite(tramiteRegistrado)){
            try{
                await ModificacionExpedienteRepositorio.ModificarEstado(etiqueta, tramiteRegistrado.IdExpediente, usuarioId);
            }catch(Exception){
                throw;
            }
        }
    }

    private static bool EsUltimoTramite(Tramite tramite)
    {
        List<Tramite>? tramites = ConsultaTramite.ConsultaTodosTramites();
        return tramites?.Where(t=>t.IdExpediente == tramite.IdExpediente).Max(t => t.Id) == tramite.Id;
    }

    async private static Task AtualizarTramite(Tramite tramite, string filePath)
    {
        List<Tramite>? tramites = ConsultaTramite.ConsultaTodosTramites() ?? new List<Tramite>();
        tramites.RemoveAll(t => t.Id == tramite.Id);
        tramites.Add(tramite);
        tramites.Sort((t1, t2) => t1.Id.CompareTo(t2.Id));

        string json = JsonSerializer.Serialize(tramites, new JsonSerializerOptions { WriteIndented = true });
        await File.WriteAllTextAsync(filePath, json);
    }
}
