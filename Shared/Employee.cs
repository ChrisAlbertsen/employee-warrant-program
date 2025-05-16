using System;
using System.Collections.Generic;

namespace BlazorApp.Shared
{
    public class Employee
    {
        public Guid Id { get; set; }
        public string Cpr { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        
        public ICollection<WarrantAllocation> WarrantAllocations { get; set; }
        public ICollection<WarrantGrantCase> WarrantGrantCases { get; set; }
    }
}