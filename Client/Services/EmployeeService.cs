using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using BlazorApp.Client.Interfaces;
using BlazorApp.Shared;

namespace BlazorApp.Client.Services;

public class EmployeeService(HttpClient httpClient) : IEmployeeService
{
    public async Task<IEnumerable<Employee>> GetEmployeesAsync()
    {
        var result = await httpClient.GetFromJsonAsync<IEnumerable<Employee>>("api/GetEmployee");
        return result;
    }
}