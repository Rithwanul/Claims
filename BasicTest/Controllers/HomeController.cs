using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BasicTest.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult Secret()
        {
            return View();
        }

        public IActionResult Authenticate()
        {

            var gramdmaClaims = new List<Claim>() 
            { 
                new Claim(ClaimTypes.Name, "Dico"),
                new Claim(ClaimTypes.Email, "rithwanul@gmail.com"),
                new Claim("Grandma.Says", "I love you!!")
            };

            var licenceClaim = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, "Bob"),
                new Claim("DriverSkill", "A+")
            };

            var grandMaIdentity = new ClaimsIdentity(gramdmaClaims, "Grandma Identity");
            var licenceIdentity = new ClaimsIdentity(licenceClaim, "Government");

            var userPrinciple = new ClaimsPrincipal(new[] { grandMaIdentity, licenceIdentity });

            HttpContext.SignInAsync(userPrinciple);

            return RedirectToAction(nameof(Index));
        }
    }
}
