namespace CustomerInvoiceApp.Models.ViewModels
{
    public class IndexVM
    {
        public IEnumerable<Customer>? Customers { get; set; }
        public IEnumerable<Invoice>? Invoices { get; set; }
        public IEnumerable<Sales>? SalesByCountry { get; set; }
        public List<string> Labels { get; set; }
        public List<decimal> Values { get; set; }
    }
}
