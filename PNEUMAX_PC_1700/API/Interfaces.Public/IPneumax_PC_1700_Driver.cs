
using TL.Pneumax_PC_1700.API.Enums;

namespace TL.Pneumax_PC_1700.API.Interfaces.Public
{
    public interface IPneumax_PC_1700_Driver
    {
        bool SetPressure(int desiredPressure);
        bool SetInterventionMode(InterventionMode value);
        bool SetAnalogInputValue(AnalogInputValue value);
    }
}
