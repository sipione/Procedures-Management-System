using SGE.Aplicacion.Entidades;
namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteConsultaPorld
{
    public static Expediente ConsultarPorId(List<Expediente> expedientes, int id)
    {
        Expediente? encontrado = expedientes.Find(expediente => expediente.Id == id);
        if (encontrado == null)
        {
            throw GeneralExcepcion.NotFoundExcepcion("Expediente no encontrado");
        }
        else
        {
            return encontrado;
        }
    }
}
