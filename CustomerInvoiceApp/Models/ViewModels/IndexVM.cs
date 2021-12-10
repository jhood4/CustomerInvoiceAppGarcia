namespace CustomerInvoiceApp.Models.ViewModels
{
    public class IndexVM
    {
        public IEnumerable<Customer>? Customers { get; set; }
        public IEnumerable<Invoice>? Invoices { get; set; }
    }
}
