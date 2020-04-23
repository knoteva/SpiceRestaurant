﻿using Microsoft.EntityFrameworkCore;

namespace SpiceHouse.Web.Areas.Administration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using SpiceHouse.Data;
    using SpiceHouse.Data.Models;

    [Area("Administration")]
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;

        // Create constructor
        public CategoryController(ApplicationDbContext db)
        {
            this._db = db;
        }

        // GET: Pass all to the view.
        public async Task<IActionResult> Index()
        {
            return this.View(await this._db.Categories.ToListAsync());
        }

        // GET: Create
        public IActionResult Create()
        {
            return this.View();
        }

        // POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category category)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(category);
            }

            this._db.Categories.Add(category);
            await this._db.SaveChangesAsync();

            return this.RedirectToAction(nameof(this.Index));
        }

        // GET: Edit
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var category = await this._db.Categories.FindAsync(id);
            if (category == null)
            {
                return this.NotFound();
            }

            return this.View(category);
        }

        // POST: Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Category category)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(category);
            }

            this._db.Update(category);
            await this._db.SaveChangesAsync();

            return this.RedirectToAction(nameof(this.Index));
        }

        // GET: Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var category = await this._db.Categories.FindAsync(id);
            if (category == null)
            {
                return this.NotFound();
            }

            return this.View(category);
        }

        // POST: Delete
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var category = await this._db.Categories.FindAsync(id);

            if (category == null)
            {
                return this.View();
            }

            this._db.Categories.Remove(category);
            await this._db.SaveChangesAsync();
            return this.RedirectToAction(nameof(this.Index));
        }

        //GET Details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var category = await this._db.Categories.FindAsync(id);
            if (category == null)
            {
                return this.NotFound();
            }

            return this.View(category);
        }
    }

}