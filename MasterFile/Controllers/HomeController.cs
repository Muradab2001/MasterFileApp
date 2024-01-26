using MasterFile.DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace MasterFile.Controllers
{
	[Authorize(Roles = "Admin")]
	public class HomeController : Controller
    {
		private readonly ApplicationDbContext _context;

		public HomeController(ApplicationDbContext context)
		{
			_context = context;
		}
		public IActionResult Index()
        {
			ViewBag.MyDate = new DateTime(2022, 01, 01);
			ViewBag.Projects=_context.Projects.Count();
			return View();
		}
    }
}
