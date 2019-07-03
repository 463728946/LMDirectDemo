using BinarySerialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMDirect.Messages.Socket
{
    public class ApplicationMessage : BaseReportContents
    {

        [FieldOrder(15)]
        [FieldLength(2)]
        [SerializeAs(SerializedType.Int2)]
        [FieldEndianness(Endianness.Big)]
        public AppMsgType AppMsgType { get; set; }

        [FieldOrder(16)]
        [FieldLength(2)]
        public short AppMsgLength { get; set; }

        [FieldOrder(17)]
        [Subtype("AppMsgType", AppMsgType.TimeSync, typeof(TimeSync))]
        [Subtype("AppMsgType", AppMsgType.VBusDiagnosticsReport, typeof(VBusDiagnosticsReport))]
        public AppendixE AppMsg { get; set; }

    }

    public class AppendixE
    {

    }
    public class VBusDiagnosticsReport : AppendixE
    {
        [FieldOrder(0)]
        [SerializeUntil((byte)0)]
        public List<DTCBlockItem> BlockItem { get; set; }
    }

    public class TimeSync : AppendixE
    {
        [FieldOrder(0)]
        public byte[] Data { get; set; }
    }

    public class DTCBlockItem
    {
        [FieldOrder(0)]
        [FieldBitLength(8)]
        public DTClockType Type { get; set; }

        [FieldOrder(1)]
        [FieldLength(1)]
        public short Length { get; set; }

        [FieldOrder(2)]
        [FieldLength("Length")]
        public byte[] Data { get; set; }
    }

    public class DTClockType
    {
        [FieldOrder(3)]
        [FieldBitLength(3)]
        public SourceBus SourceBus { get; set; }


        [FieldOrder(2)]
        [FieldBitLength(1)]
        public ReportType ReportType { get; set; }

        [FieldOrder(1)]
        [FieldBitLength(3)]
        public int BusSpecificFlags { get; set; }

        [FieldOrder(0)]
        [FieldBitLength(1)]
        public int Zero { get; set; }
    }

    public enum AppMsgType
    {
        IPRequest = 10,
        IPReport = 11,
        TimeSync = 50,
        Services = 80,
        SVRMessaging = 81,
        DownloadIDReport = 100,
        DownloadAuthorization = 101,
        DownloadRequest = 102,
        DownloadUpdate = 103,
        DownloadComplete = 104,
        DownloadHTTPLMUFW = 105,
        DownloadHTTPFile = 106,
        OTADownload = 107,
        ATCommand = 110,
        VersionReport = 111,
        GPSStatusReport = 112,
        MessageStatisticsReport = 113,
        StateReport = 115,
        Geo_ZoneActionMessage = 116,
        Geo_ZoneUpdateMessage = 117,
        ProbeIDReport = 118,
        CaptureReport = 120,
        MotionLogReport = 122,
        CompressedMotionLogReport = 123,
        VBusDataReport = 130,
        VehicleIDReport = 131,
        VBusDTCReport = 132,
        VBusVINDecodeLookup = 133,
        SquarellCommandMessage = 134,
        SquarellStatusMessage = 135,
        VBusRegisterDeviceMessage = 136,
        VBusFreezeFrame = 137,
        VBusDiagnosticsReport = 139,
        VBusRemoteOBD = 140,
        VBusGroupDataReport = 142,
        VBusManagementOutbound = 145,
        VBusManagementInbound = 148,
    }
    public enum SourceBus
    {
        J1939, J1708, OBDII
    }

    public enum ReportType
    {
        All, Unreported
    }

}
