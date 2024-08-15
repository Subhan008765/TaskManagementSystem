using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManagementSystem.Data;
using TaskManagementSystem.Models;
using TaskManagementSystem.Helpers;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("tasks/due-in/{days}")]
        public async Task<ActionResult<IEnumerable<Models.Task>>> GetTasksDueInDays(int days)
        {
            var dueDate = DateTime.Now.AddDays(days);
            var tasks = await _context.Tasks
                .Where(t => t.DueDate <= dueDate && !t.IsCompleted)
                .Include(t => t.Employee)
                .Include(t => t.Employee.Team)
                .ToListAsync();

            return Ok(tasks);
        }

        [HttpGet("tasks/due-this-week")]
        public async Task<ActionResult<IEnumerable<Models.Task>>> GetTasksDueThisWeek()
        {
            var startOfWeek = DateTime.Now.StartOfWeek(DayOfWeek.Monday);
            var endOfWeek = startOfWeek.AddDays(7);

            var tasks = await _context.Tasks
                .Where(t => t.DueDate >= startOfWeek && t.DueDate < endOfWeek && !t.IsCompleted)
                .Include(t => t.Employee)
                .Include(t => t.Employee.Team)
                .ToListAsync();

            return Ok(tasks);
        }

        [HttpGet("tasks/due-this-month")]
        public async Task<ActionResult<IEnumerable<Models.Task>>> GetTasksDueThisMonth()
        {
            var startOfMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            var endOfMonth = startOfMonth.AddMonths(1);

            var tasks = await _context.Tasks
                .Where(t => t.DueDate >= startOfMonth && t.DueDate < endOfMonth && !t.IsCompleted)
                .Include(t => t.Employee)
                .Include(t => t.Employee.Team)
                .ToListAsync();

            return Ok(tasks);
        }

        [HttpGet("teams/performance-this-month")]
        public async Task<ActionResult<IEnumerable<TeamPerformanceReport>>> GetTeamPerformanceThisMonth()
        {
            var startOfMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            var endOfMonth = startOfMonth.AddMonths(1);

            var performance = await _context.Tasks
                .Where(t => t.DueDate >= startOfMonth && t.DueDate < endOfMonth && t.IsCompleted)
                .GroupBy(t => t.Employee.Team)
                .Select(g => new TeamPerformanceReport
                {
                    TeamName = g.Key.Name,
                    TasksCompleted = g.Count()
                })
                .ToListAsync();

            return Ok(performance);
        }
    }

    public class TeamPerformanceReport
    {
        public string TeamName { get; set; }
        public int TasksCompleted { get; set; }
    }
}

