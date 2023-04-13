using Microsoft.EntityFrameworkCore;
using PapperAB.Models;

namespace PapperAB.Data
{
    public class PapperABContext : DbContext
    {
        public PapperABContext(DbContextOptions<PapperABContext> options) 
            : base(options)
        {
            
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectList> ProjectLists { get; set; }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //}
    }
}
