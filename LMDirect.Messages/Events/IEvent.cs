using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMDirect.Messages.Events
{
    public interface IEvent 
    {
        Guid EntityId { get; }
    }

    public interface ISucceedEvent : IEvent { }
    public interface IFailedEvent : IEvent { }
}
