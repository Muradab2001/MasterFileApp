using MasterFile.DAL;
using MasterFile.Models;
using MasterFile.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Mail;
using System.Net;

namespace MasterFile.Controllers
{
    public class AccountController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _context;
        private readonly SignInManager<AppUser> _signInManager;

        private readonly UserManager<AppUser> _userManager;


        public AccountController(RoleManager<IdentityRole> roleManager, ApplicationDbContext context, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {

            _roleManager = roleManager;
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        //public async Task CreateRoles()
        //{
        //    await _roleManager.CreateAsync(new IdentityRole("Member"));
        //    await _roleManager.CreateAsync(new IdentityRole("Moderator"));
        //    await _roleManager.CreateAsync(new IdentityRole("Admin"));
        //}
        public IActionResult login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginVM login)
        {
            if (login.Password == null || login.UserName == null)
            {

                ModelState.AddModelError("", "Username or password is incorrect");
                return View();
            }


            AppUser user = await _userManager.FindByNameAsync(login.UserName);

            if (user == null)
            {
                ModelState.AddModelError("", "Username or password is incorrect");
                return View();
            }
            Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(user.UserName, login.Password, true, true);

            if (!result.Succeeded)
            {
                if (result.IsLockedOut)
                {
                    ModelState.AddModelError("", "Your account is blocked because you write wrong password or username.You try after 5 minutes");
                    return View();
                }
                ModelState.AddModelError("", "Username or password is incorrect");
                return View();

            }
            _context.SaveChanges();
            return RedirectToAction("index", "Home");
        }

		//[HttpGet]
		//[AutoValidateAntiforgeryToken]
		//public async Task<IActionResult> Register()
		//{
		//	if (!ModelState.IsValid) return View();

		//	AppUser user = new AppUser
		//	{
  //              UserName="Murad",
		//		Email = "Murad@gmail.com"
		//	};
		
		//	IdentityResult result = await _userManager.CreateAsync(user, "Murad2121");
		//	await _signInManager.SignInAsync(user, isPersistent: false);
		//	await _userManager.AddToRoleAsync(user, "Admin");
		//	TempData["Verify"] = true;
		//	await _signInManager.SignOutAsync();
		//	return RedirectToAction("Index", "Home");
		//}

	}
}
