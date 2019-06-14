using GospelWorld.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GospelWorld.Managers
{
    public interface ISermonCategoryServ
    {
        List<SermonCategoryModel> GetSermonCategories();
    }
}