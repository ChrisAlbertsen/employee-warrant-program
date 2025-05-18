using System;

namespace Api.Exceptions;

public class ConfirmationLetterUpdateFailedException(Guid Id) : 
    Exception($"Letter was sent for ConfirmationLetter id: {Id}, but database save failed")
{
    
}