using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LandlordRatings.Data;
using LandlordRatings.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace LandlordRatings.Controllers
{
    public class LandlordsController : Controller
    {

        private LandlordDbContext _context;

        public LandlordsController(LandlordDbContext context)
        {
            _context = context;
        }

        // GET: /Landlords?name=[letter]
        public IActionResult Index(string name = "")
        {
            if (name == "")
            {
                return View(_context.Landlords.ToList());
            } else
            {
                var query = from l in _context.Landlords
                            where l.LastName.ToLower().Contains(name.ToLower())
                            select l;
                return View(query.ToList());
            }
        }

        // GET: /Landlords?city=XXX&state=XXX
        [ActionName("SearchByCityState")]
        public IActionResult Index(string city = "", string state = "")
        {
            if (state == "" || city == "")
            {
                return View("Index", _context.Landlords.ToList());
            }
            else
            {
                var query = from l in _context.Landlords
                            where l.State == state &&
                            l.City == city
                            select l;
                return View("Index", query.ToList());
            }
        }

        // GET: /Landlords/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Landlords/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(LandlordModel landlord)
        {
            if (ModelState.IsValid)
            {
                _context.Landlords.Add(landlord);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(landlord);
        }

        // GET: /Landlords/5 (unique ID)
        public IActionResult Details(int? ID)
        {
            if (ID == null)
            {
                return NotFound();
            } else
            {
                LandlordModel lm = _context.Landlords.SingleOrDefault(l => l.LandlordID == ID);
                if (lm == null)
                {
                    return NotFound();
                }
                List<RatingModel> ratings = _context.Ratings.Where(r => r.LandlordID == ID).ToList();
                if (ratings != null)
                {
                    lm.Ratings = ratings;
                } else
                {
                    lm.Ratings = new List<RatingModel>();
                }
                return View(lm);
            }
        }
    }
}
