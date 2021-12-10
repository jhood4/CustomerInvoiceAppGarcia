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
            IndexVM vm = new IndexVM
            {
                Customers = _context.Customers.ToList(),
                Invoices = _context.Invoices.ToList()
            };
            return View(vm);
        }
    }
}