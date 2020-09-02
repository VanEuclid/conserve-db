using System;
using System.ComponentModel.DataAnnotations;

namespace ConserveDB.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string departmentName { get; set; }
        public string position { get; set; }
    }
}
