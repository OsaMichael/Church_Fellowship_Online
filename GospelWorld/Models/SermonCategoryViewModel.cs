using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GospelWorld.Models
{
    public class SermonCategoryViewModel
    {
        public virtual ICollection<SermonCategoryModel> SermonCategories { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 2)]
        [Display(Name = "Message Type")]
        public string SermonType { get; set; }
        [Display(Name = "Description")]
        public string SermonDescription { get; set; }
        public string SermonName { get; set; }
        public bool Done { get; set; } = false;
    }
}