using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LandlordRatings.Models;
using LandlordRatings.Data;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace LandlordRatings.Controllers
{
    public class RatingsController : Controller
    {

        private LandlordDbContext _context;

        public RatingsController(LandlordDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        // GET: /Ratings/Details/5 (unique ID, matches Landlord ID)
        public IActionResult Details(int? ID)
        {
            if (ID == null)
            {
                return NotFound();
            }
            else
            {
                List<RatingModel> ratingModels = _context.Ratings.Where(l => l.LandlordID == ID).ToList();
                return View(ratingModels);
            }
        }

        // GET: /Ratings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Ratings/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(RatingModel rating)
        {
            if (ModelState.IsValid)
            {
                _context.Ratings.Add(rating);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rating);
        }
    }
}
