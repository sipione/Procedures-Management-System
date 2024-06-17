public interface IServicioAutorizacion
{
    bool PoseeElPermiso(int idUsuario, Permiso permiso);
    List<Permiso> AdminitradorPermisos();
}
