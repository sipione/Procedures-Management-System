using SGE.Aplicacion.Entidades;
namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteConsultaPorld
{
    public static Expediente ConsultarPorId(List<Expediente> expedientes, int id)
    {
        return  expedientes.Find(expediente => expediente.Id == id)!;
    }
}
