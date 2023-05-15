using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PapperAB.Data;
using PapperAB.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace PapperAB.Controllers
{
    public class InfoController : Controller
    {
        private readonly PapperABContext context;
        public InfoController(PapperABContext _context)
        {
            context = _context;
        }
        public async Task<IActionResult> Index()
        {
            List<InfoViewModel> list = new List<InfoViewModel>();
            var projectlist = await context.ProjectLists
                               .Include(x => x.Employees)
                               .Include(e => e.Projects)
            .AsNoTracking().ToListAsync();

            return View(projectlist);
        }
        //CreateInfo
        //GET
        public async Task<IActionResult> CreateInfo()
        {
            var equerys = from e in context.Employees
                         select e.FirstMidName + " " + e.LastName;
            ViewBag.EDropDownValues = new SelectList(context.Employees, "EmployeeId", "FirstMidName");
           
            
            var pquerys = from p in context.Projects
                         select p.ProjectName;
            ViewBag.PDropDownValues = new SelectList(context.Projects, "ProjectId", "ProjectName");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateInfo(ProjectList model)
        {
            if (ModelState.IsValid)
            {
                var projectlist = new ProjectList();
                projectlist.FK_ProjectId = model.FK_ProjectId;
                projectlist.FK_EmployeeId = model.FK_EmployeeId;
                projectlist.Start = model.Start;
                projectlist.Stop = model.Stop;
                context.Add(projectlist);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
        //CreateInfo
        //GET
        public async Task<IActionResult> UpdateInfo()
        {
            var equerys = from e in context.Employees
                          select e.FirstMidName + " " + e.LastName;
            ViewBag.EDropDownValues = new SelectList(context.Employees, "EmployeeId", "FirstMidName");


            var pquerys = from p in context.Projects
                          select p.ProjectName;
            ViewBag.PDropDownValues = new SelectList(context.Projects, "ProjectId", "ProjectName");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateInfo(ProjectList model)
        {
            if (ModelState.IsValid)
            {
                var projectlist = new ProjectList();
                projectlist.FK_ProjectId = model.FK_ProjectId;
                projectlist.FK_EmployeeId = model.FK_EmployeeId;
                projectlist.Start = model.Start;
                projectlist.Stop = model.Stop;
                context.Add(projectlist);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
    }
}
