using System.Data.Common;
using SGE.Aplicacion;

internal class ServicioAutorizacionProvisorio : IServicioAutorizacion{
    public bool PoseeElPermiso(int usuarioId, Permiso permiso){
        if(permiso == Permiso.ExpedienteAlta){
            return usuarioId == 1;
        }
        return usuarioId == 1;
    }
}