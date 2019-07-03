using LMDirect.Messages.Socket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMDirect.Messages
{
    public class Log
    {
        public int SequenceNumber { get; set; }
        public string MessageType { get; set; }
        public string EventCode { get; set; }
        public double Speed { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdateTime { get; set; }


        public string MobileID { get; set; }
        public string ServiceType { get; set; }                        
        public uint Altitude { get; set; }        
        public ushort Heading { get; set; }
        public string RawData { get; set; }
        public SocketMessage Decoded { get; set; }
    }


}
