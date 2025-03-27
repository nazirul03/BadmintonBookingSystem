using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BadmintonBookingSystemAPI.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using BadmintonBookingSystemAPI.Models;

namespace CustomerManagementAPI.Controllers
{
    [Route("[controller]")]
    public class BookingsController : Controller
    {
        private readonly BadmintonBookingSystemContext _context;

        public BookingsController(BadmintonBookingSystemContext context)
        {
            _context = context;
        }

        // GET: Subjects
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var bookings = await _context.Bookings.ToListAsync();
            return View(bookings); // Returns the list view of subjects
        }

        // GET: Subjects/Details/5
        [HttpGet("Details/{id}")]
        public async Task<IActionResult> Details(int id)
        {
            var booking = await _context.Bookings.FindAsync(id);
            if (booking == null)
            {
                return NotFound();
            }

            return View(booking); // Returns the details view of a specific subject
        }

        // GET: Subjects/Create
        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View(); // Returns the view for creating a new subject
        }

        // POST: Subjects/Create
        [HttpPost("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Booking booking)
        {
            if (ModelState.IsValid)
            {
                _context.Add(booking);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index)); // Redirects to the subject list
            }
            return View(booking);
        }

        // GET: Subjects/Edit/5
        [HttpGet("Edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var booking = await _context.Bookings.FindAsync(id);
            if (booking == null)
            {
                return NotFound();
            }
            return View(booking); // Returns the edit view for a specific subject
        }

        // POST: Subjects/Edit/5
        [HttpPost("Edit/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Booking booking)
        {
            if (id != booking.BookID)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(booking);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookingExists(id))
                    {
                        return NotFound();
                    }
                    throw;
                }
                return RedirectToAction(nameof(Index)); // Redirects to the subject list
            }
            return View(booking);
        }

        // GET: Subjects/Delete/5
        [HttpGet("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var booking = await _context.Bookings.FindAsync(id);
            if (booking == null)
            {
                return NotFound();
            }

            return View(booking); // Returns the delete confirmation view
        }

        // POST: Subjects/Delete/5
        [HttpPost("Delete/{id}"), ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var booking = await _context.Bookings.FindAsync(id);
            if (booking != null)
            {
                _context.Bookings.Remove(booking);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index)); // Redirects to the subject list
        }

        private bool BookingExists(int id)
        {
            return _context.Bookings.Any(e => e.BookID == id);
        }
    }
}