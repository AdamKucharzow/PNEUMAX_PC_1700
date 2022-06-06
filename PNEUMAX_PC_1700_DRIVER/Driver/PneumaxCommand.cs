using PNEUMAX_PC_1700_DRIVER.Driver.Enums;
using PNEUMAX_PC_1700_DRIVER.Driver.Interfaces;

namespace PNEUMAX_PC_1700_DRIVER.Driver
{
    internal class PneumaxCommand : IPneumaxCommand
    {
        public byte Header => throw new System.NotImplementedException();

        public OperatingCode Code => throw new System.NotImplementedException();

        public byte LowByte => throw new System.NotImplementedException();

        public byte HighByte => throw new System.NotImplementedException();
    }
}
