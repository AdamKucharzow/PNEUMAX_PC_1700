using TL.Pneumax_PC_1700.Driver.Enums;
using TL.Pneumax_PC_1700.Driver.Interfaces;

namespace TL.Pneumax_PC_1700.Driver
{
    class PneumaxCommand : IPneumaxCommand
    {
        public byte Header => throw new System.NotImplementedException();

        public OperatingCode Code => throw new System.NotImplementedException();

        public byte LowByte => throw new System.NotImplementedException();

        public byte HighByte => throw new System.NotImplementedException();
    }
}
