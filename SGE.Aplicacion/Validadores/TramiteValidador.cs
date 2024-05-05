using System.Reflection.Metadata;
using SGE.Aplicacion.Entidades;

internal class TramiteValidador{

    internal static bool Validar(Tramite tramite){
        if(tramite == null){
            return false;
        }
        if(tramite.Id.GetType() != typeof(int) || tramite.Id <= 0){
            return false;
        }

        if(tramite.Contenido == null || tramite.Contenido.Length == 0){
            return false;
        }

        return true;
    }
}