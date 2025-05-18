using System;
using System.Linq;
using System.Net;
using Api.Exceptions;
using Api.Persistence;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace Api.Functions.ConfirmationLetter;

public class ReceiveConfirmationLetterSignature(
    AppDbContext dbContext,
    ILogger<ReceiveConfirmationLetterSignature> logger)
{
    [Function("ConfirmationLetterSigned")]
    public HttpResponseData Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "post")]
        HttpRequestData req,
        Guid id)
    {
        logger.LogInformation("ConfirmationLetterSigned was called");
        RegisterConfirmationLetterSignature(id);
        var response = req.CreateResponse(HttpStatusCode.OK);
        return response;
    }

    private void RegisterConfirmationLetterSignature(Guid confirmationLetterId)
    {
        var confirmationLetter = dbContext
            .ConfirmationLetters
            .FirstOrDefault(cl => cl.Id == confirmationLetterId);

        if (confirmationLetter == null)
            throw new ConfirmationLetterException($"Confirmation letter not found for id: {confirmationLetterId}");

        confirmationLetter.IsSigned = true;

        dbContext.EnsuredSaveChanges();
    }
}