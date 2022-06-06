
using PNEUMAX_PC_1700_DRIVER.Driver.Enums;

namespace PNEUMAX_PC_1700_DRIVER.Driver.Interfaces
{
    internal interface IPneumaxResponse
    {
        byte Header { get; }

        ReplyCode Code { get; }

        byte LowByte { get; }

        byte HighByte { get; }
    }
}
