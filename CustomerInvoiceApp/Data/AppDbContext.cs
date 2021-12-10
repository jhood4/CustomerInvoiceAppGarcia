using CustomerInvoiceApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomerInvoiceApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
    }
}
