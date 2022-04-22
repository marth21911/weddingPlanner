using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using weddingPlanner.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace weddingPlanner.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private MyContext _context;

        public HomeController(ILogger<HomeController> logger, MyContext context)
        {
            _logger = logger;
            _context = context;
        }
        [HttpPost("adduser")]
        public IActionResult AddUser(User newUser)
        {
            if(ModelState.IsValid)
            {
                if(_context.Users.Any(a=> a.Email == newUser.Email))
                {
                    ModelState.AddModelError("Email", "Email is already in use");
                    return View("Index");
                }
                PasswordHasher<User> Hasher = new PasswordHasher<User>();
                newUser.Password = Hasher.HashPassword(newUser, newUser.Password);
                _context.Users.Add(newUser);
                _context.SaveChanges();
                HttpContext.Session.SetInt32("UserId", newUser.UserId);
                return RedirectToAction("Dashboard");
            } else{
                return View("Index");
            }
        }
        [HttpGet("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return View("Index");
        }
        [HttpGet("Dashboard")]
        public IActionResult Dashboard()
        {
            if(HttpContext.Session.GetInt32("UserId")==null)
            {
                return RedirectToAction("Index");
            }
            ViewBag.UserinSession = HttpContext.Session.GetInt32("UserId");
            ViewBag.Allweddings= 
            _context.Weddings.
            Include(a=>a.Attendees).
            ThenInclude(b=>User).
            ToList();
            return View();
        }
        [HttpGet("/delete/{WedId}")]
        public IActionResult DeleteWedding(int WedId)
        {
            if(HttpContext.Session.GetInt32("UserId")==null)
            {
                return RedirectToAction("Index");
            }
            Wedding wedToDelete = _context.Weddings.
            SingleOrDefault(a=>a.WeddingId == WedId);
            _context.Weddings.Remove(wedToDelete);
            _context.SaveChanges();
            return RedirectToAction("Dashboard");
        }
        [HttpGet ("unrsvp/{wedId}")]
        public IActionResult unRsvp(int wedId)
        {
            if(HttpContext.Session.GetInt32("UserId")==null)
            {
                return RedirectToAction("Index");
            }
        int UserinSession = (int) HttpContext.Session.GetInt32("UserId");
        var unRsvper = _context.SharedEvent.FirstOrDefault(a=>a.WeddingId == wedId && a.UserId == UserinSession);
        _context.SharedEvent.Remove(unRsvper);
        _context.SaveChanges();

            return RedirectToAction("Dashboard");
        }
        [HttpPost("rsvp")]
        public IActionResult Rsvp(Event newAttendee)
        {
            if(HttpContext.Session.GetInt32("UserId")==null)
            {
                return RedirectToAction("Index");
            }
            _context.SharedEvent.Add(newAttendee);
            _context.SaveChanges();
            return RedirectToAction("Dashboard");
        }
        [HttpPost("login")]
        public IActionResult Login(LogUser logUser)
        {
            if(ModelState.IsValid)
            {
                User userInDB = _context.Users.FirstOrDefault(a=> a.Email == logUser.LogEmail);
                if(userInDB == null)
                {
                    ModelState.AddModelError("LogEmail", "Invalid login credentials");
                    return View ("Index");
                }
                var hasher = new PasswordHasher<LogUser>();
                var result = hasher.VerifyHashedPassword(logUser, userInDB.Password, logUser.LogPassword);
                if(result ==0)
                {
                    ModelState.AddModelError("LogEmail", "Invalid login credentials");
                    return View ("Index");
                }
                HttpContext.Session.SetInt32("UserId", userInDB.UserId);
                return RedirectToAction("Dashboard");
            } else{
                return View("Index");
            }
        }
        [HttpGet("createWedding")]
        public IActionResult NewWedding()
        {
            if(HttpContext.Session.GetInt32("UserId")==null)
            {
                return RedirectToAction("Index");
            }
            ViewBag.UserinSession = HttpContext.Session.GetInt32("UserId");
            return View();
        }
        [HttpPost("wedding/create")]
        public IActionResult createWedding(Wedding newWedding)
        {
            if(HttpContext.Session.GetInt32("UserId")==null)
            {
                return RedirectToAction("Index");
            }
            if(ModelState.IsValid)
            {
                _context.Weddings.Add(newWedding);
                _context.SaveChanges();
                return Redirect($"/wedding/{newWedding.WeddingId}");
            } 
            return View ("NewWedding");
        }
        [HttpGet("wedding/{weddingId}")]
        public IActionResult ViewWedding( int weddingId)
        {
            if(HttpContext.Session.GetInt32("UserId")==null)
            {
                return RedirectToAction("Index");
            }
            ViewBag.OneWedding = 
            _context.Weddings.
            Include(a=>a.Attendees).
            ThenInclude(b=>b.User).
            FirstOrDefault(a=>a.WeddingId == weddingId);
            return View();
        }

        public IActionResult Index()
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
