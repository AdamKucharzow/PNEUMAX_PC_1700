using NUnit.Framework;
using Moq;
using TL.Pneumax_PC_1700.API.Enums;
using TL.Pneumax_PC_1700.API.Interfaces.Public;
using TL.Pneumax_PC_1700.API;

namespace PNEUMAX_PC_1700.Tests.Unit
{
    public class Tests
    { 
        [Test]
        [TestCase(PneumaxModel.Model_1_Bar, 101, false)]
        [TestCase(PneumaxModel.Model_5_Bar, 501, false)]
        [TestCase(PneumaxModel.Model_9_Bar, 901, false)]
        public void TestWhetherPressureHigherThanAllowedForModelCannotBeSet(PneumaxModel model, int value, bool expected)
        {
            IPneumax_PC_1700_Driver driver = Mock.Of<IPneumax_PC_1700_Driver>();
            Pneumax_PC_1700 pneumax = new Pneumax_PC_1700(model, driver);
            
            bool isPressureSet = pneumax.TrySetPressure(value);

            Assert.That(isPressureSet, Is.EqualTo(expected));
        }

        [Test]
        [TestCase(PneumaxModel.Model_1_Bar, 50, true)]
        public void TestWhetherDesiredPresureIsSetProperly(PneumaxModel model, int value, int expected)
        {
            IPneumax_PC_1700_Driver driver = Mock.Of<IPneumax_PC_1700_Driver>();
            Pneumax_PC_1700 pneumax = new Pneumax_PC_1700(model, driver);

            pneumax.TrySetPressure(value);

            Assert.That(pneumax.DesiredPresure, Is.EqualTo(expected));
        }

        [Test]
        [TestCase(PneumaxModel.Model_1_Bar, AnalogInputValue.UserSet, AnalogInputValue.UserSet)]
        public void TestWhetherAnalogInputValueIsSetProperly(PneumaxModel model, AnalogInputValue value, AnalogInputValue expected)
        {
            IPneumax_PC_1700_Driver driver = Mock.Of<IPneumax_PC_1700_Driver>();
            Pneumax_PC_1700 pneumax = new Pneumax_PC_1700(model, driver);

            pneumax.SetAnalogInputValue(value);

            Assert.That(pneumax.AnalogInputValue, Is.EqualTo(expected));
        }

        [Test]
        [TestCase(PneumaxModel.Model_1_Bar, InterventionMode.AccurateMode, InterventionMode.AccurateMode)]
        public void TestWhetherInterventionModeIsSetProperly(PneumaxModel model, InterventionMode value, InterventionMode expected)
        {
            IPneumax_PC_1700_Driver driver = Mock.Of<IPneumax_PC_1700_Driver>();
            Pneumax_PC_1700 pneumax = new Pneumax_PC_1700(model, driver);

            pneumax.SetInterventionMode(value);

            Assert.That(pneumax.InterventionMode, Is.EqualTo(expected));
        }

        [Test]
        [TestCase(PneumaxModel.Model_1_Bar, ReferenceSource.AnalogInput, ReferenceSource.AnalogInput)]
        public void TestWhetherReferenceSourceIsSetProperly(PneumaxModel model, ReferenceSource value, ReferenceSource expected)
        {
            IPneumax_PC_1700_Driver driver = Mock.Of<IPneumax_PC_1700_Driver>();
            Pneumax_PC_1700 pneumax = new Pneumax_PC_1700(model, driver);

            pneumax.SetReferenceSource(value);

            Assert.That(pneumax.ReferenceSource, Is.EqualTo(expected));
        }

        [Test]
        [TestCase(PneumaxModel.Model_1_Bar, UnitOfMeasurement.Bar, UnitOfMeasurement.Bar)]
        public void TestWhetherUnitOfMeasurementIsSetProperly(PneumaxModel model, UnitOfMeasurement value, UnitOfMeasurement expected)
        {
            IPneumax_PC_1700_Driver driver = Mock.Of<IPneumax_PC_1700_Driver>();
            Pneumax_PC_1700 pneumax = new Pneumax_PC_1700(model, driver);

            pneumax.SetUnitOfMeasurement(value);

            Assert.That(pneumax.UnitOfMeasurement, Is.EqualTo(expected));
        }

        [Test]
        [TestCase(PneumaxModel.Model_1_Bar, VoltageAnalogOutput.V_0_10_Absolute, VoltageAnalogOutput.V_0_10_Absolute)]
        public void TestWhetherVoltageAnalogOutputIsSetProperly(PneumaxModel model, VoltageAnalogOutput value, VoltageAnalogOutput expected)
        {
            IPneumax_PC_1700_Driver driver = Mock.Of<IPneumax_PC_1700_Driver>();
            Pneumax_PC_1700 pneumax = new Pneumax_PC_1700(model, driver);

            pneumax.SetVoltageAnalogOutput(value);

            Assert.That(pneumax.VoltageAnalogOutput, Is.EqualTo(expected));
        }


        [Test]
        [TestCase(PneumaxModel.Model_1_Bar, ProtectionMode.Activated, ProtectionMode.Activated)]
        public void TestWhetherProtectionIsSetProperly(PneumaxModel model, ProtectionMode value, ProtectionMode expected)
        {
            IPneumax_PC_1700_Driver driver = Mock.Of<IPneumax_PC_1700_Driver>();
            Pneumax_PC_1700 pneumax = new Pneumax_PC_1700(model, driver);

            pneumax.SetProtectionMode(value);

            Assert.That(pneumax.ProtectionMode, Is.EqualTo(expected));
        }
    }
}