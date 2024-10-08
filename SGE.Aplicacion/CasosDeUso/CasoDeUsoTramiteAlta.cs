﻿namespace SGE.Aplicacion.CasosDeUso
{
    public class CasoDeUsoTramiteAlta(
        ITramiteRepositorio _tramiteRepositorio,
        IServicioAutorizacion _servicioAutorizacion,
        IExpedienteRepositorio _expedienteRepositorio,
        TramiteValidador _tramiteValidador
    )
    {
        public void Ejecutar(Tramite tramite, int usuarioId)
        {
            if (!_servicioAutorizacion.PoseeElPermiso(usuarioId, Permiso.TramiteAlta))
            {
                throw new UnauthorizedAccessException("El usuario no tiene permiso para crear tramites.");
            }

            var expediente = _expedienteRepositorio.ObtenerPorId(tramite.ExpedienteId);
            if (expediente == null)
            {
                throw new Exception("El expediente no existe");
            }

            tramite.FechaCreacion = DateTime.Now;
            tramite.FechaUltimaModificacion = DateTime.Now;
            tramite.UsuarioUltimaModificacionId = usuarioId;
            tramite.Etiqueta = EtiquetaTramite.EscritoPresentado;

            _tramiteValidador.Validar(tramite);
            _tramiteRepositorio.Crear(tramite);
        }

        public OperationResult Ejecutar(Tramite tramite, int usuarioId, bool toApi)
        {
            try
            {
                Ejecutar(tramite, usuarioId);
                return OperationResult.Created(tramite, "Tramite creado con exito");
            }
            catch (UnauthorizedAccessException ex)
            {
                return OperationResult.Unauthorized(ex.Message);
            }
            catch (Exception ex)
            {
                return OperationResult.BadRequest(ex.Message);
            }
        }
    }
}
