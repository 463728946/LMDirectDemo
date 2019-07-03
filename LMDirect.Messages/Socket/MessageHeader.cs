using BinarySerialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMDirect.Messages.Socket
{
    public class MessageHeader
    {
        [FieldOrder(1)]
        [FieldLength(1)]
        public ServiceType ServiceType { get; set; }

        [FieldOrder(2)]
        [FieldLength(1)]
        public MessageType MessageType { get; set; }

        [FieldOrder(3)]
        [FieldLength(2)]
        [SerializeAs(SerializedType.UInt2)]
        [FieldEndianness(Endianness.Big)]
        public int SequenceNumber { get; set; }

    }
}
