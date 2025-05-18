using System.Threading.Tasks;
using Api.Interfaces;
using BlazorApp.Shared;
using Microsoft.Extensions.Logging;

namespace Api.Services;

public class DocumentSignatureService(ILogger<DocumentSignatureService> logger) : ISignatureService
{
    public Task RequestSignatureAsync(Employee employee)
    {
        logger.LogInformation("Signature request was sent");
        return Task.CompletedTask;
    }
}