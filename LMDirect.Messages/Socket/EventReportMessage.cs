using BinarySerialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMDirect.Messages.Socket
{
    public class EventReportMessage :  BaseReportContents
    {

        [FieldOrder(15)]
        [FieldLength(1)]
        public short EventIndex { get; set; }

        [FieldOrder(16)]
        [FieldLength(1)]
        public short EventCode { get; set; }

        [FieldOrder(17)]
        [FieldLength(1)]
        public short Accums { get; set; }

        [FieldOrder(18)]
        [FieldLength(1)]
        public short Append { get; set; }

        [FieldOrder(19)]
        [FieldLength(4)]
        public byte[] AccumList { get; set; }
    }

    public class AppendixG
    {

    }

}
