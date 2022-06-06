using TL.Pneumax_PC_1700.Driver.Enums;

namespace TL.Pneumax_PC_1700.Interfaces
{
    internal interface IPneumaxResponse
    {
        byte Header { get; }

        ReplyCode Code { get; }

        byte LowByte { get; }

        byte HighByte { get; }
    }
}
