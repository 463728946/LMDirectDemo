using LMDirect.Services.Direct;
using SuperSocket.SocketBase.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMDirect.SocketService.SocketServer
{
    public class MyReceiveFilter : IReceiveFilter<BinaryRequestInfo>
    {       
        public MyReceiveFilter()
        {           
        }
        public int LeftBufferSize { get; set; }

        public IReceiveFilter<BinaryRequestInfo> NextReceiveFilter { get; set; }

        public FilterState State { get; set; }

        public BinaryRequestInfo Filter(byte[] readBuffer, int offset, int length, bool toBeCopied, out int rest)
        {
            rest = 0;
            var id = new Guid().ToString();
            var info = new BinaryRequestInfo(id, readBuffer);                        
            return info;
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }

}
