using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;
using Interfaces.Services;
using BLL.Services;
using DAL.Repository;
using Interfaces.Repository;

namespace lab.Util
{
    public class ReposModule : NinjectModule
    {
        private string connectionString;
        public ReposModule(/*string connection*/)
        {
            //connectionString = connection;
        }

        public override void Load()
        {
            Bind<IDbRepository>().To<DbRepositorySQL>()/*.InSingletonScope().WithConstructorArgument(connectionString)*/;
        }
    }
}
