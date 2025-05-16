using System;

namespace BlazorApp.Shared
{
    public class WarrantAllocation
    {
        public Guid Id { get; set; }
        public Guid EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public int Quantity { get; set; }
        public decimal StrikePrice { get; set; }
        public DateOnly FullVestingDate { get; set; }
        public DateOnly GrantDate { get; set; }
        public DateOnly ExercisePeriodStart { get; set; }
        public DateOnly ExercisePeriodEnd { get; set; }
        public bool IsExercised { get; set; }
        public DateOnly? ExercisedOnDate { get; set; }
    }
}