using BinarySerialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMDirect.Messages.Socket
{
    public class Options
    {
        [FieldOrder(7)]
        [FieldBitLength(1)]
        public bool IsMobileID { get; set; }

        [FieldOrder(6)]
        [FieldBitLength(1)]
        public bool IsMobileIDType { get; set; }

        [FieldOrder(5)]
        [FieldBitLength(1)]
        public bool IsAuthenticationWord { get; set; }

        [FieldOrder(4)]
        [FieldBitLength(1)]
        public bool IsRouting { get; set; }

        [FieldOrder(3)]
        [FieldBitLength(1)]
        public bool IsForwarding { get; set; }

        [FieldOrder(2)]
        [FieldBitLength(1)]
        public bool IsResponseRedirection { get; set; }

        [FieldOrder(1)]
        [FieldBitLength(1)]
        public bool IsOptionsExtension { get; set; }

        [FieldOrder(0)]
        [FieldBitLength(1)]
        public bool IsAlwaysSet { get; set; }
    }
}
