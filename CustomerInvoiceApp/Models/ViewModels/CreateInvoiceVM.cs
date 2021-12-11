using Microsoft.AspNetCore.Mvc.Rendering;

namespace CustomerInvoiceApp.Models.ViewModels
{
    public class CreateInvoiceVM
    {
        public Invoice Invoice { get; set; }
        public IEnumerable<SelectListItem> CustomerList { get; set; }
    }
}
