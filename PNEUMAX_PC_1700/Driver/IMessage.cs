using TL.PMEUMAX_PC_1700.Driver.Enums;

namespace TL.PMEUMAX_PC_1700.Driver
{
    internal interface IMessage
    {
        byte Header { get; }

        PC_1700_OperatingCode Code { get; }

        byte LowByte { get; }

        byte HighByte { get; }
    }
}
