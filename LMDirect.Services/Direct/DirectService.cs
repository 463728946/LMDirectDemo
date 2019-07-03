using BinarySerialization;
using LMDirect.Core;
using LMDirect.Messages.Socket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Autofac;
using LMDirect.Framework.Common;
using LMDirect.Messages;

namespace LMDirect.Services.Direct
{
    public class DirectService : IDirectService
    {
        private readonly IMongoRepository _repository;
        private readonly Dictionary<short, string> DicEventCode;

        public DirectService(IMongoRepository repository)
        {
            DicEventCode = new Dictionary<short, string>
            {
                { 0, "Moving" },
                { 1, "GPS Acquired" },
                { 2, "GPS Lost" },
                { 3, "Ignition ON" },
                { 4, "Ignition OFF" },
                { 5,"VBus DTC Change"},
                { 6,"VBus State-Vehicle Not Detected"},
                { 7,"VBus State-Vehicle Detected"},
                { 8,"VBus State-VIN Decode Completed"},
                { 9,"VBus Event-Engine Off "},
                { 10,"VBus Event- Engine On"},
                { 11,"VBus Event-DM1 Change"},
                { 12,"VBus Event-Custom defined VBus Event"}

            };
            _repository = repository;
        }

        public async Task<(Log _log, byte[] _response)> NewMessageAsync(byte[] bytes)
        {
            try
            {
                var serializer = new BinarySerializer();
                var message = await serializer.DeserializeAsync<SocketMessage>(bytes);

                var log = new Log()
                {
                    CreatedOn = DateTime.UtcNow,
                    MobileID = message.OptionsHeader.MobileID.ToHex(),
                    ServiceType = message.Header.ServiceType.ToString(),
                    MessageType = message.Header.MessageType.ToString(),
                    SequenceNumber = message.Header.SequenceNumber,

                    RawData = bytes.ToHex(),
                    Decoded = message
                };

                if (message.Contents.GetType().IsAssignableTo<BaseReportContents>())
                {
                    var contents = message.Contents as BaseReportContents;
                    log.UpdateTime = contents.UpdateTime.ToDateTime();
                    log.Latitude = contents.Latitude;
                    log.Longitude = contents.Longitude;
                    log.Altitude = contents.Altitude;
                    log.Speed = contents.Speed * 0.036; //1cm/s=1/1000000cm/1/3600s=0.036km/h
                    log.Heading = contents.Heading;
                    if (message.Contents.GetType().IsAssignableTo<EventReportMessage>())
                    {
                        var er = message.Contents as EventReportMessage;
                        var codevalue = string.Empty;
                        if (!DicEventCode.TryGetValue(er.EventCode, out codevalue))
                            codevalue = string.Format("No Definition EventCode{0}", er.EventCode);

                        log.EventCode = codevalue;
                    }
                }

                await _repository.InsertOneAsync(log);
                return (log, Response(message, serializer));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return (null, null);
            }
        }


        private byte[] Response(SocketMessage message, BinarySerializer bs)
        {
            var response = new SocketMessage
            {
                OptionsHeader = message.OptionsHeader,
                Header = new MessageHeader()
                {
                    MessageType = MessageType.ACK_NAK,
                    ServiceType = ServiceType.ResponseToAnAcknowledged,
                    SequenceNumber = message.Header.SequenceNumber
                },
                Contents = new AcknowledgeMessage()
                {
                    Type = 0x0,
                    Ack = 0x0,
                    Unused = 0x0,
                    AppVersion = new byte[] { 0x0, 0x0, 0x0 }
                }
            };
            using (var ms = new System.IO.MemoryStream())
            {
                bs.Serialize(ms, response);
                return ms.ToArray();
            }
        }




    }
}
