using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PapperAB.Data;
using PapperAB.Models;

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
    }
}
