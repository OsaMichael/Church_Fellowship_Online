using GospelWorld.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GospelWorld.Interface
{
    public interface ISermonServices
    {
        bool CreatSermon(SermonModel model);
        List<SermonModel> GetSermons();
        bool UpdateSerm(SermonModel model);
        SermonModel GetSermonById(int id);
        bool DeleteSermon(int id);
        List<SermonViewModel> GetSermonViewModels();

    }
}