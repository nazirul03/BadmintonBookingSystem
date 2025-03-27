using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BadmintonBookingSystemAPI.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using BadmintonBookingSystemAPI.Models;

namespace CustomerManagementAPI.Controllers
{
    [Route("[controller]")]
    public class CustomersController : Controller
    {
        private readonly BadmintonBookingSystemContext _context;

        public CustomersController(BadmintonBookingSystemContext context)
        {
            _context = context;
        }

        // GET: Students
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var customers = await _context.Customers.ToListAsync();
            return View(customers); // Returns the list view of students
        }

        // GET: Students/Details/5
        [HttpGet("Details/{id}")]
        public async Task<IActionResult> Details(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer); // Returns the details view of a specific student
        }

        // GET: Students/Create
        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View(); // Returns the view for creating a new student
        }

        // POST: Students/Create
        [HttpPost("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index)); // Redirects to the student list
            }
            return View(customer);
        }

        // GET: Students/Edit/5
        [HttpGet("Edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer); // Returns the edit view for a specific student
        }

        // POST: Students/Edit/5
        [HttpPost("Edit/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Customer customer)
        {
            if (id != customer.CustID)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerExists(id))
                    {
                        return NotFound();
                    }
                    throw;
                }
                return RedirectToAction(nameof(Index)); // Redirects to the student list
            }
            return View(customer);
        }

        // GET: Students/Delete/5
        [HttpGet("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer); // Returns the delete confirmation view
        }

        // POST: Students/Delete/5
        [HttpPost("Delete/{id}"), ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index)); // Redirects to the student list
        }

        private bool CustomerExists(int id)
        {
            return _context.Customers.Any(e => e.CustID == id);
        }
    }
}