using System.Collections.Generic;
using System.Linq;
using Api.Functions.Employee;
using Api.Persistence;
using BlazorApp.Shared;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Api.Functions.Case;

public class GetCase(AppDbContext dbContext, ILogger<GetEmployee> logger)
{
    [Function("GetCase")]
    public HttpResponseData Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get")]
        HttpRequestData req,
        string? fullName)
    {
        logger.LogInformation("GetCase function request was made.");
        var employee = fullName is null ? GetAllCases() : SearchCases(fullName);
        var response = req.CreateResponse();
        response.WriteAsJsonAsync(employee);
        return response;
    }

    private List<WarrantGrantCase> SearchCases(string nameQuery)
    {
        if (string.IsNullOrWhiteSpace(nameQuery))
            return [];

        var cases = dbContext
            .WarrantGrantCases
            .Where(e => e.Employee.FullName.ToLower().Contains(nameQuery.ToLower()))
            .ToList();

        return cases;
    }

    private List<WarrantGrantCase> GetAllCases()
    {
        var cases = dbContext
            .WarrantGrantCases
            .Include(wcg => wcg.Employee)
            .ToListAsync()
            .Result;
        return cases;
    }
}