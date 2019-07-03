using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMDirect.Messages.Socket
{
    public enum ServiceType
    {
        /// <summary>
        /// Unacknowledged Request
        /// </summary>
        Unacknowledged,

        /// <summary>
        /// Acknowledged Request
        /// </summary>
        Acknowledged,

        /// <summary>
        /// Response to an Acknowledged Request
        /// </summary>
        ResponseToAnAcknowledged
    }
    public enum Action
    {
        ReadRequest,
        WriteRequest,
        ReadReport,
        WriteReport,
        UpdateBegin,
        UpdateEnd
    }
}
