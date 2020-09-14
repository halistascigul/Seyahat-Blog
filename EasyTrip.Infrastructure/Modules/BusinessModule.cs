using EasyTrip.Business.Repositories.Abstract;
using EasyTrip.Business.Repositories.Concrete;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyTrip.Infrastructure.Modules
{
    public class BusinessModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IBlogService>().To<BlogManager>().InSingletonScope();
            Bind<ICommentService>().To<CommentManager>().InSingletonScope();
            Bind<IContactService>().To<ContactManager>().InSingletonScope();
            Bind<IImageService>().To<ImageManager>().InSingletonScope();
            Bind<IAdminService>().To<AdminManager>().InSingletonScope();
        }
    }
}
