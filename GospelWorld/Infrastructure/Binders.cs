using GospelWorld.Interface;
using GospelWorld.Managers;
using GospelWorld.Models;
using Ninject.Modules;
using Ninject.Web.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GospelWorld
{
    public class Binders : NinjectModule
    {
        public override void Load()
        {
            //Kernel.Bind<DbContext>().ToSelf().InRequestScope();
            Kernel.Bind<DbContext>().To<ApplicationDbContext>().InRequestScope();

            Bind<IDepartmentService>().To<DepartmentService>().InRequestScope();
            Bind<ISermonServices>().To<SermonServices>().InRequestScope();
            Bind<IWorkerServices>().To<WorkerServices>().InRequestScope();
            Bind<IEventServices>().To<EventServices>().InRequestScope();
            Bind<IMemberServices>().To<MemberServices>().InRequestScope();
            Bind<ISermonCategoryServ>().To<SermonCategoryServ>().InRequestScope();
        }
       
    }
}