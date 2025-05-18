using System;
using System.Net;
using System.Threading.Tasks;
using Api.Exceptions;
using Api.Functions.Employee;
using Api.Persistence;
using BlazorApp.Shared;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace Api.Functions.Case;

public class CreateCase(AppDbContext dbContext, ILogger<GetEmployee> logger)
{
    [Function("CreateCase")]
    public async Task<HttpResponseData> Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "post")]
        HttpRequestData req,
        Guid id)
    {
        logger.LogInformation("CreateCase function request was made.");
        var warrantGrantCase = await CreateWarrantGrantCase(id);

        var response = req.CreateResponse(HttpStatusCode.OK);
        await response.WriteAsJsonAsync(warrantGrantCase);
        return response;
    }

    private async Task<WarrantGrantCase> CreateWarrantGrantCase(Guid id)
    {
        var warrantGrantCase = new WarrantGrantCase
        {
            EmployeeId = id
        };

        dbContext.WarrantGrantCases.Add(warrantGrantCase);
        var result = await dbContext.SaveChangesAsync();
        if (result == 0) throw new WarrantGrantCaseNotCreatedException(id);
        logger.LogInformation("WarrantGrantCase created.");

        return warrantGrantCase;
    }
}