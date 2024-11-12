using AirlineManagement.Entities;
using AirlineManagement.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Data.Entity.Infrastructure;
using System.Security.Claims;

namespace AirlineManagement.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext _context;

        public AccountController(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }
        public IActionResult Index()
        {
            return View(_context.UserAccounts.ToList());
        }
        public IActionResult Registration() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult Registration(RegistrationViewModel model) 
        {
            if (ModelState.IsValid) 
            {
                //it is useful for you select which field you want to show
                UserAccount account = new UserAccount();
                account.Email = model.Email;
                account.UserName = model.UserName;
                account.Password = model.Password;
                account.FirstName = model.FirstName;
                account.LastName = model.LastName;

                try
                {
                    _context.UserAccounts.Add(account);
                    _context.SaveChanges();

                    ModelState.Clear();
                    ViewBag.Message = $"{account.FirstName} you are succesfully registered";
                }
                catch (DbUpdateException ex)
                {
                    ModelState.AddModelError("", "Please enter a unique username");

                    return View(model);
                    
                }

                return View();

            }



            return View(model);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid) 
            {
                var user = _context.UserAccounts.Where(x => x.UserName == model.UserName && x.Password == model.Password).FirstOrDefault();
                if (user != null) 
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, user.UserName),
                        new Claim("Name", user.FirstName),
                        new Claim(ClaimTypes.Role, "User"),
                    };
                    var claimsIdentity = new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);
                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,new ClaimsPrincipal(claimsIdentity));

                    return RedirectToAction("SecurePage","Account");
                }
                else
                {
                    ModelState.AddModelError("", "Plase enter valid username or password");
                }
            }
            return View(model);


        }
        [Authorize]
        public IActionResult SecurePage()
        {
            ViewBag.Name = HttpContext.User.Identity.Name;
            return View();
        }
    }
}
