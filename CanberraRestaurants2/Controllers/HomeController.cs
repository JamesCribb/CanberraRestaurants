using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CanberraRestaurants2.Data;
using Microsoft.EntityFrameworkCore;


namespace CanberraRestaurants2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        // As with the Reviews page, need to modify this method to display information from database
        // Use LINQ to sort list of reviews by date before displaying it
        public async Task<IActionResult> Cuisine()
        {
            var allReviews = from review in _context.Review orderby review.SubmissionDate descending select review;

            return View(await allReviews.ToListAsync());

            // return View(await _context.Review.ToListAsync());
        }

        public IActionResult Dishes()
        {
            return View();
        }

        public IActionResult Location()
        {
            return View();
        }

        public IActionResult Price()
        {
            return View();
        }

        public IActionResult Restaurants()
        {
            return View();
        }

        // New controller method for display review information on reviews page

        public async Task<IActionResult> Reviews()
        {
            return View(await _context.Review.ToListAsync());
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}