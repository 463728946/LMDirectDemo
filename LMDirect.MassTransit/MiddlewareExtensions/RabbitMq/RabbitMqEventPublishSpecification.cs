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
    public class RabbitMqEventPublishSpecification : IPipeSpecification<PublishContext<IEvent>>
    {
        private readonly IBus _bus;

        public RabbitMqEventPublishSpecification(IBus bus)
        {
            _bus = bus;
        }

        public void Apply(IPipeBuilder<PublishContext<IEvent>> builder)
        {
            builder.AddFilter(new RabbitMqEventPublishFilter(_bus));
        }

        public IEnumerable<ValidationResult> Validate()
        {
            return Enumerable.Empty<ValidationResult>();
        }
    }
}
