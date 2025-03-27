using Microsoft.EntityFrameworkCore;
using BadmintonBookingSystemAPI.Models;
using System.Collections.Generic;

namespace BadmintonBookingSystemAPI.Data
{
    public class BadmintonBookingSystemContext : DbContext
    {
        public BadmintonBookingSystemContext(DbContextOptions<BadmintonBookingSystemContext> options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Booking> Bookings { get; set; }
    }
}