using LMDirect.Messages;
using LMDirect.Messages.Socket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMDirect.Services.Direct
{
    public interface IDirectService
    {
        Task<(Log _log, byte[] _response)> NewMessageAsync(byte[] bytes);

    }
}
