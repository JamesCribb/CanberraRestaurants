using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CanberraRestaurants2.Data;
using CanberraRestaurants2.Models;
using Microsoft.AspNetCore.Authorization;

namespace CanberraRestaurants2.Controllers
{
    public class ReviewsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReviewsController(ApplicationDbContext context)
        {

            _context = context;

        }

        // GET: Reviews
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Review.ToListAsync());
        }

        // GET: Reviews/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var review = await _context.Review
                .SingleOrDefaultAsync(m => m.Id == id);
            if (review == null)
            {
                return NotFound();
            }

            return View(review);
        }

        // GET: Reviews/Create
        [Authorize(Roles = "Manager, RegisteredUser")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Reviews/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SubmissionDate, Agrees,Disagrees,Date,Name,Heading,Restaurant,Comment,Rating")] Review review)
        {
            if (ModelState.IsValid)
            {
                _context.Add(review);
                await _context.SaveChangesAsync();
                return RedirectToAction("Reviews", "Home");
            }
            return View(review);
        }

        // GET: Reviews/Edit/5
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var review = await _context.Review.SingleOrDefaultAsync(m => m.Id == id);
            if (review == null)
            {
                return NotFound();
            }
            return View(review);
        }

        // POST: Reviews/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SubmissionDate,Agrees,Disagrees,Date,Name,Heading,Restaurant,Comment,Rating")] Review review)
        {

            if (id != review.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(review);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReviewExists(review.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Reviews", "Home");
            }
            return View(review);
        }

        // GET: Reviews/Delete/5
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var review = await _context.Review
                .SingleOrDefaultAsync(m => m.Id == id);
            if (review == null)
            {
                return NotFound();
            }

            return View(review);
        }

        // POST: Reviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var review = await _context.Review.SingleOrDefaultAsync(m => m.Id == id);
            _context.Review.Remove(review);
            await _context.SaveChangesAsync();
            return RedirectToAction("Reviews", "Home");
        }

        private bool ReviewExists(int id)
        {
            return _context.Review.Any(e => e.Id == id);
        }

        // No View: Reviews/IncrementAgrees/5
        [Authorize(Roles = "Manager, RegisteredUser")]
        public async Task<IActionResult> IncrementAgrees(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var review = await _context.Review.SingleOrDefaultAsync(m => m.Id == id);

            if (review == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    // If the agree/disagree button has already been clicked for this review, do nothing
                    if (review.ChangedThisSession)
                    {
                        return RedirectToAction("Reviews", "Home");
                    }
                    else
                    {
                        int totalAgrees = review.Agrees + 1;
                        review.Agrees = totalAgrees;
                        review.ChangedThisSession = true;   // flag as changed
                        _context.Update(review);
                        await _context.SaveChangesAsync();
                    }

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReviewExists(review.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return RedirectToAction("Reviews", "Home");
        }

        // No View: Reviews/IncrementDisagrees/5
        [Authorize(Roles = "Manager, RegisteredUser")]
        public async Task<IActionResult> IncrementDisagrees(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var review = await _context.Review.SingleOrDefaultAsync(m => m.Id == id);

            if (review == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    // If the agree/disagree button has already been clicked for this review, do nothing
                    if (review.ChangedThisSession)
                    {
                        return RedirectToAction("Reviews", "Home");
                    }
                    else
                    {
                        int totalDisagrees = review.Disagrees + 1;
                        review.Disagrees = totalDisagrees;
                        review.ChangedThisSession = true;
                        _context.Update(review);
                        await _context.SaveChangesAsync();
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReviewExists(review.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return RedirectToAction("Reviews", "Home");
        }
    }
}
