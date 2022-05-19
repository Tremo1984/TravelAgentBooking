using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TravelAgentBooking.Models;

public sealed class BookingModel
{
    public int Id { get; set; }
    public BookingType BookingType { get; set; }
    public int NumberOfNights { get; set; }
    public int NumberTravling { get; set; }
    public decimal PricePerNight { get; set; }
    public decimal TotalPrice { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    [Required]
    public string Destination { get; set; }
        
    [NotMapped]    
    public IEnumerable<SelectListItem> Bookingtypes { get; set; }
}
