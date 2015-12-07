using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Auction.Data.Repository;
using Auction.Data.UnitOfWork;
using Ninject;

namespace Auction.Web
{
    public class AuctionDependencyResolver : IDependencyResolver
    {
        private readonly IKernel _kernel;

        public AuctionDependencyResolver(IKernel kernel)
        {
            _kernel = kernel;
            DependencyBuilder();
        }

        private void DependencyBuilder()
        {
            _kernel.Bind<IUnitOfWork>().To<UnitOfWork>();
            _kernel.Bind<IUserRepository>().To<UserRepository>();
        }

        public object GetService(Type serviceType)
        {
            return _kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _kernel.GetAll(serviceType);
        }
    }
}