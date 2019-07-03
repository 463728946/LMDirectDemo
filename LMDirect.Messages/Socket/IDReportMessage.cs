using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BinarySerialization;

namespace LMDirect.Messages.Socket
{
    public class IDReportMessage:IMessageContents
    {
        [FieldOrder(0)]
        [FieldLength(1)]
        public byte ScriptVersion { get; set; }

        [FieldOrder(1)]
        [FieldLength(1)]
        public byte ConfigVersion { get; set; }

        [FieldOrder(2)]
        [FieldLength(3)]
        public byte[] AppVersion { get; set; }

        [FieldOrder(3)]
        [FieldLength(1)]
        public byte VehicleVersion { get; set; }

        [FieldOrder(4)]
        [FieldLength(1)]
        public UnitStatus UnitStatus { get; set; }

        [FieldOrder(5)]
        [FieldLength(1)]
        public byte ModemSelection { get; set; }

        [FieldOrder(6)]
        [FieldLength(1)]
        public byte ApplicationID { get; set; }

        /// <summary>
        ///  S-Register 145
        /// </summary>
        [FieldOrder(7)]
        [FieldLength(1)]        
        public byte MobileIDType { get; set; }

        [FieldOrder(8)]
        [FieldLength(4)]
        public byte[] QueryID { get; set; }

        [FieldOrder(9)]
        [FieldLength(8)]
        public string ESN { get; set; }

        [FieldOrder(10)]
        [FieldLength(8)]
        public string IMEI { get; set; }

        [FieldOrder(11)]
        [FieldLength(8)]
        public string IMSI { get; set; }

        [FieldOrder(12)]
        [FieldLength(8)]
        public string MIN { get; set; }

        [FieldOrder(13)]
        [FieldLength(10)]
        public string ICCID { get; set; }

        [FieldOrder(14)]
        public byte[] ExtensionStrings { get; set; }

    }

    public class UnitStatus
    {
        /// <summary>
        /// Bit 0 – LMU32: HTTP OTA Update Status(0=OK, 1=Error), LMU8: Unused
        /// </summary>
        [FieldOrder(7)] 
        [FieldBitLength(1)]
        LMU32Status OTAUpdateStatus { get; set; }

        /// <summary>
        /// Bit 1 – GPS Antenna Status (0=OK, 1=Error)
        /// </summary>
        [FieldOrder(6)] 
        [FieldBitLength(1)]
        LMU32Status GPSAntennaStatus { get; set; }

        /// <summary>
        /// Bit 2 – GPS Receiver Self-Test (0=OK, 1=Error) (LMU32 only)
        /// </summary>
        [FieldOrder(5)]
        [FieldBitLength(1)]
        LMU32Status GPSReceiverSelfTest { get; set; }

        /// <summary>
        /// Bit 3 – GPS Receiver Tracking (0=Yes, 1=No)
        /// </summary>
        [FieldOrder(4)]
        [FieldBitLength(1)]
        LMU32Status GPSReceiverTracking { get; set; }


        /// <summary>
        /// Bit 4 – VBus disabled due to errors
        /// </summary>
        [FieldOrder(3)]
        [FieldBitLength(1)]
        bool VBusDisabledDueToErrors { get; set; }

        /// <summary>
        /// Bit 5 – Reserved, Currently Unused
        /// </summary>
        [FieldOrder(2)]
        [FieldBitLength(1)]
        bool Reserved1 { get; set; }

        /// <summary>
        /// Bit 6 – Reserved, Currently Unused
        /// </summary>
        [FieldOrder(1)]
        [FieldBitLength(1)]
        bool Reserved2 { get; set; }

        /// <summary>
        /// Bit 7 – Reserved, Currently Unused
        /// </summary>
        [FieldOrder(0)]
        [FieldBitLength(1)]
        bool Reserved3 { get; set; }

    }

    public enum LMU32Status
    {
        OK,ERROR
    }
}
