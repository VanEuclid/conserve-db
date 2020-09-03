using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ConserveDB.Models
{
    public class Department
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Department Name")]
        public string departmentName { get; set; }

        [Required]
        [Display(Name = "Position")]
        public string position { get; set; }

    }
}
