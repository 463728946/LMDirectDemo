using GreenPipes;
using LMDirect.Messages.Events;
using LMDirect.Services.EventStore;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMDirect.MassTransit.MiddlewareExtensions.EventStore
{
    public class EventStoreSpecification : IPipeSpecification<PublishContext<IEvent>>
    {
        private readonly IEventStoreService _eventService;

        public EventStoreSpecification(IEventStoreService eventService)
        {
            _eventService = eventService;
        }

        public void Apply(IPipeBuilder<PublishContext<IEvent>> builder)
        {
            builder.AddFilter(new EventStoreFilter(_eventService));
        }

        public IEnumerable<ValidationResult> Validate()
        {
            return Enumerable.Empty<ValidationResult>();
        }
    }
}
