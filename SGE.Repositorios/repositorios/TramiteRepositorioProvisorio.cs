using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class TramiteRepositorioArchivo : ITramiteRepositorio
{
    private const string FilePath = "tramites.csv";

    public Tramite? ObtenerPorId(int id)
    {
        var tramites = LeerTramitesDesdeArchivo();
        return tramites.FirstOrDefault(t => t.Id == id);
    }

    public IEnumerable<Tramite> ObtenerPorEtiqueta(EtiquetaTramite etiquetaTramite)
    {
        var tramites = LeerTramitesDesdeArchivo();
        return tramites.Where(t => t.Etiqueta == etiquetaTramite);
    }

    public void Crear(Tramite tramite)
    {
        var tramites = LeerTramitesDesdeArchivo();
        tramite.Id = tramites.Count == 0 ? 1 : tramites.Max(t => t.Id) + 1;
        tramites.Add(tramite);
        GuardarTramitesEnArchivo(tramites);
    }

    public void Actualizar(Tramite tramite)
    {
        var tramites = LeerTramitesDesdeArchivo();
        var indice = tramites.FindIndex(t => t.Id == tramite.Id);
        if (indice != -1)
        {
            tramites[indice] = tramite;
            GuardarTramitesEnArchivo(tramites);
        }
    }

    public void Eliminar(int id)
    {
        var tramites = LeerTramitesDesdeArchivo();
        var tramite = tramites.FirstOrDefault(t => t.Id == id);
        if (tramite != null)
        {
            tramites.Remove(tramite);
            GuardarTramitesEnArchivo(tramites);
        }else{
            throw new Exception("El tramite no existe");
        }
    }

    public IEnumerable<Tramite> ObtenerPorExpediente(int expedienteId) => 
        LeerTramitesDesdeArchivo().Where(t => t.ExpedienteId == expedienteId);

    public Tramite? ObtenerUltimoTramitePorExpediente(int expedienteId) => 
        LeerTramitesDesdeArchivo().Where(t => t.ExpedienteId == expedienteId).OrderByDescending(t => t.FechaCreacion).FirstOrDefault();

    private List<Tramite> LeerTramitesDesdeArchivo()
    {
        var tramites = new List<Tramite>();
        if (!File.Exists(FilePath))
            return tramites;

        var lineas = File.ReadAllLines(FilePath);
        foreach (var linea in lineas)
        {
            var campos = linea.Split(',');
            var tramite = new Tramite
            {
                Id = int.Parse(campos[0]),
                ExpedienteId = int.Parse(campos[1]),
                Etiqueta = (EtiquetaTramite)Enum.Parse(typeof(EtiquetaTramite), campos[2]),
                Contenido = campos[3],
                FechaCreacion = DateTime.Parse(campos[4]),
                FechaUltimaModificacion = DateTime.Parse(campos[5]),
                UsuarioUltimaModificacionId = int.Parse(campos[6])
            };
            tramites.Add(tramite);
        }
        return tramites;
    }

    private void GuardarTramitesEnArchivo(List<Tramite> tramites)
    {
        var lineas = tramites.Select(t =>
            $"{t.Id},{t.ExpedienteId},{t.Etiqueta},{t.Contenido},{t.FechaCreacion},{t.FechaUltimaModificacion},{t.UsuarioUltimaModificacionId}");
        File.WriteAllLines(FilePath, lineas);
    }
}
