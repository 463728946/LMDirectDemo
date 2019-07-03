using Autofac;
using LMDirect.Framework.Settings;
using LMDirect.MassTransit.BusSwitcher;
using LMDirect.MassTransit.MiddlewareExtensions.RabbitMq;
using MassTransit;
using System;
using System.Linq;

namespace LMDirect.MassTransit.Autofac
{
    public class MassTransitModule : Module
    {
        //private const string HOSTING_WEBAPI = "WebApi";
        //private const string HOSTING_WINSERVICE = "SocketService";
        protected override void Load(ContainerBuilder builder)
        {
            // Register all the consumers.
            builder.RegisterConsumers(typeof(MassTransitModule).Assembly);

            // Register the bus.

            RegisterRabbitMqBus(builder, false, false);
            RegisterInMemoryBus(builder, ReceiveEndPoint.Commnad, ReceiveEndPoint.Request, ReceiveEndPoint.Event);

            //var hosting = AppSettingConfig.Hosting;
            //var transportType = AppSettingConfig.TransportType;

            //if (transportType.ToUpper() == "RABBITMQ")
            //{
            //    if (hosting == HOSTING_WINSERVICE)
            //    {
            //        RegisterRabbitMqBus(builder, false, true, ReceiveEndPoint.Commnad, ReceiveEndPoint.Request, ReceiveEndPoint.Event);
            //    }
            //    else if (hosting == HOSTING_WEBAPI)
            //    {
            //        RegisterRabbitMqBus(builder, true, false);
            //    }
            //}
            //else
            //{
            //    if (hosting == HOSTING_WEBAPI)
            //    {
            //        RegisterRabbitMqBus(builder, false, false);

            //        RegisterInMemoryBus(builder, ReceiveEndPoint.Commnad, ReceiveEndPoint.Request, ReceiveEndPoint.Event);
            //    }
            //}

            builder.Register(context =>
                {
                    var memoryBus = context.ResolveKeyed<IBus>("memory_bus");
                    var rabbitMqBus = context.ResolveKeyed<IBus>("rabbitmq_bus");

                    return new BusSwitch(memoryBus, rabbitMqBus);
                })
                .AsImplementedInterfaces()
                .SingleInstance();
        }


        private void RegisterRabbitMqBus(ContainerBuilder builder, bool isSendIdentityHeader, bool isConfigureIdentityHeader, params ReceiveEndPoint[] receiveEndPoints)
        {
            builder.Register(context =>
            {
                var busControl = Bus.Factory.CreateUsingRabbitMq(cfg =>
                {
                    var uri = AppSettingConfig.RabbitMqBaseUri;

                    cfg.Host(new Uri(uri), x =>
                    {
                        x.Username(AppSettingConfig.RabbitMqUserName);
                        x.Password(AppSettingConfig.RabbitMqUserPassword);
                    });

                    //if (isSendIdentityHeader)
                    //{
                    //    ConfigureSendHeader(cfg);
                    //}

                    ConfigureEndPoints(cfg, context, receiveEndPoints);

                    //cfg.UseExceptionLogger(context.ResolveKeyed<ILogger>("masstransit_exception"));
                });

                //if (isConfigureIdentityHeader)
                //{
                //    busControl.ConnectConsumeObserver(new ConfigureIdentityConsumeObserver());
                //}

                busControl.Start();

                return busControl;
            })
            .Named<IBus>("rabbitmq_bus")
            .As<IBusControl>()
            .As<IBus>()
            .SingleInstance()
            .AutoActivate();
        }

        private void RegisterInMemoryBus(ContainerBuilder builder, params ReceiveEndPoint[] receiveEndPoints)
        {
            builder.Register(context =>
            {
                var busControl = Bus.Factory.CreateUsingInMemory(cfg =>
                {
                    ConfigureEndPoints(cfg, context, receiveEndPoints);

                    cfg.ConfigurePublish(x =>
                    {
                        // The middleware runs in order.
                        // Run rabbitmq event publish first and then run signalr service.
                        // repeat send
                        //x.UseEventStore(context.Resolve<IEventStoreService>());
                        x.UseRabbitMqEventPublish(context.ResolveKeyed<IBus>("rabbitmq_bus"));
                        //x.UseSignalR(context.Resolve<ISignalRService>());

                    });

                    //cfg.UseExceptionLogger(context.ResolveKeyed<ILogger>("masstransit_exception"));
                });

                busControl.Start();
                return busControl;
            })
            .Named<IBus>("memory_bus")
            .As<IBusControl>()
            .As<IBus>()
            .SingleInstance()
            .AutoActivate();
        }

