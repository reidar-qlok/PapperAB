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
            var items = await (from emp in context.Employees
                               join pl in context.ProjectLists on emp.EmployeeId equals pl.FK_EmployeeId
                               join proj in context.Projects on pl.FK_ProjectId equals proj.ProjectId
                               select new
                               {
                                   Start = pl.Start,
                                   Stop = pl.Stop,
                                   ProjectName= proj.ProjectName,
                                   Description = proj.Description,
                                   FirstMidName = emp.FirstMidName,
                                   LastName=emp.LastName
                               }).ToListAsync();
            // konvertera från anonymous
            foreach (var item in items)
            {
                InfoViewModel listItem = new InfoViewModel();
                listItem.Start = item.Start;
                listItem.Stop = item.Stop;
                listItem.ProjectName = item.ProjectName;
                listItem.Description = item.Description;
                listItem.FirstMidName = item.FirstMidName;
                listItem.LastName = item.LastName;
                list.Add(listItem);
            }
            // Kalla på view
            return View(list);
        }
    }
}
