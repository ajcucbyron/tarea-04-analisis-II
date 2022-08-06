using System;
using System.Collections.Generic;
using System.Reflection;
using Autofac;
using Ddd.KernellCompartido.Interfaces;
using Ddd.ManejoDeTienda.Dominio.Agregados;
using Infraestructura.SQL.Data;
using MediatR;
using MediatR.Pipeline;
using Microsoft.Extensions.ObjectPool;
using Module = Autofac.Module;

namespace Infraestructura.SQL
{
    public class ModuloDeInfraestructura: Module
    {
        private readonly bool _isDevelopment = false;
        private readonly List<Assembly> _assemblies = new List<Assembly>();

        public ModuloDeInfraestructura(bool isDevelopment, Assembly callingAssembly = null)
        {
            _isDevelopment = isDevelopment;
            var coreAssembly = Assembly.GetAssembly(typeof(Tienda));
            var infrastructureAssembly = Assembly.GetAssembly(typeof(StartupSetup));
            var sys = Assembly.GetAssembly(typeof(Guid));
            _assemblies.Add(coreAssembly);
            _assemblies.Add(infrastructureAssembly);
            _assemblies.Add(sys);
            if (callingAssembly != null)
            {
                _assemblies.Add(callingAssembly);
            }
        }

        protected override void Load(ContainerBuilder builder)
        {
            if (_isDevelopment)
            {
                RegisterDevelopmentOnlyDependencies(builder);
            }
            else
            {
                RegisterProductionOnlyDependencies(builder);
            }
            RegisterCommonDependencies(builder);
        }

        private void RegisterCommonDependencies(ContainerBuilder builder)
        {

            builder.RegisterGeneric(typeof(RepositorioBase<,>))
        .As(typeof(IRepositorio<,>))
        .InstancePerLifetimeScope();

        
            builder
                .RegisterType<Mediator>()
                .As<IMediator>()
                .InstancePerLifetimeScope();

            builder.Register<ServiceFactory>(context =>
            {
                var c = context.Resolve<IComponentContext>();
                return t => c.Resolve(t);
            });

            var mediatrOpenTypes = new[]
            {
                typeof(IRequestHandler<,>),
                typeof(IRequestExceptionHandler<,,>),
                typeof(IRequestExceptionAction<,>),
                typeof(INotificationHandler<>)
            };

            foreach (var mediatrOpenType in mediatrOpenTypes)
            {
                builder
                .RegisterAssemblyTypes(_assemblies.ToArray())
                .AsClosedTypesOf(mediatrOpenType)
                .AsImplementedInterfaces();
            }

            
            //builder.RegisterType<AppDbContextSeed>().InstancePerLifetimeScope();


            builder.RegisterType<DefaultObjectPoolProvider>()
              .As<ObjectPoolProvider>()
              .SingleInstance();            
        }

        private void RegisterDevelopmentOnlyDependencies(ContainerBuilder builder)
        {
            // TODO: Add development only services
        }

        private void RegisterProductionOnlyDependencies(ContainerBuilder builder)
        {
            // TODO: Add production only services
        }
    }
}
