using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SGE.Repositorios;

public class ExpedienteRepositorioArchivo : IExpedienteRepositorio
{
    private const string FilePath = "expedientes.csv";

    public Expediente ObtenerPorId(int id)
    {
        var expedientes = LeerExpedientesDesdeArchivo();
        return expedientes.FirstOrDefault(e => e.Id == id);
    }

    public void Crear(Expediente expediente)
    {
        var expedientes = LeerExpedientesDesdeArchivo();
        expediente.Id = expedientes.Count == 0 ? 1 : expedientes.Max(e => e.Id) + 1;
        expedientes.Add(expediente);
        GuardarExpedientesEnArchivo(expedientes);
    }

    public void Actualizar(Expediente expediente)
    {
        var expedientes = LeerExpedientesDesdeArchivo();
        var indice = expedientes.FindIndex(e => e.Id == expediente.Id);
        if (indice != -1)
        {
            expedientes[indice] = expediente;
            GuardarExpedientesEnArchivo(expedientes);
        }
    }

    public void Eliminar(int id)
    {
        var expedientes = LeerExpedientesDesdeArchivo();
        var expediente = expedientes.FirstOrDefault(e => e.Id == id);
        if (expediente != null)
        {
            expedientes.Remove(expediente);
            GuardarExpedientesEnArchivo(expedientes);
        }
    }

    public IEnumerable<Expediente> Listar()
    {
        return LeerExpedientesDesdeArchivo();
    }

    private List<Expediente> LeerExpedientesDesdeArchivo()
    {
        var expedientes = new List<Expediente>();
        if (!File.Exists(FilePath))
            return expedientes;

        var lineas = File.ReadAllLines(FilePath);
        foreach (var linea in lineas)
        {
            var campos = linea.Split(',');
            var expediente = new Expediente
            {
                Id = int.Parse(campos[0]),
                Caratula = campos[1],
                FechaCreacion = DateTime.Parse(campos[2]),
                FechaUltimaModificacion = DateTime.Parse(campos[3]),
                UsuarioUltimaModificacionId = int.Parse(campos[4]),
                Estado = Enum.Parse<EstadoExpediente>(campos[5])
            };
            expedientes.Add(expediente);
        }
        return expedientes;
    }

    private void GuardarExpedientesEnArchivo(List<Expediente> expedientes)
    {
        var lineas = expedientes.Select(e =>
            $"{e.Id},{e.Caratula},{e.FechaCreacion},{e.FechaUltimaModificacion},{e.UsuarioUltimaModificacionId},{e.Estado}");
        File.WriteAllLines(FilePath, lineas);
    }
}

