using System;

namespace BlazorApp.Shared
{
    public class Case
    {
        public string Id { get; set; }
        public string EmployeeId { get; set; }
        public Guid WarrantAllocationId { get; set; }
        public WarrantAllocation WarrantAllocation { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public DateOnly GrantDate { get; set; } 
        public bool IsConfirmationLetterSent { get; set; }
        public bool IsSignatureRequested { get; set; }
        public bool IsApprovedByBoard { get; set; }
        public bool IsRegisteredBySkat { get; set; }
    }
}