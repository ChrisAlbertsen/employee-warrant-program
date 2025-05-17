using System;

namespace Api.Exceptions;

public class WarrantGrantCaseNotCreatedException(Guid id)
    : Exception($"WarrantGrantCase was not created successfully for employee id {id}")
{
}