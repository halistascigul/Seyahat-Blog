using EasyTrip.DataAccess.Abstract;
using EasyTrip.DataAccess.Concrete;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyTrip.Infrastructure.Modules
{
    public class DalModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IBlogDal>().To<BlogDal>().InSingletonScope();
            Bind<ICommentDal>().To<CommentDal>().InSingletonScope();
            Bind<IContactDal>().To<ContactDal>().InSingletonScope();
            Bind<IImageDal>().To<ImageDal>().InSingletonScope();
            Bind<IAdminDal>().To<AdminDal>().InSingletonScope();
        }
    }
}
