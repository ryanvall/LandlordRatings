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
            // Get 5 most recently added reveiws
            var mostRecentQuery = from r in _context.Ratings
                                  group r by r.DateAdded into mostrecent
                                  orderby mostrecent.Key
                                  select mostrecent;

            List<RatingModel> ratings = mostRecentQuery.Take(5).SelectMany(rating => rating).ToList();
            return View(ratings);
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
                LandlordModel lm = _context.Landlords.SingleOrDefault(n => n.ID == ID);
                if (lm == null)
                {
                    return NotFound();
                } else
                {
                    String name = lm.Name;
                    ViewData["LandlordName"] = name;
                    ViewData["LandlordID"] = ID;
                    List<RatingModel> ratingModels = _context.Ratings.Where(l => l.LandlordID == ID).ToList();
                    return View(ratingModels);
                }
            }
        }

        // GET: /Ratings/Create/2
        public IActionResult Create(int? ID)
        {
            if (ID == null)
            {
                return NotFound();
            } else
            {
                String name = _context.Landlords.SingleOrDefault(n => n.ID == ID).Name;
                ViewData["LandlordName"] = name;
                ViewData["LandlordID"] = ID;
                return View();
            }
        }

        // POST: /Ratings/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(RatingModel rating)
        {
            rating.DateAdded = DateTime.Now;
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
