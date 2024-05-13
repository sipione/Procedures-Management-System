using System.Data.Common;
using SGE.Aplicacion;

internal class ServicioAutorizacionProvisorio : IServicioAutorizacion{
    public bool PoseeElPermiso(int usuarioId, Permiso permiso){

        return usuarioId == 1;
    }
}