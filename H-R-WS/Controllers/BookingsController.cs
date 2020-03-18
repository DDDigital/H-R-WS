using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using H_R_WS.Data;
using H_R_WS.Models;
using H_R_WS.Services;

namespace H_R_WS.Controllers
{
    public class BookingsController : Controller
    {
        private readonly IGenericHotelService<Booking> _hotelService;

        public BookingsController(IGenericHotelService<Booking> genericHotelService)
        {
            _hotelService = genericHotelService;
        }

        // GET: Bookings
        public async Task<IActionResult> Index()
        {
            return View(await _hotelService.GetAllItemsAsync());
        }

        // GET: Bookings/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = await _hotelService.GetItemByIdAsync(id);


            if (booking == null)
            {
                return NotFound();
            }


            return View(booking);
        }

            // GET: Bookings/Create
            public IActionResult Create()
        {
            return View();
        }

        // POST: Bookings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,RoomID,DateCreated,CheckIn,CheckOut,Guests,TotalFee,Paid,Completed,ApplicationUserId,CustomerName,CustomerEmail,CustomerPhone,CustomerAddress,CustomerCity,OtherRequests")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                booking.ID = Guid.NewGuid().ToString();
                await _hotelService.CreateItemAsync(booking);
                return RedirectToAction(nameof(Index));
            }
            return View(booking);
        }

        // GET: Bookings/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = await _hotelService.GetItemByIdAsync(id);

            var rooms = _hotelService.GetAllRoomsWithFeature(id);
            ViewData["RoomsWithFeature"] = rooms;
            if (booking == null)
            {
                return NotFound();
            }
            return View(booking);
        }

        // POST: Bookings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ID,RoomID,DateCreated,CheckIn,CheckOut,Guests,TotalFee,Paid,Completed,ApplicationUserId,CustomerName,CustomerEmail,CustomerPhone,CustomerAddress,CustomerCity,OtherRequests")] Booking booking)
        {
            if (id != booking.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _hotelService.EditItemAsync(booking);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (_hotelService.GetItemByIdAsync(id) == null)
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
            return View(booking);
        }

        // GET: Bookings/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = await _hotelService.GetItemByIdAsync(id);
            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }

        // POST: Bookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var booking = await _hotelService.GetItemByIdAsync(id);
            await _hotelService.DeleteItemAsync(booking);
            return RedirectToAction(nameof(Index));
        }

    }
}
