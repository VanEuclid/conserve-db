using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace ConserveDB.Models
{
    public class MemberEmploymentViewModel
    {
        public List<Member> Members { get; set; }
        public SelectList EmploymentStatus { get; set; }
        public string Status { get; set; }
        public string SearchString { get; set; }       
    }
}
