using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMDirect.MassTransit.MiddlewareExtensions.RabbitMq
{
    public static class RabbitMqEventPublishExtension
    {
        public static void UseRabbitMqEventPublish(this IPublishPipeConfigurator configurator, IBus bus)
        {
            configurator.AddPipeSpecification(new RabbitMqEventPublishSpecification(bus));
        }
    }
}
