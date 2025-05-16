using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Api.Persistence;
using BlazorApp.Shared;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Api;

public class CreateCase(AppDbContext dbContext, ILogger<GetEmployee> logger)
{
    [Function("CreateCase")]
    public HttpResponseData Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "post")]
        HttpRequestData req,
        Guid id)
    {
        logger.LogInformation("CreateCase function request was made.");
        CreateWarrantGrantCase(id);
        return req.CreateResponse(HttpStatusCode.OK);
    }

    private void CreateWarrantGrantCase(Guid id)
    {
        var warrantGrantCase = new WarrantGrantCase()
        {
            EmployeeId = id,
        };
        
        dbContext.WarrantGrantCases.Add(warrantGrantCase);
        dbContext.SaveChanges();
        Console.WriteLine("Warrant grant case created.");
    }
}