using System;
using System.Threading.Tasks;
using BlazorApp.Shared;

namespace BlazorApp.Client.Interfaces;

public interface IWarrantGrantCaseService
{
    Task<WarrantGrantCase> CreateCaseAsync(Guid id);
}