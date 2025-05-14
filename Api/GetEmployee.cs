using System;
using System.Collections.Generic;
using BlazorApp.Shared;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Extensions.Sql;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace Api
{
    public class GetEmployee(ILogger<GetEmployee> logger)
    {
        [Function("GetEmployee")]
        public HttpResponseData Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get")]
            HttpRequestData req,
            [SqlInput(commandText: "select * from dbo.Employee",
                commandType: System.Data.CommandType.Text,
                parameters: "@Id={Query.id}",
                connectionStringSetting: "SqlConnectionString")
            ]
            ICollection<Employee> employees)
        {
            logger.LogInformation("GetEmployee function request was made.");
            var response = req.CreateResponse();
            response.WriteAsJsonAsync(employees);
            return response;
        }
    }
}
