using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;
using static System.Net.Mime.MediaTypeNames;

namespace WebApplication2.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        {
        }
       public DbSet<Test> tests { get; set; }
    }
}
