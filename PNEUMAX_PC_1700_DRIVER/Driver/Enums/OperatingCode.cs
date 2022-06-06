namespace PNEUMAX_PC_1700_DRIVER.Driver.Enums
{
    internal enum OperatingCode : byte
    {
        /// <summary>
        /// Resets the regulator.
        /// 01(h)
        /// </summary>
        Reset = 0x01,

        /// <summary>
        /// Reads given parameter's value.
        /// 0D(h)
        /// </summary>
        ReadParameter = 0xD,

        /// <summary>
        /// Writes value to given parameter.
        /// </summary>
        WriteParameter = 0x61,

        /// <summary>
        /// Writes desired pressure value.
        /// </summary>
        WriteDesiredPressureValue = 0x21,

        /// <summary>
        /// Sets desired pressure value.
        /// </summary>
        SetDesiredPressureValue = 0x22,

        /// <summary>
        /// Reads desired pressure value.
        /// </summary>
        ReadDesiredPressureValue = 0x2F,

        /// <summary>
        /// Reads outlet pressure value.
        /// </summary>
        ReadOutletPressureValue = 0x3F,

        /// <summary>
        /// Desired pressure and reference source reading.
        /// </summary>
        ReadDesiredPressureAndReferenceSource = 0x4F,
    }
}
