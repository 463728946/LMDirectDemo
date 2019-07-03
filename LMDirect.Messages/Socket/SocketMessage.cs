using BinarySerialization;

namespace LMDirect.Messages.Socket
{
    public class SocketMessage
    {
        [FieldOrder(0)]
        public OptionsHeader OptionsHeader { get; set; }

        [FieldOrder(1)]
        [FieldLength(4)]
        public MessageHeader Header { get; set; }

        [FieldOrder(2)]
        [Subtype("Header.MessageType", MessageType.Null, typeof(NullMessage))]
        [Subtype("Header.MessageType", MessageType.ACK_NAK, typeof(AcknowledgeMessage))]
        [Subtype("Header.MessageType", MessageType.EventReport, typeof(EventReportMessage))]
        [Subtype("Header.MessageType", MessageType.ApplicationData, typeof(ApplicationMessage))]
        [Subtype("Header.MessageType", MessageType.IDReport, typeof(IDReportMessage))]
        public IMessageContents Contents { get; set; }
       
    }

    public class Test: IMessageContents
    {
        [FieldOrder(0)]
        public byte[] Data { get; set; }
    }
}
