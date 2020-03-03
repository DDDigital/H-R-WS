﻿using System;
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
    public class RoomTypesController : Controller
    {
        private readonly IGenericHotelService<RoomType> _roomTypeService;
        public RoomTypesController(IGenericHotelService<RoomType> roomTypeService)
        {
            _roomTypeService = roomTypeService;
        }

        // GET: RoomTypes
        public async Task<IActionResult> Index()
        {
            return View(await _roomTypeService.GetAllItemsAsync());
        }

        // GET: RoomTypes/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roomType = await _roomTypeService.GetItemByIdAsync(id);

            if (roomType == null)
            {
                return NotFound();
            }
            return View(roomType);
        }

        // GET: RoomTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RoomTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,BasePrice,Description,ImageUrl")] RoomType roomType)
        {
            if (ModelState.IsValid)
            {
                roomType.ID = Guid.NewGuid().ToString();
                await _roomTypeService.CreateItemAsync(roomType);
                return RedirectToAction(nameof(Index));
            }
            return View(roomType);
        }

        // GET: RoomTypes/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roomType = await _roomTypeService.GetItemByIdAsync(id);
            if (roomType == null)
            {
                return NotFound();
            }
            return View(roomType);
        }

        // POST: RoomTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ID,Name,BasePrice,Description,ImageUrl")] RoomType roomType)
        {
            if (id != roomType.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _roomTypeService.EditItemAsync(roomType);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (_roomTypeService.GetItemByIdAsync(id) == null)
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
            return View(roomType);
        }

        // GET: RoomTypes/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roomType = await _roomTypeService.GetItemByIdAsync(id);
            if (roomType == null)
            {
                return NotFound();
            }

            return View(roomType);
        }

        // POST: RoomTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var roomType = await _roomTypeService.GetItemByIdAsync(id);
            await _roomTypeService.DeleteItemAsync(roomType);
            return RedirectToAction(nameof(Index));
        }

       
    }
}
