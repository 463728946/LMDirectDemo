using LMDirect.Messages.Socket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LMDirect.Core.Entities
{    
    public class EventReport
    {

        public string MobileID { get; set; }

        public MobileIDType MobileIDType { get; set; }

        public ServiceType ServiceType { get; set; }

        public MessageType MessageType { get; set; }

        public int SequenceNumber { get; set; }

        /// <summary>
        /// The time tag of the message in seconds, referenced from Jan. 1, 1970
        /// </summary>
        public DateTime UpdateTime { get; set; }

        /// <summary>
        /// The last known time of fix from the GPS satellites. This value is reported in seconds from Jan. 1, 1970
        /// </summary>
        public DateTime TimeOfFix { get; set; }

        /// <summary>
        /// The latitude reading of the GPS receiver, measured in degrees with a 1x10^-7 degree lsb, signed 2’s complement
        /// </summary>
        public double Latitude { get; set; }

        /// <summary>
        /// The longitude reading of the GPS receiver, measured in degrees with a 1x10^-7 degree lsb, signed 2’s complement
        /// </summary>
        public double Longitude { get; set; }

        /// <summary>
        /// The altitude reading of the GPS receiver measured in centimeters above the WGS-84 Datum, signed 2’s complement
        /// </summary>
        public int Altitude { get; set; }

        /// <summary>
        /// The speed as reported by the GPS receiver, measured in centimeters per second
        /// </summary>
        public int Speed { get; set; }

        /// <summary>
        /// The heading value reported in degrees from true North
        /// </summary>
        public int Heading { get; set; }

        /// <summary>
        /// The number of satellites used in the GPS solution
        /// </summary>
        public double Satellites { get; set; }

        /// <summary>
        /// The current fix status of the GPS receiver bitmapped as follows:
        /// </summary>

        public FixStatus FixStatus { get; set; }

        /// <summary>
        /// The identifier of the Carrier/Operator the wireless modem is currently using. For GSM, HSPA, and LTE networks, this is the MNC (mobile network code). For CDMA networks this is the SID (system identification number).
        /// </summary>
        public string Carrier { get; set; }

        /// <summary>
        /// The received signal strength of the wireless modem in dBm. This value is signed in a 2’s complement format.
        /// </summary>
        public string RSSI { get; set; }

        /// <summary>
        /// The current state of the wireless modem bit mapped as follows
        /// </summary>
        public CommState CommState { get; set; }

        /// <summary>
        /// The GPS Horizontal Dilution of Precision - it is a unit-less value reported with a 0.1 lsb.
        /// </summary>
        public string HDOP { get; set; }

        /// <summary>
        /// The current state of the inputs, bit mapped as follows:
        /// </summary>

        public string Inputs { get; set; }

        /// <summary>
        /// Status of key modules within the unit:
        ///Bit 0 – LMU32: HTTP OTA Update Status (0=OK, 1=Error), LMU8: Unused
        ///Bit 1 – GPS Antenna Status (0=OK, 1=Error)
        ///Bit 2 – GPS Receiver Self-Test (0=OK, 1=Error) (LMU32 only)
        ///Bit 3 – GPS Receiver Tracking (0=Yes, 1=No)
        ///Bit 4 – Reserved, Currently Unused
        ///Bit 5 – Reserved, Currently Unused
        ///Bit 6 – Reserved, Currently Unused
        ///Bit 7 – Unused
        /// </summary>
        public string UnitStatus { get; set; }

        /// <summary>
        /// The index number of the event that generated the report; values should range from 0-249. 255 represents a Real Time PEG Action request.
        /// </summary>
        public int EventIndex { get; set; }

        /// <summary>
        /// The event code assigned to the report as specified by the event’s Action Parameter
        /// </summary>
        public int EventCode { get; set; }

        /// <summary>
        /// The number of 4-byte values in the AccumList and the Accumulator Reporting Format Type (upper 2 bits). Refer to Appendix G, ‘Accumulator Reporting Formats’ for details.
        /// </summary>
        public string Accums { get; set; }

        /// <summary>
        /// This bit-mapped byte is used to indicate the presence, when corresponding bit is set, of specific data types appended to the end of the Event Report following the list of accumulators. Each data type starts with a single length byte followed by the data. If multiple data types are present, they shall appear in order of the bits set in the ‘Append’ byte, starting with bit 0.
        /// Bit 0 – Cell Info (see ‘Appended Data’ section below).Bit 1 thru 7 – reserved, set to zero (0).
        /// </summary>
        public string Append { get; set; }

        /// <summary>
        /// A list of ‘n’ 4-byte fields where ‘n’ is defined in the Accums field. The format for this list is dependent upon the Accumulator Reporting Format Type also defined in the Accums field. Refer to Appendix G, ‘Accumulator Reporting Formats’ for details.
        /// </summary>
        public string AccumList { get; set; }

    }
}
