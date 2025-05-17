using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using BlazorApp.Client.Interfaces;
using BlazorApp.Shared;

namespace BlazorApp.Client.Services;

public class WarrantGrantCaseService(HttpClient httpClient) : IWarrantGrantCaseService
{
    public async Task<WarrantGrantCase> CreateCaseAsync(Guid id)
    {
        var result = await httpClient.PostAsync($"api/CreateCase?id={id}", null);
        result.EnsureSuccessStatusCode();
        var warrantGrantCase = await result.Content.ReadFromJsonAsync<WarrantGrantCase>();
        return warrantGrantCase;
    }

    public async Task<IEnumerable<WarrantGrantCase>> GetAllCasesAsync()
    {
        var warrantGrantCases = await httpClient.GetFromJsonAsync<IEnumerable<WarrantGrantCase>>("api/GetCase");
        return warrantGrantCases ?? Array.Empty<WarrantGrantCase>();
    }
}