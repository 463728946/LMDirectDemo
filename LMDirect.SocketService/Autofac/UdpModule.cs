using Autofac;
using SuperSocket.SocketEngine;
using System;
using LMDirect.SocketService.SocketServer;
using MassTransit;
using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Config;

namespace LMDirect.SocketService.Autofac
{
    public class UdpModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MyUdpServer>()
                .AsSelf()
                .SingleInstance();
        }
    }
}
