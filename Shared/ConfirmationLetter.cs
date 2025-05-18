using System;

namespace BlazorApp.Shared;

public class ConfirmationLetter
{
    public Guid Id { get; set; }
    public required Guid WarrantGrantCaseId { get; set; }
    public bool IsSent { get; set; }
    public bool IsSigned { get; set; }
}