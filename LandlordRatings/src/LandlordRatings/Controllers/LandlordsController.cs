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

        // GET: /Landlords/[letter]
        public IActionResult Index(string letter)
        {
            if (letter == null)
            {
                return View(_context.Landlords.ToList());
            } else
            {
                return View(_context.Landlords.Select(l => l.Name.Contains(letter)));
            }
        }

        public IActionResult Create()
        {
            return View();
        }

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
    }
}
