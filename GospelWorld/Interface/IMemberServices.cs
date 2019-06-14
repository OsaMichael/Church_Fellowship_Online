using GospelWorld.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GospelWorld.Interface
{
    public interface IMemberServices
    {
        bool CreateMemb(MemberModel model);
        List<MemberModel> GetMembers();
        bool UpdateMemb(MemberModel model);
        MemberModel GetMemberById(int id);
        bool DeleteMember(int id);
    }
}