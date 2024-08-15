using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace TaskManagementSystem.Models
{
    public class Task
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        public DateTime DueDate { get; set; }

        public bool IsCompleted { get; set; }

        public int EmployeeId { get; set; }

        public Employee Employee { get; set; }

        public ICollection<Note> Notes { get; set; }

        public ICollection<Document> Documents { get; set; }
    }
}
