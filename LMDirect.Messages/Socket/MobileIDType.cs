using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMDirect.Messages.Socket
{
    public enum MobileIDType
    {
        OFF,
        /// <summary>
        /// Electronic Serial Number (ESN) of the LMU
        /// </summary>
        ESN,

        /// <summary>
        /// International Mobile Equipment Identifier (IMEI) or Electronic Identifier (EID) of the wireless modem
        /// </summary>
        Equipment,

        /// <summary>
        /// International Mobile Subscriber Identifier (IMSI) of the SIM card (GSM/GPRS devices only)
        /// </summary>
        Subscriber,

        /// <summary>
        /// User Defined Mobile ID
        /// </summary>
        Defined,

        /// <summary>
        /// Phone Number of the mobile (if available)
        /// </summary>
        PhoneNumber,

        /// <summary>
        /// The current IP Address of the LMU
        /// </summary>
        IPAddress,

        /// <summary>
        /// CDMA Mobile Equipment ID (MEID) or International Mobile Equipment Identifier (IMEI) of the wireless modem
        /// </summary>
        CDMA
    }
}
