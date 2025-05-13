using System;

namespace BlazorApp.Shared
{
    public class WarrantAllocation
    {
        public Guid Id { get; set; }
        public Guid EmployeeId { get; set; }
        public int Quantity { get; set; }
        public decimal StrikePrice { get; set; }
        public DateTime FullVestingDate { get; set; }
        public bool IsGranted { get; set; }
        public DateTime GrantDate { get; set; }
        public DateTime ExercisePeriodStart { get; set; }
        public DateTime ExercisePeriodEnd { get; set; }
        public bool IsExercised { get; set; }
        public DateTime? ExerciseDate { get; set; }
    }
}