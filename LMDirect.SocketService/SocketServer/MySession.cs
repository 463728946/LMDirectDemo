using System;
using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Protocol;
using LMDirect.Services.Direct;
using LMDirect.MassTransit.BusSwitcher;
using LMDirect.Messages;
using LMDirect.Messages.Socket;
using LMDirect.Framework.Common;

namespace LMDirect.SocketService.SocketServer
{
    public class MySession : AppSession<MySession, BinaryRequestInfo>
    {
        public IDirectService _service;
        public IBusSwitch _bus;
        public MySession()
        {

        }
        protected override async void HandleUnknownRequest(BinaryRequestInfo requestInfo)
        {
            var hex = requestInfo.Body.ToHex();
            Console.WriteLine("Raw:{0}", hex);
            try
            {
                var (_event, _response) = await _service.NewMessageAsync(requestInfo.Body);
                if (_event != null) await _bus.Publish(_event);
                if (_response != null) TrySend(_response, 0, _response.Length);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                //throw;
            }
           
        }

        protected override void OnSessionStarted()
        {
        }



    }




}
