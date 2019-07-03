using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMDirect.Messages.Socket
{
    public enum MessageType
    {
        Null,
        ACK_NAK,
        EventReport,
        IDReport,
        UserData,
        ApplicationData,
        ConfigurationParameter,
        UnitRequest,
        LocateReport,
        UserDataWithAccumulators,
        MiniEventReport,
        MiniUserData,
        MiniApplication,
        DeviceVersion,
        ApplicationMessageWithAccumulators
    }
}
