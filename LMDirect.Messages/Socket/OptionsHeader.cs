using BinarySerialization;
using LMDirect.Framework.Common;


namespace LMDirect.Messages.Socket
{
    public class OptionsHeader
    {
        [FieldOrder(0)]
        [FieldLength(1)]
        public Options OptionsByte { get; set; }

        [FieldOrder(1)]
        [FieldLength(1)]
        [SerializeWhen("OptionsByte.IsMobileID", true)]
        public short MobileIDFieldLength { get; set; }

        [FieldOrder(2)]
        [FieldLength("MobileIDFieldLength")]
        [SerializeWhen("OptionsByte.IsMobileID", true)]
        public byte[] MobileID { get; set; }
        

        [FieldOrder(3)]
        [FieldLength(1)]
        [SerializeWhen("OptionsByte.IsMobileIDType", true)]
        public short MobileIDTypeLength { get; set; }

        [FieldOrder(4)]
        [FieldLength(1)]//"MobileIDTypeLength"
        [SerializeWhen("OptionsByte.IsMobileIDType", true)]
        public MobileIDType MobileIDType { get; set; }

        [FieldOrder(5)]
        [FieldLength(1)]
        [SerializeWhen("OptionsByte.IsAuthenticationWord", true)]
        public short AuthenticationLength { get; set; }

        [FieldOrder(6)]
        [FieldLength("AuthenticationLength")]
        [SerializeWhen("OptionsByte.IsAuthenticationWord", true)]
        public byte[] Authentication { get; set; }

        [FieldOrder(7)]
        [FieldLength(1)]
        [SerializeWhen("OptionsByte.IsRouting", true)]
        public short RoutingLength { get; set; }

        [FieldOrder(8)]
        [FieldLength("RoutingLength")]
        [SerializeWhen("OptionsByte.IsRouting", true)]
        public byte[] Routing { get; set; }

        [FieldOrder(9)]
        [FieldLength(1)]
        [SerializeWhen("OptionsByte.IsForwarding", true)]
        public short ForwardingLength { get; set; }

        [FieldOrder(10)]
        [FieldLength("ForwardingLength")]
        [SerializeWhen("OptionsByte.IsForwarding", true)]
        public byte[] Forwarding { get; set; }

        [FieldOrder(11)]
        [FieldLength(1)]
        [SerializeWhen("OptionsByte.IsResponseRedirection", true)]
        public short ResponseRedirectionLength { get; set; }

        [FieldOrder(12)]
        [FieldLength("ResponseRedirectionLength")]
        [SerializeWhen("OptionsByte.IsResponseRedirection", true)]
        public byte[] ResponseRedirection { get; set; }

        [FieldOrder(13)]
        [FieldLength(1)]
        [SerializeWhen("OptionsByte.IsOptionsExtension", true)]
        public short OptionsExtensionLength { get; set; }

        [FieldOrder(14)]
        [FieldLength("OptionsExtensionLength")]
        [SerializeWhen("OptionsByte.IsOptionsExtension", true)]
        public OptionsExtension OptionsExtension { get; set; }
    }

}
