using Autofac;
using LMDirect.Core.Autofac;
using LMDirect.Framework.Settings;
using LMDirect.MassTransit.Autofac;
using LMDirect.Services.Autofac;
using LMDirect.SocketService.Autofac;
using LMDirect.SocketService.SocketServer;
using MassTransit;

namespace LMDirect.SocketService
{
    public class SocketService
    {
        private readonly IContainer _container;
        //private readonly IBootstrap _bootstrap;

        public SocketService()
        {            
            var builder = new ContainerBuilder();
            builder.RegisterModule<DataModule>();
            builder.RegisterModule<ServiceModule>();                        
            builder.RegisterModule<MassTransitModule>();
            builder.RegisterModule<UdpModule>();
            var container = builder.Build();

            _container = container;
        }

        public void Start()
        {
            if (AppSettingConfig.TransportType.ToUpper() == "RABBITMQ")
            {
                _container.Resolve<IBusControl>().Start();
            }
            _container.Resolve<MyUdpServer>().Start();
        }

        public void Stop()
        {
            if (AppSettingConfig.TransportType.ToUpper() == "RABBITMQ")
            {
                _container.Resolve<IBusControl>().Start();
            }
            //_bootstrap.Stop();
        }


    }

  

  

}
