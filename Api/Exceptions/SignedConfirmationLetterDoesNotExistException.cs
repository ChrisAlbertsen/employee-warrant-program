using System;

namespace Api.Exceptions;

public class SignedConfirmationLetterDoesNotExistException(Guid id) : 
    Exception($"The signed confirmation letter with id {id} does not exist")
{
    
}