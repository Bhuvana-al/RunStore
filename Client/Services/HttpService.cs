using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls.Platform;
using Client.Interfaces;

namespace Client.Services;

public class HttpService<T> : IHttpService<T> where T : class
{
    private readonly JsonSerializerOptions _options = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
        WriteIndented = true
    };

    public async Task Delete(string resource, string id)
    {
        try
        {
            var url = $"https://runstore-cbea.restdb.io/rest/{resource}/{id}";
            using HttpClient httpClient = new();
            httpClient.BaseAddress = new Uri(url);
            httpClient.DefaultRequestHeaders.Add("Cache-Control","none");
            httpClient.DefaultRequestHeaders.Add("x-apikey", "c9fe87657e4a320046a28c1a055b394d4ab5c");
            
            await httpClient.DeleteAsync(url);
        }
        catch (Exception ex)
        {
            
            throw new Exception(ex.Message);
        }
    }

    public async Task<List<T>> Get(string resource)
    {
        // steg 1. Skapa sökvägen till resursen
        var url = $"https://runstore-cbea.restdb.io/rest/{resource}";
        
        // steg 2. Skapa en instans av HttpClient(.Net) klassen.
        using HttpClient client = new();

        // steg 3. Konfigurera HttpClient objektet.
        client.BaseAddress = new Uri(url);
        client.DefaultRequestHeaders.Add("Cache-Control", "none");
        client.DefaultRequestHeaders.Add("x-apikey" , "c9fe87657e4a320046a28c1a055b394d4ab5c");
        
        // steg 4. Skicka paketet
        var response = await client.GetAsync(url);

        if (!response.IsSuccessStatusCode) return [];

        var result = await response.Content.ReadAsStringAsync();

        var list = JsonSerializer.Deserialize<List<T>>(result, _options) ?? [];
        return list;
    }

    public async Task<T> Get(string resource, string predicate)
    {
        try
        {
            var url = $"https://runstore-cbea.restdb.io/rest/{resource}?q={predicate}";

            using HttpClient client = new();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Add("Cache-Control", "none");
            client.DefaultRequestHeaders.Add("x-apikey" , "c9fe87657e4a320046a28c1a055b394d4ab5c");

            var response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                
                if(string.IsNullOrWhiteSpace(result))
                {
                    throw new Exception("Fanns ingenting");
                }
                
                var data = JsonSerializer.Deserialize<List<T>>(result, _options)!;
                return data[0];

            }
            throw new Exception("Det gick fel: " + response.StatusCode);
        }
        catch(Exception ex)
        {
            throw new Exception(ex.Message);
        }

    }

    public async Task Post(string resource, T data)
    {
        try
        {
            var url = $"https://runstore-cbea.restdb.io/rest/{resource}";
            
            using HttpClient client = new();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Add("Cache-Control", "none");
            client.DefaultRequestHeaders.Add("x-apikey", "c9fe87657e4a320046a28c1a055b394d4ab5c");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            await client.PostAsJsonAsync<T>(url, data);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task Put(string resource, T data, string objectId)
    {
        try
        {
            var url = $"https://runstore-cbea.restdb.io/rest/{resource}/{objectId}";
            using HttpClient httpClient = new();
            httpClient.BaseAddress = new Uri(url);
            httpClient.DefaultRequestHeaders.Add("Cache-Control","none");
            httpClient.DefaultRequestHeaders.Add("x-apikey", "c9fe87657e4a320046a28c1a055b394d4ab5c");
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("appilcation/json"));

            await httpClient.PutAsJsonAsync<T>(url, data);
        }
        catch(HttpRequestException ex)
        {
            throw new Exception(ex.Message);
        }
        catch(Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
