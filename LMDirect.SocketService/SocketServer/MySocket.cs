using System;
using LMDirect.Services.Direct;
using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Config;
using SuperSocket.SocketBase.Protocol;

namespace LMDirect.SocketService.SocketServer
{
   
    public class MySocket : AppServer<MySession, BinaryRequestInfo>
    {
        public MySocket() : base(new DefaultReceiveFilterFactory<MyReceiveFilter, BinaryRequestInfo>())
        {

        }       
    }   
}
