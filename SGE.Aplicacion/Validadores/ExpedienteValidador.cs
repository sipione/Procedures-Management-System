using SGE.Aplicacion.Entidades;

namespace SGE.Aplicacion;

internal class ExpedienteValidador
{
    internal static bool IsValidExpedienteCreation(Expediente expediente){
        if(string.IsNullOrEmpty(expediente.Caratula)){
            return false;
        }

        if(expediente.Id.GetType() != typeof(int) || expediente.Id <= 0){
            return false;
        }

        return true;
    }
}
