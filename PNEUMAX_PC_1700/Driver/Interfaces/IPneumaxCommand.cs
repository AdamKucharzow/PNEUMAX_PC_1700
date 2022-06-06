using TL.Pneumax_PC_1700.Driver.Enums;

namespace TL.Pneumax_PC_1700.Driver.Interfaces
{
    internal interface IPneumaxCommand
    {
        byte Header { get; }

        OperatingCode Code { get; }

        byte LowByte { get; }

        byte HighByte { get; }
    }
}
