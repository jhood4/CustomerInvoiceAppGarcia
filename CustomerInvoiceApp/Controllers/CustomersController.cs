using CustomerInvoiceApp.Data;
using CustomerInvoiceApp.Models;
using CustomerInvoiceApp.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CustomerInvoiceApp.Controllers
{
    public class CustomersController : Controller
    {
        private readonly AppDbContext _context;
        public CustomersController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult GetCustomerAndInvoices(string id)
        {
            Customer customer = _context.Customers.Where(x => x.Id.ToString() == id).Include("Invoices").FirstOrDefault();
            return View(customer);
        }
        public IActionResult Create()
        {
            Customer customer = new Customer();
            return View(customer);
        }

        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Edit(string id)
        {
            Customer customer = _context.Customers.FirstOrDefault(x => x.Id.ToString() == id);
            return View(customer);
        }

        [HttpPost]
        public IActionResult Edit(Customer customer)
        {
            _context.Customers.Update(customer);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Delete(string id)
        {
            var customer = _context.Customers.FirstOrDefault(x =>x.Id.ToString() == id);
            _context.Customers.Remove(customer);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}
