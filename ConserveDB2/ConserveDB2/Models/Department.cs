using System;
using System.ComponentModel.DataAnnotations;

namespace ConserveDB2.Models
{
    public class Department
    {
        [Key]
        public int DId { get; set; }

        [Required]
        [Display(Name = "Department Name")]
        public string departmentName { get; set; }

        [Required]
        [Display(Name = "Position")]
        public string position { get; set; }

    }
}
