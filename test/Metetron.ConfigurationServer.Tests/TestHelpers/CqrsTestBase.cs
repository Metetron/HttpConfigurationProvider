using System;
using System.Reflection;
using AutoMapper;
using MediatR;
using Metetron.ConfigurationServer.Persistence;
using Microsoft.Extensions.DependencyInjection;

namespace Metetron.ConfigurationServer.Tests.TestHelpers
{
    public class CqrsTestBase : IDisposable
    {
        public ConfigurationContext Context { get; set; }
        public IMediator Mediator { get; set; }

        public CqrsTestBase()
        {
            Context = DbContextFactory.Create();

            var services = new ServiceCollection();
            services.AddSingleton(Context);
            services.AddMediatR(Assembly.GetAssembly(typeof(Startup)));

            Mediator = services.BuildServiceProvider().GetRequiredService<IMediator>();
        }

        public void Dispose()
        {
            DbContextFactory.Dispose(Context);
            GC.SuppressFinalize(this);
        }
    }
}