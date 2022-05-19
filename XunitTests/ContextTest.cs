using System;
using Microsoft.EntityFrameworkCore;
using TravelAgentBooking.Data;
using Xunit;

namespace XunitTests
{
    public class ContextTest
    {
        [Fact]
        public void BuildContextTest()
        {
            var optionsBuilder = new DbContextOptionsBuilder<TravelAgentBookingContext>();
            optionsBuilder.UseInMemoryDatabase(nameof(TravelAgentBookingContext));
            var context = new TravelAgentBookingContext(optionsBuilder.Options);

            Assert.NotNull(context);
        }

        [Fact]
        public void AddTest()
        {
            var optionsBuilder = new DbContextOptionsBuilder<TravelAgentBookingContext>();
            optionsBuilder.UseInMemoryDatabase<TravelAgentBookingContext>(nameof(TravelAgentBookingContext));
            var context = new TravelAgentBookingContext(optionsBuilder.Options);

            var model = new TravelAgentBooking.Models.BookingModel();
            model.BookingType = TravelAgentBooking.Models.BookingType.UK;
            model.Destination = "Stockton";
            model.StartDate = System.DateTime.Now;
            model.EndDate = System.DateTime.Now.AddDays(7);
            model.NumberOfNights = model.EndDate.Day - model.StartDate.Day;
            model.NumberTravling = 7;
            model.PricePerNight = 99.99m;
            model.TotalPrice = model.PricePerNight * model.NumberOfNights;            

            context.BookingModel.Add(model);
            context.SaveChanges();

            Assert.True(context.BookingModel.AnyAsync().Result);
        }
    }
}