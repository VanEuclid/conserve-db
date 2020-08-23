using System;
using System.ComponentModel.DataAnnotations;

namespace ConserveDB.Models
{
    public class Member
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Address { get; set; }
        public string EmailAddress { get; set; }
        public string PreferredContactPhoneNumber { get; set; }
        public string Position { get; set; }
        public string Department { get; set; }

        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        public string EmploymentStatus { get; set; }
        public string Shift { get; set; }
        public string Manager { get; set; }
        public string TeamMemberPhoto { get; set; }
        public string FavoriteColor { get; set; }

    }
}
