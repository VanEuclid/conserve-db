using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConserveDB.Models
{
    public class Member
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Address { get; set; }

        [Required]
        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }

        [Required]
        [Display(Name = "Preferred Contact Phone Number")]
        [DataType(DataType.PhoneNumber)]
        public string PreferredContactPhoneNumber { get; set; }

        [Required]
        public string Position { get; set; }
        public string Department { get; set; }

        [Display(Name = "Start Date")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Display(Name = "End Date")]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        [Required]
        [Display(Name = "Employment Status")]
        public string EmploymentStatus { get; set; }

        [Required]
        public string Shift { get; set; }

        [Required]
        public string Manager { get; set; }

        [Display(Name = "Team Member Photo")]
        public string TeamMemberPhoto { get; set; }

        [Display(Name = "Favorite Color")]
        public string FavoriteColor { get; set; }

    }
}
