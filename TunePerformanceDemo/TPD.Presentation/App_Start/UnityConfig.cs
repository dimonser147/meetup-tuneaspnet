using System;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using TPD.Presentation.Models;
using TPD.Presentation.Controllers;

namespace TPD.Presentation.App_Start
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        /// <summary>
        /// Gets the configured Unity container.
        /// </summary>
        public static IUnityContainer GetConfiguredContainer()
        {
            return container.Value;
        }
        #endregion

        /// <summary>Registers the type mappings with the Unity container.</summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>There is no need to register concrete types such as controllers or API controllers (unless you want to 
        /// change the defaults), as Unity allows resolving a concrete type even if it was not previously registered.</remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // ASP.NET Identity
            container.RegisterType<DbContext, ApplicationDbContext>(new HierarchicalLifetimeManager());
            container.RegisterType<UserManager<ApplicationUser>>(new HierarchicalLifetimeManager());
            container.RegisterType<IUserStore<ApplicationUser>, UserStore<ApplicationUser>>(new HierarchicalLifetimeManager());
            container.RegisterType<AccountController>(new InjectionConstructor());

            // DB Context
            container
                .RegisterInstance<DAL.TunePerformanceDemoEntities>(container.Resolve<DAL.TunePerformanceDemoEntities>(), new HierarchicalLifetimeManager());

            // Repositories
            container
                .RegisterType<TPD.DAL.Events.ISpeakersRepository, TPD.DAL.Events.Repositories.SpeakersRepositoryV3>(
                    new InjectionConstructor(container.Resolve<DAL.TunePerformanceDemoEntities>())
                )
                .RegisterType<TPD.DAL.Events.IProgrammsRepository, TPD.DAL.Events.Repositories.ProgrammsRepositoryV3>(
                    new InjectionConstructor(container.Resolve<DAL.TunePerformanceDemoEntities>())
                ); 

            // UOW
            container
                .RegisterType<TPD.DAL.Events.IEventUOW, TPD.DAL.Events.EventUOW>(
                    new InjectionConstructor(container.Resolve<DAL.TunePerformanceDemoEntities>())
                );

        }
    }
}
