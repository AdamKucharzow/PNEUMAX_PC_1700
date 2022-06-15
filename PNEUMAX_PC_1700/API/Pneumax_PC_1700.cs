using System;
using TL.Pneumax_PC_1700.API.Enums;
using TL.Pneumax_PC_1700.API.Interfaces.Public;

namespace TL.Pneumax_PC_1700.API
{
    public class Pneumax_PC_1700
    {
        private readonly PneumaxModel model;
        private IPneumax_PC_1700_Driver driver;
        private MaximumAllowableInputs maximumAllowableInputs;
        private int desiredPressure;
        private AnalogInputValue analogInputValue;
        private InterventionMode interventionMode;
        private ReferenceSource referenceSource;
        private UnitOfMeasurement unitOfMeasurement;
        private VoltageAnalogOutput voltageAnalogOutput;
        private ProtectionMode protectionMode;

        public Pneumax_PC_1700(PneumaxModel pneumaxModel, IPneumax_PC_1700_Driver driver)
        {
            this.model = pneumaxModel;
            this.driver = driver;
            this.CreateMaximumAllowableInputs(this.model);
        }

        private void CreateMaximumAllowableInputs(PneumaxModel model)
        {
            //TODO: This should be changed to something more manaeable.
            switch (model)
            {
                case PneumaxModel.Model_1_Bar:
                    this.maximumAllowableInputs = new MaximumAllowableInputs() { MaximumPressure = 100 };
                    break;
                case PneumaxModel.Model_5_Bar:
                    this.maximumAllowableInputs = new MaximumAllowableInputs() { MaximumPressure = 500 };
                    break;
                case PneumaxModel.Model_9_Bar:
                    this.maximumAllowableInputs = new MaximumAllowableInputs() { MaximumPressure = 900 };
                    break;
                default:
                    throw new NotSupportedException($"Not supported model {model}.");
            }
        }

        public PneumaxModel Model => model;

        public AnalogInputValue AnalogInputValue => this.analogInputValue;

        public int DesiredPresure => this.desiredPressure;

        public InterventionMode InterventionMode => this.interventionMode;

        public ReferenceSource ReferenceSource => this.referenceSource;

        public UnitOfMeasurement UnitOfMeasurement => this.unitOfMeasurement;

        public VoltageAnalogOutput VoltageAnalogOutput => this.voltageAnalogOutput;

        public ProtectionMode ProtectionMode => this.protectionMode;

        public void SetInsensitivity()
        {
        }

        public bool SetAnalogInputValue(AnalogInputValue value)
        {
            if (Enum.IsDefined(typeof(AnalogInputValue), value) == false)
                throw new NotSupportedException($"{typeof(AnalogInputValue).Name} '{value}' is not supported");
            bool result = this.driver.SetAnalogInputValue(value);

            if (result)
                this.analogInputValue = value;

            return result;
        }

        public bool SetInterventionMode(InterventionMode value)
        {
            return this.driver.SetInterventionMode(value);
        }

        public void SetReferenceSource(ReferenceSource value)
        {
            throw new NotImplementedException();
        }

        public void SetUnitOfMeasurement(UnitOfMeasurement value)
        {
            throw new NotImplementedException();
        }

        public void SetVoltageAnalogOutput(VoltageAnalogOutput value)
        {
            throw new NotImplementedException();
        }

        public bool SetPressure(int hundredthsOfBar)
        {
            if (this.maximumAllowableInputs.MaximumPressure < hundredthsOfBar || this.maximumAllowableInputs.MinimumPressure > hundredthsOfBar)
            {
                return false;
            }

            if (this.desiredPressure == hundredthsOfBar)
                return false;

            bool result = this.driver.SetPressure(hundredthsOfBar);
            if (result)
                this.desiredPressure = hundredthsOfBar;

            return result;
        }

        private struct MaximumAllowableInputs
        {            
            public int MaximumPressure { get; set; }

            public int MinimumPressure { get; set; }

            public void SetProtectionMode(ProtectionMode value)
            {
                throw new NotImplementedException();
            }
        }

        public void SetProtectionMode(ProtectionMode value)
        {
            throw new NotImplementedException();
        }
    }
}
