using System;

namespace Api.Exceptions;

public class ConfirmationLetterException(string message) :
    Exception(message)
{
}