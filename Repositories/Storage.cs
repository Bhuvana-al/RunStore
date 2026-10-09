using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Encodings.Web;
using System.Text.Json;
using Client.Interfaces;

namespace Client.Repositories;

public class Storage<T> : IStorage<T> where T : class
{
    
    readonly JsonSerializerOptions options = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
        WriteIndented = true,
        PropertyNameCaseInsensitive = true
    };
    public List<T> Read(string path)
    {
        try
        {
            var json = File.ReadAllText(path);
            var data = JsonSerializer.Deserialize<List<T>>(json, options);
            return data ?? [];

            /*string data = File.ReadAllText(path);
            if (!string.IsNullOrEmpty(data) || !string.IsNullOrWhiteSpace(data))
            {
                return JsonSerializer.Deserialize<List<T>>(data, options)!;
            }
            else
            {
                return [];
            } */
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        } 
    }

    public void Write(string path, List<T> data)
    {
        try
        {
            var json = JsonSerializer.Serialize(data, options);
            File.WriteAllText(path, json);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
