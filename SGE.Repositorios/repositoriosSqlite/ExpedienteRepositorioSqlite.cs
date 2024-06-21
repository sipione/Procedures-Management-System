using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace SGE.Repositorios
{
    public class ExpedienteRepositorioSqlite : IExpedienteRepositorio
    {
        private readonly SGEContexto _contexto;

        public ExpedienteRepositorioSqlite(SGEContexto contexto)
        {
            _contexto = contexto;
        }

        public Expediente ObtenerPorId(int id)
        {
            return _contexto.Expedientes.FirstOrDefault(e => e.Id == id);
        }

        public void Crear(Expediente expediente)
        {
            _contexto.Expedientes.Add(expediente);
            _contexto.SaveChanges();
        }

        public void Actualizar(Expediente expediente)
        {
            var expedienteExistente = _contexto.Expedientes.FirstOrDefault(e => e.Id == expediente.Id);
            if (expedienteExistente != null)
            {
                expedienteExistente.Caratula = expediente.Caratula;
                expedienteExistente.FechaCreacion = expediente.FechaCreacion;
                expedienteExistente.FechaUltimaModificacion = expediente.FechaUltimaModificacion;
                expedienteExistente.UsuarioUltimaModificacionId = expediente.UsuarioUltimaModificacionId;
                expedienteExistente.Estado = expediente.Estado;
                expedienteExistente.Tramites = new List<Tramite>(expediente.Tramites);
                _contexto.SaveChanges();
            }else
            {
                throw new Exception("El expediente no existe");
            }
        }

        public void Eliminar(int id)
        {
            var expediente = _contexto.Expedientes.FirstOrDefault(e => e.Id == id);
            if (expediente != null)
            {
                _contexto.Expedientes.Remove(expediente);
                _contexto.SaveChanges();
            }
        }

        public IEnumerable<Expediente> Listar()
        {
            return _contexto.Expedientes.ToList();
        }
    }
}