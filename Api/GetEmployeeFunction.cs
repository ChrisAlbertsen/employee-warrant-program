using BlazorApp.Shared;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace Api.EmployeeFunctions
{
    public class GetEmployeeFunction(ILogger<GetEmployeeFunction> logger)
    {
        [Function("GetEmployee")]
        public HttpResponseData Run([HttpTrigger(AuthorizationLevel.Anonymous, "get")] HttpRequestData req)
        {
            logger.LogInformation("GetAllEmployees function request was made.");
            var employees = new List<Employee>
            {
                new Employee
                {
                    Id = "E001",
                    Name = "Alice Johnson",
                    Email = "alice.johnson@example.com",
                    NumberOfWarrants = 150,
                    Ownership = 0.025m
                },
                new Employee
                {
                    Id = "E002",
                    Name = "Bob Smith",
                    Email = "bob.smith@example.com",
                    NumberOfWarrants = 200,
                    Ownership = 0.035m
                },
                new Employee
                {
                    Id = "E003",
                    Name = "Charlie Davis",
                    Email = "charlie.davis@example.com",
                    NumberOfWarrants = 100,
                    Ownership = 0.015m
                },
                new Employee
                {
                    Id = "E004",
                    Name = "Dana Lee",
                    Email = "dana.lee@example.com",
                    NumberOfWarrants = 250,
                    Ownership = 0.045m
                }
            };
            
            var response = req.CreateResponse();
            response.WriteAsJsonAsync(employees);
            return response;
        }
    }
}
