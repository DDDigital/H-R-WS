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
    public class RoomsController : Controller
    {
        private readonly IGenericHotelService<Room> _RoomService;

        public RoomsController(IGenericHotelService<Room> genericHotelService)
        {
            _RoomService = genericHotelService;
        }

        // GET: Rooms
        public IActionResult Index()
        {
            return View(_RoomService.GetAllRoomsAndRoomTypes());
        }
        // GET: Rooms/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roomType = await _RoomService.GetItemByIdAsync(id);

            if (roomType == null)
            {
                return NotFound();
            }
            return View(roomType);
        }

        // GET: Rooms/Create
        public IActionResult Create()
        {
            var RoomTypes = _RoomService.GetAllRoomTypesAsync().Result;
            ViewData["RoomTypeID"] = new SelectList(RoomTypes, "ID", "Name");
            return View();
        }

        // POST: Rooms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Number,RoomTypeID,Price,Available,Description,MaximumGuests")] Room room)
        {
            if (ModelState.IsValid)
            {
                room.ID = Guid.NewGuid();
                await _RoomService.CreateItemAsync(room);
                return RedirectToAction(nameof(Index));
            }
            return View(room);
        }

        // GET: Rooms/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roomType = await _RoomService.GetItemByIdAsync(id);
            if (roomType == null)
            {
                return NotFound();
            }
            return View(roomType);
        }

        // POST: Rooms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ID,Number,RoomTypeID,Price,Available,Description,MaximumGuests")] Room room)
        {
            if (id != room.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _RoomService.EditItemAsync(room);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (_RoomService.GetItemByIdAsync(id) == null)
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
            return View(room);
        }

        // GET: Rooms/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roomType = await _RoomService.GetItemByIdAsync(id);
            if (roomType == null)
            {
                return NotFound();
            }

            return View(roomType);
        }

        // POST: Rooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var roomType = await _RoomService.GetItemByIdAsync(id);
            await _RoomService.DeleteItemAsync(roomType);
            return RedirectToAction(nameof(Index));
        }
        /*
        private bool RoomExists(Guid id)
        {
            return _RoomService.Rooms.Any(e => e.ID == id);
        }
        */
    }
}
