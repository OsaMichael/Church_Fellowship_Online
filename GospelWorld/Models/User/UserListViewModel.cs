using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GospelWorld.Models.User
{
    public class UserListViewModel
    {
        public IEnumerable<ApplicationUser> Users { get; set; } = Enumerable.Empty<ApplicationUser>();

    }
}