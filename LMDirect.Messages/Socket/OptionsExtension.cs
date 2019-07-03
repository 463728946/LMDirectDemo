using BinarySerialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMDirect.Messages.Socket
{
    public class OptionsExtension
    {
        [FieldOrder(7)]
        [FieldBitLength(1)]
        public bool ESN { get; set; }

        [FieldOrder(6)]
        [FieldBitLength(1)]
        public bool VIN { get; set; }

        [FieldOrder(5)]
        [FieldBitLength(1)]
        public bool EncryptionService { get; set; }

        [FieldOrder(4)]
        [FieldBitLength(1)]
        public bool LM_Direct_Compression { get; set; }

        [FieldOrder(3)]
        [FieldBitLength(1)]
        public bool LM_Direct_Routing { get; set; }

        [FieldOrder(2)]
        [FieldBitLength(1)]
        public bool NotUsed1 { get; set; }

        [FieldOrder(1)]
        [FieldBitLength(1)]
        public bool NotUsed2 { get; set; }

        [FieldOrder(0)]
        [FieldBitLength(1)]
        public bool NotUsed3 { get; set; }
    }
}
