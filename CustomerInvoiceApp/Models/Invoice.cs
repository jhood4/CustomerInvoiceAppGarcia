namespace CustomerInvoiceApp.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public decimal Amount { get; set; }
        public DateTime InvoiceDate { get; set; }
        public Customer Customers { get; set; }
    }
}
