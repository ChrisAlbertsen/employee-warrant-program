using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorApp.Shared;

namespace BlazorApp.Client.Interfaces;

public interface IEmployeeService
{
    Task<IEnumerable<Employee>> GetEmployeesAsync();
}