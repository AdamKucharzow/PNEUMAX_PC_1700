using System;
using TL.Pneumax_PC_1700.API.Enums;
using TL.Pneumax_PC_1700.API.Interfaces.Public;
using TL.Pneumax_PC_1700.Driver;

namespace TL.Pneumax_PC_1700.API
{
    public class Pneumax_PC_1700
    {
        private readonly PneumaxModel model;
        private ICommandSender commandSender;
        private MaximumAllowableInputs maximumAllowableInputs;
        private int desiredPressure;
        private bool analogInputValue;
        private bool interventionMode;
        private bool referenceSource;
        private bool unitOfMeasurement;
        private bool voltageAnalogOutput;
        private ProtectionMode protectionMode;

        public Pneumax_PC_1700(PneumaxModel pneumaxModel, ICommandSender commandSender)
        {
            this.model = pneumaxModel;
            this.commandSender = commandSender;
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

        public object DesiredPresure => this.desiredPressure;

        public bool InterventionMode => this.interventionMode;
        
        public bool ReferenceSource => this.referenceSource;

        public bool UnitOfMeasurement => this.unitOfMeasurement;

        public bool VoltageAnalogOutput => this.voltageAnalogOutput;

        public ProtectionMode ProtectionMode => this.protectionMode;

        public void SetInsensitivity()
        {
            PneumaxCommand command = new PneumaxCommand();
            
            //this.commandSender.SendCommand()
        }

        public void SetAnalogInputValue(AnalogInputValue value)
        {
            throw new NotImplementedException();
        }

        public void SetInterventionMode(InterventionMode value)
        {
            throw new NotImplementedException();
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

        public bool TrySetPressure(int hundredthsofBar)
        {            
            if (this.maximumAllowableInputs.MaximumPressure < hundredthsofBar)
            {
                return false;
            }

            this.desiredPressure = hundredthsofBar;
            return true;
        }

        private struct MaximumAllowableInputs
        {
            public int MaximumPressure { get; set; }
        }
    }
}
