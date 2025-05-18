using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Exceptions;
using Api.Interfaces;
using Api.Persistence;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Extensions.Sql;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Api.Functions.ConfirmationLetter;

public class SendConfirmationLetter(
    AppDbContext dbContext,
    ILogger<SendConfirmationLetter> logger,
    ISignatureService signatureService)
{
    [Function("SendConfirmationLetter")]
    public async Task Run(
        [SqlTrigger("[dbo].[ConfirmationLetters]", "SqlConnectionString")]
        IReadOnlyList<SqlChange<BlazorApp.Shared.ConfirmationLetter>> changes,
        FunctionContext context)
    {
        var insertChanges = changes
            .Where(c => c.Operation == SqlChangeOperation.Insert)
            .ToList();

        foreach (var change in insertChanges) await SendLetter(change.Item);
    }

    private async Task SendLetter(BlazorApp.Shared.ConfirmationLetter confirmationLetter)
    {
        var employee = dbContext
            .WarrantGrantCases.Include(warrantGrantCase => warrantGrantCase.Employee)
            .FirstOrDefault(wgc => wgc.ConfirmationLetterId == confirmationLetter.Id)?
            .Employee;

        if (employee == null)
            throw new WarrantGrantException(
                $"Employee for WarrantGrantCase with id: {confirmationLetter.WarrantGrantCaseId} not found");

        await signatureService.RequestSignatureAsync(employee);
        await MarkConfirmationLetterSent(confirmationLetter);
    }

    private async Task MarkConfirmationLetterSent(BlazorApp.Shared.ConfirmationLetter confirmationLetter)
    {
        confirmationLetter.IsSent = true;
        dbContext.Attach(confirmationLetter).State = EntityState.Modified;
        await dbContext.EnsuredSaveChangesAsync();
    }
}