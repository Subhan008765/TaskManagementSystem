using Microsoft.EntityFrameworkCore;
using TaskManagementSystem.Models;
using System.Threading.Tasks;
using TaskModel = TaskManagementSystem.Models.Task; // Alias for Task model
namespace TaskManagementSystem.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<TaskModel> Tasks { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Document> Documents { get; set; }
    }
}
