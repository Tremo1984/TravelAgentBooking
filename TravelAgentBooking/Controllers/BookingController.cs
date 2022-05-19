#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TravelAgentBooking.Data;
using TravelAgentBooking.Models;

namespace TravelAgentBooking.Controllers;

public class BookingController : Controller
{
    private readonly TravelAgentBookingContext _context;

    public BookingController(TravelAgentBookingContext context)
    {
        _context = context;
    }

    // GET: Booking
    public async Task<IActionResult> Index()
    {
        return View(await _context.BookingModel.ToListAsync());
    }

    // GET: Booking/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var bookingModel = await _context.BookingModel
            .FirstOrDefaultAsync(m => m.Id == id);
        if (bookingModel == null)
        {
            return NotFound();
        }

        return View(bookingModel);
    }

    // GET: Booking/Create
    public IActionResult Create()
    {
        BookingModel bookingModel = new BookingModel();

        var bookingTypes = new List<SelectListItem>();
        int i = 1;
        bookingTypes.Add(new SelectListItem { Value = "0", Text = "Select Booking", Selected = true });

        foreach (var item in Enum.GetValues(typeof(BookingType)))
        {
            bookingTypes.Add(new SelectListItem { Value = i.ToString(), Text = item.ToString() });
            i++;
        }

        bookingModel.Bookingtypes = bookingTypes.AsEnumerable().OrderBy(i => i.Value);
        return View(bookingModel);
    }

    // POST: Booking/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,BookingType,NumberOfNights,NumberTravling,PricePerNight,TotalPrice,StartDate,EndDate,Destination")] BookingModel bookingModel)
    {
        if (ModelState.IsValid)
        {
            _context.Add(bookingModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(bookingModel);
    }

    // GET: Booking/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var bookingModel = await _context.BookingModel.FindAsync(id);
        if (bookingModel == null)
        {
            return NotFound();
        }
        return View(bookingModel);
    }

    // POST: Booking/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,BookingType,NumberOfNights,NumberTravling,PricePerNight,TotalPrice,StartDate,EndDate,Destination")] BookingModel bookingModel)
    {
        if (id != bookingModel.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(bookingModel);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookingModelExists(bookingModel.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        return View(bookingModel);
    }

    // GET: Booking/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var bookingModel = await _context.BookingModel
            .FirstOrDefaultAsync(m => m.Id == id);
        if (bookingModel == null)
        {
            return NotFound();
        }

        return View(bookingModel);
    }

    // POST: Booking/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var bookingModel = await _context.BookingModel.FindAsync(id);
        _context.BookingModel.Remove(bookingModel);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool BookingModelExists(int id)
    {
        return _context.BookingModel.Any(e => e.Id == id);
    }
}
