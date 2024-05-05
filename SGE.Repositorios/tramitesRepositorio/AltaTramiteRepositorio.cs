﻿using System.IO;
using System.Text.Json;
using SGE.Aplicacion;
using SGE.Aplicacion.Entidades;
namespace SGE.Repositorios;

public class AltaTramiteRepositorio
{
    private static JsonSerializerOptions GetOptions()
    {
        return new JsonSerializerOptions { WriteIndented = true };
    }
    public async Task<string> CrearTramite(string IdExpediente, string Contenido, int UsuarioId)
    {
        try
        {
            string filePath = "../SGE.Repositorios/tramitesRepositorio/Tramites.json"; // Specify the file path where you want to save the object
            List<Tramite> tramites = getAllTramitesFromTheFile(filePath);
            int Id = GenerateTramiteId(tramites);
            Tramite tramite = CasoDeUsoTramiteAlta.CrearTramite(IdExpediente, Contenido, UsuarioId, Id);

            await GuardarTramite(tramite, filePath, tramites);
            return "Tramite creado con éxito";
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al crear tramite: {ex.Message}");
            return $"No fue posible crear el Tramite. Error: {ex.Message}";
        }
    }

    private static List<Tramite> getAllTramitesFromTheFile(string filePath)
    {
        List<Tramite> tramites = new();
        if (File.Exists(filePath))
        {

            string json = File.ReadAllText(filePath);
            try
            {
                // Deserialize JSON string into 'Tramite' object
                tramites = JsonSerializer.Deserialize<List<Tramite>>(json)!;
            }
            catch (JsonException ex)
            {
                // Handle JSON deserialization error
                Console.WriteLine($"Error deserializing JSON: {ex.Message}");
                throw new Exception(ex.Message);
            }
        }
        return tramites;
    }

    private static int GenerateTramiteId(List<Tramite> tramites)
    {
        int id = 1;
        if (tramites.Count > 0)
        {
            id = tramites.Max(tramite => tramite.Id) + 1;
        }
        return id;
    }

    private static Task<int> GuardarTramite(Tramite tramite, string filePath, List<Tramite> tramites)
    {
        tramites.Add(tramite);

        if (!File.Exists(filePath))
        {
            File.Create(filePath).Dispose();
        }

        try
        {
            string jsonString = JsonSerializer.Serialize(tramites, GetOptions());
            File.WriteAllText(filePath, jsonString);
            return Task.FromResult(tramite.Id);
        }
        catch (JsonException ex)
        {
            // Handle JSON serialization error
            Console.WriteLine($"Error serializing JSON: {ex.Message}");
            throw new Exception(ex.Message);
        }
    }
}