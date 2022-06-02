using TL.PMEUMAX_PC_1700.Driver.Enums;

namespace TL.PMEUMAX_PC_1700.Driver
{
    internal interface IResponse
    {
        byte Header { get; }

        PC_1700_ReplyCode Code { get; }

        byte LowByte { get; }

        byte HighByte { get; }
    }
}
