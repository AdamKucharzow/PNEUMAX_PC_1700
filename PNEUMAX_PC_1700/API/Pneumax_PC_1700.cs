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
        private bool analogInputValue;
        private bool interventionMode;
        private bool referenceSource;
        private bool unitOfMeasurement;
        private bool voltageAnalogOutput;
        private ProtectionMode protectionMode;

        public Pneumax_PC_1700(PneumaxModel pneumaxModel, IPneumax_PC_1700_Driver driver)
        {
            this.model = pneumaxModel;
            this.driver = driver;
            this.CreateMaximumAllowableInputs(this.model);
        }

        private void CreateMaximumAllowableInputs(PneumaxModel model)
        {
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

        public bool AnalogInputValue => this.analogInputValue;

        public int DesiredPresure => this.desiredPressure;

        public bool InterventionMode => this.interventionMode;
        
        public bool ReferenceSource => this.referenceSource;

        public bool UnitOfMeasurement => this.unitOfMeasurement;

        public bool VoltageAnalogOutput => this.voltageAnalogOutput;

        public ProtectionMode ProtectionMode => this.protectionMode;

        public void SetInsensitivity()
        {
        }

        public bool SetAnalogInputValue(AnalogInputValue value)
        {
            return this.driver.SetAnalogInputValue(value);
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
            if (this.maximumAllowableInputs.MaximumPressure < hundredthsOfBar)
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
        }

        public void SetProtectionMode(ProtectionMode value)
        {
            throw new NotImplementedException();
        }
    }
}
