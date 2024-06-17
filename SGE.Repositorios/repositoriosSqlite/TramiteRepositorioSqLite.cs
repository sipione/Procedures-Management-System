using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

public class TramiteRepositorioSqLite : ITramiteRepositorio
{
    private readonly SGEContexto _contexto;

    public TramiteRepositorioSqLite(SGEContexto contexto)
    {
        _contexto = contexto;
    }

    public Tramite? ObtenerPorId(int id)
    {
        return _contexto.Tramites.FirstOrDefault(t => t.Id == id);
    }

    public IEnumerable<Tramite> ObtenerTodos()
    {
        return _contexto.Tramites.ToList();
    }

    public IEnumerable<Tramite> ObtenerPorEtiqueta(EtiquetaTramite etiquetaTramite)
    {
        return _contexto.Tramites.Where(t => t.Etiqueta == etiquetaTramite).ToList();
    }

    public void Crear(Tramite tramite)
    {
        _contexto.Tramites.Add(tramite);
        _contexto.SaveChanges();
    }

    public void Actualizar(Tramite tramite)
    {
        _contexto.Tramites.Update(tramite);
        _contexto.SaveChanges();
    }

    public void Eliminar(int id)
    {
        var tramite = _contexto.Tramites.FirstOrDefault(t => t.Id == id);
        if (tramite != null)
        {
            _contexto.Tramites.Remove(tramite);
            _contexto.SaveChanges();
        }
        else
        {
            throw new Exception("El tramite no existe");
        }
    }

    public IEnumerable<Tramite> ObtenerPorExpediente(int expedienteId)
    {
        return _contexto.Tramites.Where(t => t.ExpedienteId == expedienteId).ToList();
    }

    public Tramite? ObtenerUltimoTramitePorExpediente(int expedienteId)
    {
        return _contexto.Tramites.Where(t => t.ExpedienteId == expedienteId)
            .OrderByDescending(t => t.FechaCreacion)
            .FirstOrDefault();
    }
}