using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using StoreProject.EntityLayer.Concrete;
using StoreProject.PresentationLayer.Models;
using System.Threading.Tasks;

namespace StoreProject.PresentationLayer.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }



        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> Index(RegisterViewModel model)
        {
            AppUser appUser = new AppUser
            {
                Email = model.Mail,
                UserName = model.Username,
                Name = model.Name,
                Surnamne = model.Surname
            };
            var result = await _userManager.CreateAsync(appUser, model.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                ViewBag.message = "Hatalı bir şeyler var";
                return View();
            }
        }
    }
}
