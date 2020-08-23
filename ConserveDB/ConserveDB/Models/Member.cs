using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConserveDB.Models
{
    public class Member
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Address { get; set; }

        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }

        [Display(Name = "Preferred Contact Phone Number")]
        public string PreferredContactPhoneNumber { get; set; }
        public string Position { get; set; }
        public string Department { get; set; }

        [Display(Name = "Start Date")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Display(Name = "End Date")]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        [Display(Name = "Employment Status")]
        public string EmploymentStatus { get; set; }
        public string Shift { get; set; }
        public string Manager { get; set; }

        [Display(Name = "Team Member Photo")]
        public string TeamMemberPhoto { get; set; }

        [Display(Name = "Favorite Color")]
        public string FavoriteColor { get; set; }

    }
}
