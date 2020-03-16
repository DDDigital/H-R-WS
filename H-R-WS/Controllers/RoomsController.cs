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
        public async Task<IActionResult> Details(string id)
        {
            var room = await _RoomService.GetItemByIdAsync(id);

            if (room == null)
            {
                return NotFound();
            }

            var ImagesAndFeatures = await _RoomService.GetRoomFeaturesAndImagesAsync(room);
            ViewData["Features"] = ImagesAndFeatures.Features;
            ViewData["Images"] = ImagesAndFeatures.Images;
            return View(room);
        }

        // GET: Rooms/Create
        public IActionResult Create()
        {
            var Room = _RoomService.GetAllRoomTypesAsync().Result;
            ViewData["RoomTypeID"] = new SelectList(Room, "ID", "Name");
            var room = new Room();
            ViewData["Features"] = _RoomService.PopulateSelectedFeaturesForRoom(room);
            return View();
        }

        // POST: Rooms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Number,RoomTypeID,Price,Available,Description,MaximumGuests")] Room room, string[] SelectedFeatureIDs, string[] imageIDs)
        {
            if (ModelState.IsValid)
            {
                room.ID = Guid.NewGuid().ToString();
                await _RoomService.CreateItemAsync(room);
                _RoomService.UpdateRoomFeaturesList(room, SelectedFeatureIDs);
                _RoomService.UpdateRoomImagesList(room, imageIDs);
                return RedirectToAction(nameof(Index));
            }
            ViewData["Features"] = _RoomService.PopulateSelectedFeaturesForRoom(room);
            var ImagesAndFeatures = await _RoomService.GetRoomFeaturesAndImagesAsync(room);
            ViewData["Images"] = ImagesAndFeatures.Images;
            return View(room);
        }

        // GET: Rooms/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var room = await _RoomService.GetItemByIdAsync(id);
            if (room == null)
            {
                return NotFound();
            }
            var RoomTypes = _RoomService.GetAllRoomTypesAsync().Result;
            ViewData["RoomTypeID"] = new SelectList(RoomTypes, "ID", "Name", room.RoomType.ID);

            ViewData["Features"] = _RoomService.PopulateSelectedFeaturesForRoom(room);
            var ImagesAndFeatures = await _RoomService.GetRoomFeaturesAndImagesAsync(room);
            ViewData["Images"] = ImagesAndFeatures.Images;
            return View(room);
        }

        // POST: Rooms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ID,Number,RoomTypeID,Price,Available,Description,MaximumGuests")] Room room, string[] SelectedFeatureIDs, string[] imageIDs)
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
                    _RoomService.UpdateRoomFeaturesList(room, SelectedFeatureIDs);
                    _RoomService.UpdateRoomImagesList(room, imageIDs);
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
            var RoomTypes = _RoomService.GetAllRoomTypesAsync().Result;
            ViewData["RoomTypeID"] = new SelectList(RoomTypes, "ID", "ID", room.RoomTypeID);
            ViewData["Features"] = _RoomService.PopulateSelectedFeaturesForRoom(room);
            var ImagesAndFeatures = await _RoomService.GetRoomFeaturesAndImagesAsync(room);
            ViewData["Images"] = ImagesAndFeatures.Images;
            return View(room);
        }

        // GET: Rooms/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var room = await _RoomService.GetItemByIdAsync(id);
            if (room == null)
            {
                return NotFound();
            }

            return View(room);
        }

        // POST: Rooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var room = await _RoomService.GetItemByIdAsync(id);
            await _RoomService.DeleteItemAsync(room);
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
