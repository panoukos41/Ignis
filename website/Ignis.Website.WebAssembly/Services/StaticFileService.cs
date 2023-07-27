﻿using System.Net;
using System.Net.Http.Json;
using Ignis.Website.Services;

namespace Ignis.Website.WebAssembly.Services;

internal class StaticFileService : IStaticFileService
{
    private readonly HttpClient _httpClient;

    public StaticFileService(HttpClient httpClient)
    {
        _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
    }
    
    public async Task<string?> GetFileContentAsync(string path, CancellationToken cancellationToken = default)
    {
        try
        {
            return await _httpClient.GetStringAsync(path, cancellationToken);
        }
        catch (HttpRequestException exception)
        {
            if (exception.StatusCode == HttpStatusCode.NotFound) return null;

            throw;
        }
    }

    public Task<T?> GetFileContentAsync<T>(string path, CancellationToken cancellationToken = default)
    {
        return _httpClient.GetFromJsonAsync<T>(path, cancellationToken);
    }
}