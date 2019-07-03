using Autofac;
using LMDirect.Framework.Settings;
using LMDirect.MassTransit.Autofac;
using LMDirect.Services.Autofac;
using LMDirect.SocketService.Autofac;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMDirect.WinService
{
    public class LMDirectService
    {
        private readonly IContainer _container;

        public LMDirectService()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule<UdpModule>();
            builder.RegisterModule<ServiceModule>();
            builder.RegisterModule<MassTransitModule>();
            var container = builder.Build();

            _container = container;
        }

        public void Start()
        {
            if (AppSettingConfig.TransportType.ToUpper() == "RABBITMQ")
            {
                _container.Resolve<IBusControl>().Start();
            }
        }

        public void Stop()
        {
            if (AppSettingConfig.TransportType.ToUpper() == "RABBITMQ")
            {
                _container.Resolve<IBusControl>().Stop();
            }
        }

    }
}
