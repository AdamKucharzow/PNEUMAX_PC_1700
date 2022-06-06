using PNEUMAX_PC_1700_DRIVER.Driver.Enums;

namespace PNEUMAX_PC_1700_DRIVER.Driver.Interfaces
{
    internal interface IPneumaxCommand
    {
        byte Header { get; }

        OperatingCode Code { get; }

        byte LowByte { get; }

        byte HighByte { get; }
    }
}
