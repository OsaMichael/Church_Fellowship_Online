using GospelWorld.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GospelWorld.Models
{
    public class SermonCategoryModel
    {
        public int CatId { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        [Display(Name = "Message Type")]
        public string SermonType { get; set; }
        [Display(Name = "Description")]
        public string SermonDescription { get; set; }
        public string SermonName { get; set; }
        public bool Done { get; set; } = false;

        public virtual ICollection<SermonModel> Sermons { get; set; }
        public virtual ICollection<SermonCategoryModel> SermonCategories { get; set; }
        // public List<SermonModel> Sermons { get; set; }
        // public List<SermonCategory> SermonCategory { get; set; }
        public string SermonCat { get; set; }



        public SermonCategoryModel()
        {

        }

        public SermonCategoryModel(SermonCategory member)
        {
            this.Assign(member);
        }

        public SermonCategory Create(SermonCategoryModel model)
        {
            return new SermonCategory
            {
           
                  SermonDescription = model.SermonDescription,
                   SermonName = model.SermonName,
                    SermonType = model.SermonType,
                     SermonCat = model.SermonCat
               

            };


        }

    }
}