using CustomerInvoiceApp.Data;
using CustomerInvoiceApp.Models;
using CustomerInvoiceApp.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CustomerInvoiceApp.Controllers
{
    public class InvoicesController : Controller
    {
        private readonly AppDbContext _context;
        public InvoicesController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Create()
        {
            CreateInvoiceVM vm = new CreateInvoiceVM
            {
                Invoice = new Invoice(),
                CustomerList = _context.Customers.Select(x => new SelectListItem
                {
                    Text = $"{x.FirstName} {x.LastName}",
                    Value = x.Id.ToString()
                })
            };
            return View(vm);
        }

        [HttpPost]
        public IActionResult Create(Invoice invoice)
        {
            invoice.InvoiceDate = DateTime.Now;
            _context.Invoices.Add(invoice);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Edit(string id)
        {
            CreateInvoiceVM vm = new CreateInvoiceVM
            {
                Invoice = _context.Invoices.FirstOrDefault(x => x.Id.ToString() == id),
                CustomerList = _context.Customers.Select(x => new SelectListItem
                {
                    Text = $"{x.FirstName} {x.LastName}",
                    Value = x.Id.ToString()
                })
            };
            return View(vm);
        }

        [HttpPost]
        public IActionResult Edit(Invoice invoice)
        {
            _context.Invoices.Update(invoice);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Delete(string id)
        {
            var invoice = _context.Invoices.FirstOrDefault(x => x.Id.ToString() == id);
            _context.Invoices.Remove(invoice);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}
