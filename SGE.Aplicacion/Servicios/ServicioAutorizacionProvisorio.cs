class ServicioAutorizacionProvisorio{
     public static bool VerifyAuthorization(string usuario, Permiso permiso){
        if(permiso == Permiso.ExpedienteAlta){
            return usuario == "editor";
        }
        return false;
    }
}