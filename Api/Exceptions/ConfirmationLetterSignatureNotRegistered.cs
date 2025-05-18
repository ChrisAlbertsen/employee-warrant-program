using System;

namespace Api.Exceptions;

public class ConfirmationLetterSignatureNotRegistered(Guid id) :
    Exception($"Signature for confirmation letter with id : {id} failed to register")
{
}