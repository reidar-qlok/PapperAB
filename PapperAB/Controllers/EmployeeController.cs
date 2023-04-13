using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PapperAB.Data;

namespace PapperAB.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly PapperABContext context;
        public EmployeeController(PapperABContext _context)
        {
            context = _context;
        }
        public async Task<IActionResult> Index()
        {
            return context.Employees != null ?
                View(await context.Employees.ToListAsync()) :
                Problem("Employees är null");
        }
    }
}
