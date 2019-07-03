using BinarySerialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMDirect.Messages.Socket
{
    public class AcknowledgeMessage : IMessageContents
    {
        /// <summary>
        /// 1 byte
        /// </summary>
        [FieldOrder(0)]
        [FieldLength(1)]
        //[SubtypeDefault(typeof(MessageType))]
        public byte Type { get; set; }
        /// <summary>
        /// 1 byte
        /// </summary>
        [FieldOrder(1)]
        [FieldLength(1)]
        public byte Ack { get; set; }
        /// <summary>
        /// 1 byte
        /// </summary>
        [FieldOrder(2)]
        [FieldLength(1)]
        public byte Unused { get; set; }

        /// <summary>
        /// 3 byte
        /// </summary>
        [FieldOrder(3)]
        [FieldLength(3)]
        public byte[] AppVersion { get; set; }
    }
}
