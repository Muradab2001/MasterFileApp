using MasterFile.DAL;
using MasterFile.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Linq;

namespace MasterFile.Controllers
{
	[Authorize(Roles = "Admin")]

	public class ProjectController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProjectController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(DateTime? StartDate, DateTime? EndDate, int page = 1)
        {

            List<Project> projects;
            ViewBag.CurrentPage = page;
            ViewBag.StartDate = StartDate;
            ViewBag.EndDate = EndDate;

            if (StartDate.HasValue && EndDate.HasValue)
            {
               
                projects = _context.Projects
                    .Where(p => p.createDate > StartDate && p.createDate <= EndDate).Skip((page - 1) * 4).Take(4)
                    .ToList();
            }
            else
            {
                projects = _context.Projects.Skip((page - 1) * 4).Take(4).ToList();
            }


            return View(projects);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(Project project)
        {
            if (!ModelState.IsValid) return View();
            await _context.Projects.AddAsync(project);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Edit(int id)
        {
            if (id == 0 || id == null) return NotFound();
            Project project = _context.Projects.FirstOrDefault(p => p.Id == id);
            if (project == null) return NotFound();
            return View(project);
        }
        public IActionResult Delete(int id)
        {
            if (id == 0 || id == null) return NotFound();
            Project project = _context.Projects.FirstOrDefault(p => p.Id == id);
            if (project == null) return NotFound();
            _context.Projects.Remove(project);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Edit(int id, Project project)
        {
            if (id == 0 || id == null) return NotFound();
            Project existed = await _context.Projects.FirstOrDefaultAsync(p => p.Id == id);
            if (existed == null) return NotFound();
            if (!ModelState.IsValid) return View();
            _context.Entry(existed).CurrentValues.SetValues(project);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
