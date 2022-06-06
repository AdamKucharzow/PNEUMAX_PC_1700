using TL.Pneumax_PC_1700.API.Enums;
using TL.Pneumax_PC_1700.API.Interfaces.Public;

namespace TL.Pneumax_PC_1700.Driver
{
    public class Pneumax_PC_1700_Driver : IPneumax_PC_1700_Driver
    {
        public bool SetAnalogInputValue(AnalogInputValue value)
        {
            throw new System.NotImplementedException();
        }

        public bool SetInterventionMode(InterventionMode value)
        {
            throw new System.NotImplementedException();
        }

        public bool SetPressure(int desiredPressure)
        {
            throw new System.NotImplementedException();
        }
    }
}
