using SGE.Aplicacion.Entidades;
namespace SGE.Aplicacion;

public class CasoDeUsoTramiteConsultaPorEtiqueta
{
    public static List<Tramite>? ConsultarPorEtiqueta(List<Tramite> tramites, EtiquetaTramite etiqueta)
    {
        return tramites.Where(tramite => tramite.Etiqueta == etiqueta).ToList() ?? null;
    }

}
