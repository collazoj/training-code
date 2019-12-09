// Budget
// Bill
// Expense
// Goal
// Income 
// Member
// Tax

namespace Name
{
    public abstract class ABudget{
        public int Id { get; set; }
        public string Name { get; set; }
        public double Amount { get; set; }
        [ForeignKey("Budget")]
        public int? BudgetId { get; set; }
        public Budget Budget { get; set; }
    }
}