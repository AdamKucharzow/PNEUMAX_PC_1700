namespace PNEUMAX_PC_1700_DRIVER.Driver.Enums
{
    internal enum ReplyCode : byte
    {
        /// <summary>
        /// Regulator has been reset.
        /// </summary>
        Reset = 0x81,

        /// <summary>
        /// Given parameter's value read.
        /// </summary>
        ReadParameter = 0x8D,

        /// <summary>
        /// Value to given parameter set.
        /// </summary>
        WriteParameter = 0xE1,

        /// <summary>
        /// Desired pressure value written.
        /// </summary>
        WriteDesiredPressureValue = 0xA1,

        /// <summary>
        /// Desired pressure value set.
        /// </summary>
        SetDesiredPressureValue = 0xA2,

        /// <summary>
        /// Desired pressure value read.
        /// </summary>
        ReadDesiredPressureValue = 0xAF,

        /// <summary>
        /// Outlet pressure value read.
        /// </summary>
        ReadOutletPressureValue = 0xBF,

        /// <summary>
        /// Desired pressure and reference source read.
        /// </summary>
        ReadDesiredPressureAndReferenceSource = 0xCF,
    }
}
