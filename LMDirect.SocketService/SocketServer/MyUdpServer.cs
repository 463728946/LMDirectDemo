using LMDirect.Services.Direct;
using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LMDirect.MassTransit.BusSwitcher;

namespace LMDirect.SocketService.SocketServer
{

    public class MyUdpServer : MySocket
    {
        public IDirectService _service;
        public IBusSwitch _bus;
        public MyUdpServer(IDirectService service, IBusSwitch bus)
        {
            _bus = bus;
            _service = service;
            NewSessionConnected += MyAbc_NewSessionConnected;
        }

        private void MyAbc_NewSessionConnected(MySession session)
        {
            session._service = _service;
            session._bus = _bus;
        }

        public override bool Start()
        {
            var config = new ServerConfig
            {
                Ip = "Any",
                Port = 20500,
                Mode = SocketMode.Udp
            };
            if (!base.Setup(config))
                Console.WriteLine("Socket Setup Error");

            return base.Start();
        }

        public override void Stop()
        {

        }

    }
}
