#nullable disable
using Microsoft.EntityFrameworkCore;
using TravelAgentBooking.Models;

namespace TravelAgentBooking.Data;

public class TravelAgentBookingContext : DbContext
{
    public TravelAgentBookingContext (DbContextOptions<TravelAgentBookingContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        //modelBuilder.Entity<BookingModel>().Navigation(i=>i.Bookingtypes.);
    }

    public DbSet<TravelAgentBooking.Models.BookingModel> BookingModel { get; set; }
}
