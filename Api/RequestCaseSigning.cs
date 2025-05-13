using System.Collections.Generic;
using BlazorApp.Shared;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Extensions.Sql;
using Microsoft.Extensions.Logging;

namespace Api;

public class RequestCaseSigning(ILogger<RequestCaseSigning> logger)
{
    [Function("RequestSignatureFunction")]
    public void Run(
        [SqlTrigger("[dbo].[table1]", "")] IReadOnlyList<SqlChange<Case>> changes,
        FunctionContext context)
    {

    }
}
