using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMDirect.MassTransit.MiddlewareExtensions.EventStore
{
    public static class EventStoreExtension
    {
        public static void UseEventStore(this IPublishPipeConfigurator configurator, IEventStoreService eventService)
        {
            configurator.AddPipeSpecification(new EventStoreSpecification(eventService));
        }
    }
}
