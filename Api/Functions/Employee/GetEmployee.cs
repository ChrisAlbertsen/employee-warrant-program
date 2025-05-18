using System.Collections.Generic;
using System.Linq;
using Api.Persistence;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Api.Functions.Employee;

public class GetEmployee(AppDbContext dbContext, ILogger<GetEmployee> logger)
{
    [Function("GetEmployee")]
    public HttpResponseData Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get")]
        HttpRequestData req,
        string? fullName)
    {
        var employee = fullName is null ? GetAllEmployees() : SearchEmployee(fullName);

        logger.LogInformation("GetEmployee function request was made.");
        var response = req.CreateResponse();
        response.WriteAsJsonAsync(employee);
        return response;
    }

    private List<BlazorApp.Shared.Employee> SearchEmployee(string nameQuery)
    {
        if (string.IsNullOrWhiteSpace(nameQuery))
            return [];

        var employees = dbContext
            .Employees
            .Where(e => e.FullName.ToLower().Contains(nameQuery.ToLower()))
            .ToList();

        return employees;
    }

    private List<BlazorApp.Shared.Employee> GetAllEmployees()
    {
        var employees = dbContext.Employees.ToListAsync().Result;
        return employees;
    }
}