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
    public class EventStoreFilter : IFilter<PublishContext<IEvent>>
    {
        private readonly IEventStoreService _eventService;

        public EventStoreFilter(IEventStoreService eventService)
        {
            _eventService = eventService;
        }

        public async Task Send(PublishContext<IEvent> context, IPipe<PublishContext<IEvent>> next)
        {
            //await _eventService.InsertAsync(context.Message);
            await next.Send(context);
        }

        public void Probe(ProbeContext context) { }
    }
}
