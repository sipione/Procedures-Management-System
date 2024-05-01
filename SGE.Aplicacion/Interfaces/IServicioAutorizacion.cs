namespace SGE.Aplicacion;

internal interface IServicioAutorizacion
{
    bool PoseeElPermiso(int usuarioId, Permiso permiso);
}
