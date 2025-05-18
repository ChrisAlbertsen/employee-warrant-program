using System;

namespace Api.Exceptions;

public class WarrantGrantException(string message) : 
    Exception(message)
{
    
}