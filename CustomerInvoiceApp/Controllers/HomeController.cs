using CustomerInvoiceApp.Data;
using CustomerInvoiceApp.Models;
using CustomerInvoiceApp.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CustomerInvoiceApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var SalesList = _context.Invoices.GroupBy(x => x.Customers.Country).Select(i => new Sales
            {
                Country = i.Key,
                Amount = i.Sum(t => t.Amount)
            }).ToList();

            List<Sales> sales = SalesList;
            List<string> labels = sales.Select(x => x.Country).ToList();
            List<decimal> values = sales.Select(x => x.Amount).ToList();

            IndexVM vm = new IndexVM
            {
                Customers = _context.Customers.ToList(),
                Invoices = _context.Invoices.ToList(),
                SalesByCountry = sales,
                Labels = labels,
                Values = values
            };
            return View(vm);
        }
    }
}