using SGE.Aplicacion;

internal class UsuarioValidador{
    internal static bool IsValidUsuarioCreation(Usuario usuario){
        if(usuario == null){
            return false;
        }

        if(usuario.Id.GetType() != typeof(int) || usuario.Id <= 0){
            return false;
        }

        if(usuario.Nombre == null || usuario.Nombre.Length == 0){
            return false;
        }

        return true;
    }
}