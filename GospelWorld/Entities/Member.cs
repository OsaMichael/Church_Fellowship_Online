using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GospelWorld.Entities
{
    public class Member
    {
        [Key]
        public int MembId { get; set; }
        public string MemberName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string MemberImageUrl { get; set; }
        public string MemeberImageThumbnailUrl { get; set; }
        public string Profession { get; set; }
        public bool Married { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string OtherName { get; set; }
        public string SpouseName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }

    }
}