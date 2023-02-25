using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Options;

namespace Mission08_Group2_6.Models
{
	public class TaskEntry
	{
        //Build an app that allow the users to enter tasks with the following information:
        [Key]
        [Required]
        public int TaskId { get; set; }
        //• Task(Required)
        [Required(ErrorMessage ="Please provide a task name.")]
        public string TaskName { get; set; }
        //• Due Date
        public string? DueDate { get; set; }
        //• Quadrant(Required)
        [Required]
        public int Quadrant { get; set; }


        // set up foreign key
        //• Category(Dropdown containing options: Home, School, Work, Church)
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }
        //• Completed(True/False)
        public bool Completed { get; set; }
        
    }
}

