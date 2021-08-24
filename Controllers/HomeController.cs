using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WeddingPlanner.Models;

namespace WeddingPlanner.Controllers
{
    public class HomeController : Controller
    {
        private MyContext _context;
        public HomeController(MyContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("register")]
        public IActionResult Register(User newUser)
        {
            if(ModelState.IsValid)
            {
                if(_context.Users.Any(user => user.Email == newUser.Email))
                {
                    ModelState.AddModelError("Email", "This Email is already in use");
                    return View("Index");
                }

                PasswordHasher<User> Hasher = new PasswordHasher<User>();
                newUser.Password = Hasher.HashPassword(newUser, newUser.Password);
                _context.Users.Add(newUser);
                _context.SaveChanges();
                return RedirectToAction("Dashboard");
            }
            return View("Index");
        }

        [HttpPost("loggingIn")]
        public IActionResult LoggingIn(LoginUser login)
        {
            if(ModelState.IsValid)
            {
                User userInDb = _context.Users.FirstOrDefault(user => user.Email == login.LoginEmail);
                if(userInDb == null)
                {
                    ModelState.AddModelError("LoginEmail", "Invalid Login");

                    return View("Index");
                }
                PasswordHasher<LoginUser> hasher = new PasswordHasher<LoginUser>();

                var result = hasher.VerifyHashedPassword(login, userInDb.Password, login.LoginPassword);

                if(result == 0)
                {
                    ModelState.AddModelError("LoginEmail", "Invalid Login");

                    return View("Index");
                }

                HttpContext.Session.SetInt32("userId", userInDb.UserId);
                return RedirectToAction("Dashboard");
            }
            return View("Index");
        }

        [HttpGet("dashboard")]
        public IActionResult Dashboard(int UserId)
        {
            
            int? loggedUserId = HttpContext.Session.GetInt32("userId");
            if(loggedUserId == null) return RedirectToAction("Index");

            ViewBag.AllWeddings = _context.Weddings.Include(w => w.Guests)
            .ToList();

            ViewBag.User = loggedUserId;

            // ViewBag.Attend = _context.RSVPs

            return View();
        }

        [HttpGet("/wedding/{id}/delete")]
        public IActionResult DeleteWedding(int id)
        {
            Wedding delete = _context.Weddings
            .FirstOrDefault(e => e.WeddingId == id);

            _context.Weddings.Remove(delete);
            _context.SaveChanges();
            return RedirectToAction("Dashboard");
        }


        [HttpGet("/wedding/{id}/rsvp")]
        public IActionResult AddGuest(int id)
        {
            int loggedUserId = (int) HttpContext.Session.GetInt32("userId");

            RSVP guest = new RSVP();
            guest.UserId = loggedUserId;
            guest.WeddingId = id;
            _context.RSVPs.Add(guest);
            _context.SaveChanges();
            return RedirectToAction("Dashboard");
        }

        [HttpGet("/rsvp/{id}/remove")]
        public IActionResult RemoveRSVP(int id)
        {
            int? Person = HttpContext.Session.GetInt32("userId");
            RSVP Remove = _context.RSVPs
            .FirstOrDefault(v => v.WeddingId == id && v.UserId == Person);

            _context.RSVPs.Remove(Remove);
            _context.SaveChanges();
            return RedirectToAction("Dashboard");
        }

        [HttpGet("planwedding")]
        public IActionResult PlanWedding()
        {
            int? loggedUserId = HttpContext.Session.GetInt32("userId");
            if(loggedUserId == null) return RedirectToAction("Index");

            return View();
        }

        [HttpPost("submit")]
        public IActionResult Submit(Wedding newWedding)
        {
            int? loggedUserId = HttpContext.Session.GetInt32("userId");
            if(loggedUserId == null) return RedirectToAction("Index");

            if(ModelState.IsValid)
            {
            newWedding.UserId = (int)loggedUserId;
            _context.Add(newWedding);
            _context.SaveChanges();
            }

            return RedirectToAction("OneWedding");
        }

        [HttpGet("/wedding/{id}")]
        public IActionResult OneWedding(int id)
        {
            int? loggedUserId = HttpContext.Session.GetInt32("userId");
            if(loggedUserId == null) return RedirectToAction("Index");

            ViewBag.OneWed =_context.Weddings
            .Include(w => w.Guests)
            .ThenInclude(r => r.User)
            .FirstOrDefault(w => w.WeddingId == id);
            ViewBag.AllWeddings = _context.Weddings
            .ToList();

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
