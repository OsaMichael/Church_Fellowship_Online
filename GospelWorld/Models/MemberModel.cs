using GospelWorld.Atrributes;
using GospelWorld.Entities;
using PagedList;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GospelWorld.Models
{
    public class MemberModel
    {
        public int MembId { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Other Name")]
        public string OtherName { get; set; }

        [Display(Name = "House Address")]
        public string Address { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Required]
        [Display(Name = "Married?")]

        public bool Married { get; set; } = false;
        public string SpouseName { get; set; }

        [Display(Name = "Picture")]
        public string MemberImageUrl { get; set; }

        public IPagedList<MemberModel> Members { get; set; }
        [FileTypes("jpg,jpeg,png")]
        public HttpPostedFileBase MemeberImageThumbnailUrl { get; set; }
        [Display(Name = "Date of Birth")]
        public DateTime DateOfBirth { get; set; }
        [Display(Name = "Profession")]
        public string Profession { get; set; }

        public MemberModel()
        {

        }

        public MemberModel(Member member)
        {
            this.Assign(member);
        }

        public Member Create(MemberModel model)
        {
            return new Member
            {
                MemberName = model.FirstName + " " + model.LastName + " " + OtherName,
                Address = model.Address,
            FirstName = model.FirstName,
            LastName = model.LastName,
            OtherName = model.OtherName,
                PhoneNumber = model.PhoneNumber,
                 DateOfBirth = model.DateOfBirth,
                  Married = model.Married,
                   MemberImageUrl = model.MemberImageUrl,
                //MemeberImageThumbnailUrl = model.MemeberImageThumbnailUrl,
                Profession = model.Profession,
                     SpouseName = model.SpouseName,
                   

            };


        }
        public Member Edit(Member entity, MemberModel model)
        {
            entity.SpouseName = model.SpouseName;
            entity.Profession = model.Profession;
            entity.PhoneNumber = model.PhoneNumber;
            entity.MembId = model.MembId;
            entity.MemberName = model.FirstName + " " + model.LastName;
            entity.Married = model.Married;
            entity.Address = model.Address;
            entity.FirstName = model.FirstName;
            entity.LastName = model.LastName;
            

            return entity;
        }

    }
}