using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Calendar.Business;
using Calendar.DataAccess;
using Calendar.Entities;
using Ninject;

namespace Calendar.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {

        private IKernel kernel;

        public NinjectDependencyResolver()
        {
            kernel = new StandardKernel();
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            kernel.Bind<IRepository<Event>>().To<CommonRepository<Event>>();
            kernel.Bind<IEventService>().To<EventService>();
            kernel.Bind<IUserService>().To<UserService>();
        }
    }
}