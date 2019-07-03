using GreenPipes;
using LMDirect.Messages.Events;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMDirect.MassTransit.MiddlewareExtensions.RabbitMq
{
    public class RabbitMqEventPublishFilter : IFilter<PublishContext<IEvent>>
    {
        private readonly IBus _bus;

        public RabbitMqEventPublishFilter(
            IBus bus)
        {
            _bus = bus;
        }

        public async Task Send(PublishContext<IEvent> context, IPipe<PublishContext<IEvent>> next)
        {
            await _bus.Publish(context.Message as object);
            await next.Send(context);
        }

        public void Probe(ProbeContext context) { }
    }
}
