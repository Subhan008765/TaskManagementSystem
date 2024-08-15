using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TaskManagementSystem.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Email { get; set; }

        public int TeamId { get; set; }

        public Team Team { get; set; }

        public ICollection<Task> Tasks { get; set; }
    }
}
