using System;
using System.Collections.Generic;
using System.Linq;
using Api.Persistence;
using BlazorApp.Shared;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Extensions.Sql;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace Api
{
    public class GetEmployee(AppDbContext dbContext, ILogger<GetEmployee> logger)
    {
        [Function("GetEmployee")]
        public HttpResponseData Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get")]
            HttpRequestData req)
        {
            var employees = dbContext.Employees.ToList();
            logger.LogInformation("GetEmployee function request was made.");
            var response = req.CreateResponse();
            response.WriteAsJsonAsync(employees);
            return response;
        }
    }
}
