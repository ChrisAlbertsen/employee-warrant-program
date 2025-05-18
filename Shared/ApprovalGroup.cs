using System;
using System.Collections.Generic;

namespace BlazorApp.Shared;

public class ApprovalGroup
{
    public Guid Id { get; set; }
    public ICollection<WarrantAllocation> PendingAllocations { get; set; } = new List<WarrantAllocation>();
}