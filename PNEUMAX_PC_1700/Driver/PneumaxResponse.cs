using TL.Pneumax_PC_1700.Driver.Enums;
using TL.Pneumax_PC_1700.Interfaces;

namespace TL.Pneumax_PC_1700.Driver
{
    class PneumaxResponse : IPneumaxResponse
    {
        public byte Header => throw new System.NotImplementedException();

        public ReplyCode Code => throw new System.NotImplementedException();

        public byte LowByte => throw new System.NotImplementedException();

        public byte HighByte => throw new System.NotImplementedException();
    }
}
