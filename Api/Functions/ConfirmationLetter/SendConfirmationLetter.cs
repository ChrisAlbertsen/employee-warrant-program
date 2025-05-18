using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Exceptions;
using Api.Persistence;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Extensions.Sql;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Api.Functions.ConfirmationLetter;

public class SendConfirmationLetter(AppDbContext dbContext, ILogger<SendConfirmationLetter> logger)
{
    [Function("SendConfirmationLetter")]
    public async Task Run(
        [SqlTrigger("[dbo].[ConfirmationLetters]", "SqlConnectionString")]
        IReadOnlyList<SqlChange<BlazorApp.Shared.ConfirmationLetter>> changes,
        FunctionContext context)
    {
        //TODO: fix culture to use WarrantGrantCases table instead. Is currently throwing "JSON value is not in a supported DateOnly format".
        var insertChanges = changes
            .Where(c => c.Operation == SqlChangeOperation.Insert)
            .ToList();
        
        foreach (var change in insertChanges)
        {
            await SendLetter(change.Item);
        }
    }

    private async Task SendLetter(BlazorApp.Shared.ConfirmationLetter confirmationLetter)
    {
        var employee = dbContext
            .WarrantGrantCases.Include(warrantGrantCase => warrantGrantCase.Employee)
            .FirstOrDefault(wgc => wgc.ConfirmationLetterId == confirmationLetter.Id)?
            .Employee;
        
        logger.LogInformation($"Sending confirmation letter to: {employee.FullName}");
        await MarkConfirmationLetterSent(confirmationLetter);
    }

    private async Task MarkConfirmationLetterSent(BlazorApp.Shared.ConfirmationLetter confirmationLetter)
    {
        confirmationLetter.IsSent = true;        
        dbContext.Attach(confirmationLetter).State = EntityState.Modified;
        var result = await dbContext.SaveChangesAsync();
        if(result == 0) throw new ConfirmationLetterUpdateFailedException(confirmationLetter.Id);
    }
}