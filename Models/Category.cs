using System;
using System.ComponentModel.DataAnnotations;

namespace Mission08_Group2_6.Models
{
	public class Category
	{
        [Key]
        [Required]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}

