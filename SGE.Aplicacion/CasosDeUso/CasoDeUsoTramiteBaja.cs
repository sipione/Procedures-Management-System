using SGE.Aplicacion;
using SGE.Aplicacion.Entidades;

using System.Linq; // Add using directive for System.Linq
public class CasoDeUsoTramiteBaja
{
    public static List<Tramite>  DeleteTramitesByExpedienteId(int IdExpediente, List<Tramite> tramites, int UsuarioId)
    {
        ServicioAutorizacionProvisorio servicioAutorizacionProvisorio = new ServicioAutorizacionProvisorio();
        bool autorizado = servicioAutorizacionProvisorio.PoseeElPermiso(UsuarioId, Permiso.TramiteBaja);
        if (!autorizado)
        {
            throw AutorizacionExcepcion.NotAuthorizedException("No posee el permiso para eliminar trámites.");
        }

        List<Tramite> tramitesRestantes = new List<Tramite>(tramites);
        tramitesRestantes.RemoveAll(tramite => tramite.IdExpediente != IdExpediente);

        if (tramitesRestantes.Count == tramites.Count)
        {
            throw GeneralExcepcion.NotFoundExcepcion("Tramites no encontrados.");
        }
        return tramitesRestantes;
    }

    public static List<Tramite> DeleteTramite(int id, List<Tramite> tramites, int UsuarioId)
    {
        ServicioAutorizacionProvisorio servicioAutorizacionProvisorio = new ServicioAutorizacionProvisorio();
        bool autorizado = servicioAutorizacionProvisorio.PoseeElPermiso(UsuarioId, Permiso.TramiteBaja);
        if (!autorizado)
        {
            throw AutorizacionExcepcion.NotAuthorizedException("No posee el permiso para eliminar trámites.");
        }
 
        Tramite? tramite = tramites.FirstOrDefault(tramite => tramite.Id == id) ?? throw GeneralExcepcion.NotFoundExcepcion("Tramite no encontrado.");
        
        tramites.Remove(tramite);
        return tramites;
    }
}
