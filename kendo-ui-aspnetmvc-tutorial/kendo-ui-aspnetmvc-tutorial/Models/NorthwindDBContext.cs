using System.Data.Entity;


namespace KendoQsBoilerplate
{
    public class NorthwindDBContext : DbContext
    {
        public NorthwindDBContext() : base("NorthwindDB")
        { }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<OrderDetails> Order_Details { get; set; }
    }
}