        //private void ConfigureSendHeader(IBusFactoryConfigurator cfg)
        //{
        //    cfg.ConfigureSend(x => x.UseSendExecute(sendContext =>
        //    {
        //        //1. get current thread identity object.
        //        var currentThreadIdentityObject = Thread.CurrentPrincipal.Identity is BarcodeIdentity ? ((BarcodeIdentity)Thread.CurrentPrincipal.Identity).IdentityObject : null;

        //        if (currentThreadIdentityObject != null)
        //        {
        //            //2. set the headers.
        //            sendContext.Headers.Set(AppSettingConfig.RabbitMqIdentityHeaderKey, currentThreadIdentityObject.StaffID.ToString());
        //        }
        //    }));
        //}

        private void ConfigureEndPoints(IBusFactoryConfigurator cfg, IComponentContext context, params ReceiveEndPoint[] receiveEndPoints)
        {
            if (receiveEndPoints?.Length > 0)
            {
                var baseQueueName = AppSettingConfig.BaseQueueName;
                var rpcQueuePostfix = AppSettingConfig.RpcQueueNamePostfix;
                var commandQueuePostfix = AppSettingConfig.CommandQueueNamePostfix;
                var eventQueuePostfix = AppSettingConfig.EventQueueNamePostfix;

                var consumerMethod = typeof(AutofacExtensions).GetMethod("Consumer", new Type[] { typeof(IReceiveEndpointConfigurator), typeof(IComponentContext), typeof(string) });

                foreach (var receiveEndPoint in receiveEndPoints)
                {
                    if (receiveEndPoint == ReceiveEndPoint.Commnad)
                    {
                        cfg.ReceiveEndpoint(baseQueueName + "_" + commandQueuePostfix, ep =>
                        {
                            var commandConsumers = System.Reflection.Assembly.GetAssembly(typeof(MassTransitModule))
                                                                             .GetTypes()
                                                                             .Where(type => type.IsClass && type.Name.EndsWith("CommandConsumer"));

                            foreach (var commandConsumer in commandConsumers)
                            {
                                consumerMethod.MakeGenericMethod(commandConsumer).Invoke(commandConsumer, new object[] { ep, context, "message" });
                            }
                        });
                    }
                    else if (receiveEndPoint == ReceiveEndPoint.Request)
                    {
                        cfg.ReceiveEndpoint(baseQueueName + "_" + rpcQueuePostfix, ep =>
                        {
                            var requestConsumers = System.Reflection.Assembly.GetAssembly(typeof(MassTransitModule))
                                                                             .GetTypes()
                                                                             .Where(type => type.IsClass && type.Name.EndsWith("RequestConsumer"));

                            foreach (var requestConsumer in requestConsumers)
                            {
                                consumerMethod.MakeGenericMethod(requestConsumer).Invoke(requestConsumer, new object[] { ep, context, "message" });
                            }
                        });
                    }
                    else if (receiveEndPoint == ReceiveEndPoint.Event)
                    {
                        cfg.ReceiveEndpoint(baseQueueName + "_" + eventQueuePostfix, ep =>
                        {
                            var eventConsumers = System.Reflection.Assembly.GetAssembly(typeof(MassTransitModule))
                                                                             .GetTypes()
                                                                             .Where(type => type.IsClass && type.Name.EndsWith("EventConsumer"));

                            foreach (var eventConsumer in eventConsumers)
                            {
                                consumerMethod.MakeGenericMethod(eventConsumer).Invoke(eventConsumer, new object[] { ep, context, "message" });
                            }
                        });
                    }
                }
            }
        }


        private enum ReceiveEndPoint
        {
            Commnad,
            Event,
            Request
        }
    }


}
