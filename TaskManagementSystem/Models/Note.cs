using System.ComponentModel.DataAnnotations;

namespace TaskManagementSystem.Models
{
    public class Note
    {
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        public int TaskId { get; set; }

        public Task Task { get; set; }
    }
}
