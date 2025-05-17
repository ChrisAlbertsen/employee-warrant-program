using System;

namespace BlazorApp.Shared;

public class WarrantGrantCase
{
    public Guid Id { get; set; }
    public required Guid EmployeeId { get; set; }
    public Employee Employee { get; set; }
    public Guid? WarrantAllocationId { get; set; }
    public DateOnly StartDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);
    public DateOnly? EndDate { get; set; }
    public bool IsConfirmationLetterSent { get; set; } = false;
    public bool IsSignatureRequested { get; set; } = false;
    public bool IsApprovedByBoard { get; set; } = false;
    public bool IsRegisteredBySkat { get; set; } = false;
    public bool IsGranted { get; set; }
}