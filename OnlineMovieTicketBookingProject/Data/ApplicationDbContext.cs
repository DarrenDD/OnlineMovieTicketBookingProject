using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineMovieTicketBookingProject.Models;

namespace OnlineMovieTicketBookingProject.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<BookingTable> BookingTable { get; set; }
        public DbSet<MovieDetails> MovieDetails { get; set; }
        public DbSet<Cart> Cart { get; set; }
    }
}