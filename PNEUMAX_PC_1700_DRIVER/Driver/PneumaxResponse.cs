using PNEUMAX_PC_1700_DRIVER.Driver.Enums;
using PNEUMAX_PC_1700_DRIVER.Driver.Interfaces;

namespace TL.Pneumax_PC_1700
{
    class PneumaxResponse : IPneumaxResponse
    {
        public byte Header => throw new System.NotImplementedException();

        public ReplyCode Code => throw new System.NotImplementedException();

        public byte LowByte => throw new System.NotImplementedException();

        public byte HighByte => throw new System.NotImplementedException();
    }
}
