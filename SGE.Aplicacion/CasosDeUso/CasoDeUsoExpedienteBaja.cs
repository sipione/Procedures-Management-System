using SGE.Aplicacion.Entidades;
namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteBaja
{
    public static List<Expediente> DeleteExpediente(int id, List<Expediente> expedientes, int UsuarioId)
    {
        ServicioAutorizacionProvisorio servicioAutorizacionProvisorio = new ServicioAutorizacionProvisorio();
        bool autorizado = servicioAutorizacionProvisorio.PoseeElPermiso(UsuarioId, Permiso.ExpedienteBaja);
        if (!autorizado)
        {
            throw AutorizacionExcepcion.NotAuthorizedException("No posee el permiso para eliminar expedientes.");
        }

        Expediente? expediente = expedientes.Find(expediente => expediente.Id == id);
        if (expediente is null)
        {
            throw GeneralExcepcion.NotFoundExcepcion("Expediente no encontrado.");
        }

        expedientes.Remove(expediente);
        
        return expedientes;
    }
}
