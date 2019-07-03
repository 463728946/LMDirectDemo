using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMDirect.MassTransit.BusSwitcher
{
    public interface IBusSwitch
    {
        Task Publish(object @event);
        Task Send(object message);
        Task<TResponse> Request<TRequest, TResponse>(TRequest request) where TRequest : class
            where TResponse : class;
    }
}
