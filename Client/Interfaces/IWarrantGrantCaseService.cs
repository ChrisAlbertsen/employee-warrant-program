using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorApp.Shared;

namespace BlazorApp.Client.Interfaces;

public interface IWarrantGrantCaseService
{
    Task<WarrantGrantCase> CreateCaseAsync(Guid id);
    
    Task<IEnumerable<WarrantGrantCase>> GetAllCasesAsync();
}