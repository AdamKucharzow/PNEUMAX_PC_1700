namespace PNEUMAX_PC_1700_DRIVER.Driver.Enums
{
    internal enum PneumaxParameters
    {
        /// <summary>
        /// P0
        /// Defines the desired regulator outlet pressure value.
        /// </summary>
        DesiredPressureFromKeyboard = 0x0,

        /// <summary>
        /// P1
        /// Defines the minimum deviation between desired pressure and outlet pressure beyond which the regulator intervenes.
        /// </summary>
        Insensitivity = 0x1,

        /// <summary>
        /// P2
        /// Defines the unit of measurement that will be used on the display to show outlet pressure and desired pressure during operation in standard mode.
        /// </summary>
        DisplayUnitOfMeasurement = 0x2,

        /// <summary>
        /// P3
        /// Defines the (minimum) outlet pressure value corresponding to the minimum value of the reference signal.
        /// The range varies according to the model of transducer used. Minimum pressure must be at least 1 bar less than maximum pressure.
        /// </summary>
        MinimumPressure = 0x3,

        /// <summary>
        /// P4
        /// Defines the (maximum) outlet pressure value corresponding to the maximum value of the reference signal.
        /// The default value and the range vary according to the model of transducer used.
        /// Maximum pressure must be at least 1 bar greater than minimum pressure.
        /// </summary>
        MaximumPressure = 0x4,

        /// <summary>
        /// P5
        /// Defines the range of the analog input signal managed by the proportional regulator (pin 8 of the15-pole connector).
        /// </summary>
        SelectingAnalogInputValue = 0x5,

        /// <summary>
        /// P6
        /// Defines the range of the voltage analog output (pin 12 of the 15-pole connector).
        /// The two limits of the range are the value of the voltage-controlled analog output corresponding to minimum
        /// and maximum outlet pressure. The output will assume all intermediate values in proportion to the outlet pressure.
        /// </summary>
        VoltageAnalogOutput = 0x6,

        /// <summary>
        /// P7
        /// Defines the range of the current analog output (pin 11 of the 15-pole connector).
        /// The two limitsof the range are the value of the current-controlled analog output corresponding to minimum
        /// and maximum outlet pressure. The output will assume all intermediate values in proportion to the outlet pressure.
        /// </summary>
        CurrentAnalogOutput = 0x7,

        /// <summary>
        /// P8
        /// The digital output provides an indication that the outlet pressure corresponds to the desired
        /// pressure. It is activated when outlet pressure falls within a range defined by a lower threshold
        /// and an upper threshold, both of which can be modified by the user. The digital output is active if
        /// the outlet pressure is greater than the desired pressure less the lower threshold and is less than
        /// the desired pressure plus the upper threshold. Example: Desired pressure: 3 bar, lower
        /// threshold: 0.5 bar, upper threshold: 0.8 bar. The digital output is active if the outlet pressure is
        /// between 2.5 bar (3 - 0.5) and 3.8 bar (3 + 0.8) (pin 10 of the 15-pole connector).
        /// </summary>
        LowerThresholdForDigitalOutput = 0x8,

        /// <summary>
        /// P9
        /// See description of parameter (P8) (pin 10 of the 15-pole connector).
        /// </summary>
        UpperThresholdForDigitalOutput = 0x9,

        /// <summary>
        /// P10
        /// Defines the reference source that the regulator has to use to set outlet pressure.
        /// </summary>
        ReferenceSource = 0x10,

        //TODO: Add parameters P11 to P17

        /// <summary>
        /// P18
        /// </summary>
        ProtectionMode = 0x12,

        /// <summary>
        /// P19
        /// </summary>
        EnablingPasswordRequest = 0x13,

        /// <summary>
        /// P20
        /// </summary>
        PasswordValue = 0x14,

        /// <summary>
        /// P21
        /// </summary>
        DefaultValue = 0x15,

        /// <summary>
        /// P22
        /// </summary>
        InterventionMode = 0x16,

        /// <summary>
        /// P23
        /// </summary>
        ReferencesValueOfMinimumPressure = 0x17,

        /// <summary>
        /// P24
        /// </summary>
        ReferenceValueOfMaximumPressure = 0x18,

        /// <summary>
        /// P25
        /// </summary>
        LinearProgressionTime = 0x19
    }
}
