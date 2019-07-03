using BinarySerialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LMDirect.Framework.Common;

namespace LMDirect.Messages.Socket
{
    public abstract class BaseReportContents : IMessageContents
    {
        [FieldOrder(0)]
        [FieldLength(4)]
        public byte[] UpdateTime { get; set; }

        [FieldOrder(1)]
        [FieldLength(4)]
        public byte[] TimeOfFix { get; set; }

        [FieldOrder(2)]
        [FieldLength(4)]
        [FieldScale(10000000)]
        [SerializeAs(SerializedType.Int4)]
        [FieldEndianness(Endianness.Big)]
        public double Latitude { get; set; }

        [FieldOrder(3)]
        [FieldLength(4)]
        [FieldScale(10000000)]
        [SerializeAs(SerializedType.Int4)]
        [FieldEndianness(Endianness.Big)]
        public double Longitude { get; set; }

        [FieldOrder(4)]
        [FieldLength(4)]
        [SerializeAs(SerializedType.UInt4)]
        [FieldEndianness(Endianness.Big)]
        public uint Altitude { get; set; }

        [FieldOrder(5)]
        [FieldLength(4)]
        [SerializeAs(SerializedType.UInt4)]
        [FieldEndianness(Endianness.Big)]
        public uint Speed { get; set; }

        [FieldOrder(6)]
        [FieldLength(2)]
        [SerializeAs(SerializedType.UInt2)]
        [FieldEndianness(Endianness.Big)]
        public ushort Heading { get; set; }

        [FieldOrder(7)]
        [FieldLength(1)]
        public byte Satellites { get; set; }

        [FieldOrder(8)]
        [FieldLength(1)]
        public FixStatus FixStatus { get; set; }

        [FieldOrder(9)]
        [FieldLength(2)]
        [SerializeAs(SerializedType.UInt2)]
        [FieldEndianness(Endianness.Big)]
        public ushort Carrier { get; set; }

        [FieldOrder(10)]
        [FieldLength(2)]
        [SerializeAs(SerializedType.UInt2)]
        [FieldEndianness(Endianness.Big)]
        public ushort RSSI { get; set; }

        [FieldOrder(11)]
        [FieldLength(1)]
        public CommState CommState { get; set; }

        [FieldOrder(12)]
        [FieldLength(1)]
        public byte HDOP { get; set; }

        [FieldOrder(13)]
        [FieldLength(1)]
        public byte Inputs { get; set; }

        [FieldOrder(14)]
        [FieldLength(1)]
        public byte UnitStatus { get; set; }
    }

    public class FixStatus
    {
        /// <summary>
        /// Bit is set when the position update has a horizontal position accuracy estimate that is less that the Horizontal Position Accuracy Threshold defined in S-Register 142 (and the threshold is non-zero).
        /// </summary>       
        [FieldOrder(6)]
        [FieldBitLength(1)]
        public byte Predicted { get; set; }


        /// <summary>
        /// This bit is set when WAAS DGPS is enabled (S-Register 139) and the position has been differentially corrected
        /// </summary>
        [FieldOrder(5)]
        [FieldBitLength(1)]
        public byte DifferentiallyCorrected { get; set; }


        /// <summary>
        /// This bit is set when the current GPS fix is invalid but a previous fix’s value is available.
        /// </summary>
        [FieldOrder(4)]
        [FieldBitLength(1)]
        public byte LastKnown { get; set; }


        /// <summary>
        /// This bit is set only after a power-up or reset before a valid fix is obtained.
        /// </summary>
        [FieldOrder(3)]
        [FieldBitLength(1)]
        public byte InvalidFix { get; set; }

        /// <summary>
        /// This bit is set when 3 or fewer satellites are seen/used in the GPS fix. (i.e. with 3 satellites or less, an altitude value cannot be calculated)
        /// </summary>
        [FieldOrder(2)]
        [FieldBitLength(1)]
        public byte _2DFix { get; set; }

        /// <summary>
        /// This bit is set when the message has been logged by the LMU.
        /// </summary>
        [FieldOrder(1)]
        [FieldBitLength(1)]
        public byte Historic { get; set; }

        /// <summary>
        ///This bit is set only after a power-up or reset before a valid time-sync has been obtained.
        /// </summary>
        [FieldOrder(0)]
        [FieldBitLength(1)]
        public byte InvalidTime { get; set; }


    }

    public class CommState
    {
        [FieldOrder(6)]
        [FieldBitLength(1)]
        public bool Available { get; set; }
        [FieldOrder(5)]
        [FieldBitLength(1)]
        public bool NetworkService { get; set; }
        [FieldOrder(4)]
        [FieldBitLength(1)]
        public bool DataService { get; set; }
        [FieldOrder(3)]
        [FieldBitLength(1)]
        public bool Connected { get; set; }
        [FieldOrder(2)]
        [FieldBitLength(1)]
        public bool VoiceCallIsActive { get; set; }
        [FieldOrder(1)]
        [FieldBitLength(1)]
        public bool Roaming { get; set; }

        /// <summary>
        /// 00 = 2G Network (CDMA or GSM)
        /// 01 = 3G Network (UMTS)
        /// 10 = 4G Network (LTE)
        /// 11 = Reserved
        /// </summary>
        [FieldOrder(0)]
        [FieldBitLength(2)]
        //[SerializeAs(SerializedType.UInt1)]
        public NetworkTechnology NetworkTechnology { get; set; }

    }

    public enum NetworkTechnology 
    {
        _2G = 0,
        _3G = 1,
        _4G = 10,
        Reserved = 11,
    }
}
