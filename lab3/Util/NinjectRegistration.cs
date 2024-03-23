using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;
using Interfaces.Services;
using BLL.Services;

namespace lab.Util
{
    internal class NinjectRegistration : NinjectModule
    {
        public override void Load()
        {
            Bind<ICarService>().To<CarService>();
            Bind<IClientService>().To<ClientService>();
            Bind<ISlotService>().To<SlotService>();
            Bind<IRegistrationService>().To<RegistrationService>();
            Bind<IBreakdownService>().To<BreakdownService>();
            Bind<IMechanicService>().To<MechanicService>();
        }
    }
}
