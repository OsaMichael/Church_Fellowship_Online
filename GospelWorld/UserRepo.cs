//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;

//namespace GospelWorld
//{
//    public class UserRepo : Repository<User>, IUserRepo<IUser>
//    {
//        private readonly PraiseAssemblyDbContext _DbContext;
//        public UserRepo(PraiseAssemblyDbContext context) : base(context)
//        {
//            _DbContext = context;
//        }

//        public List<IUser> UserList
//        {
//            get
//            {
//                return _DbContext.Users.ToList<IUser>();
//            }
//        }
//    }
//}