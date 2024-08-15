using System.ComponentModel.DataAnnotations;

namespace TaskManagementSystem.Models
{
    public class Document
    {
        public int Id { get; set; }

        [Required]
        public string FileName { get; set; }

        public string FilePath { get; set; }

        public int TaskId { get; set; }

        public Task Task { get; set; }
    }
}
