using System;

namespace BlazorApp.Shared;

public class WarrantGrantCase
{
    public WarrantGrantCase()
    {
        ConfirmationLetter = new ConfirmationLetter
        {
            WarrantGrantCaseId = Id
        };
    }

    public Guid Id { get; set; } = Guid.NewGuid();
    public required Guid EmployeeId { get; set; }
    public Employee Employee { get; set; }
    public Guid ConfirmationLetterId { get; set; }
    public ConfirmationLetter ConfirmationLetter { get; set; }
    public Guid? WarrantAllocationId { get; set; }
    public DateOnly StartDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);
    public DateOnly? EndDate { get; set; }
    public bool IsSignatureRequested { get; set; } = false;
    public bool IsApprovedByBoard { get; set; } = false;
    public bool IsRegisteredBySkat { get; set; } = false;
    public bool IsGranted { get; set; }
}