using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using TL.Pneumax_PC_1700.API;
using TL.Pneumax_PC_1700.API.Enums;
using TL.Pneumax_PC_1700.API.Interfaces.Public;

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
            Mock<IPneumax_PC_1700_Driver> driver = new Mock<IPneumax_PC_1700_Driver>();
            driver.Setup(x => x.SetPressure(value)).Returns(true);
            Pneumax_PC_1700 pneumax = new Pneumax_PC_1700(model, driver.Object);
            bool isPressureSet = pneumax.SetPressure(value);

            Assert.That(isPressureSet, Is.EqualTo(false));
        }

        [Test]
        [TestCase(PneumaxModel.Model_1_Bar, -1, false)]
        [TestCase(PneumaxModel.Model_5_Bar, -1, false)]
        [TestCase(PneumaxModel.Model_9_Bar, -1, false)]
        public void TestWhetherPressureLowerThanAllowedForModelCannotBeSet(PneumaxModel model, int value, bool expected)
        {
            Mock<IPneumax_PC_1700_Driver> driver = new Mock<IPneumax_PC_1700_Driver>();
            driver.Setup(x => x.SetPressure(value)).Returns(true);
            Pneumax_PC_1700 pneumax = new Pneumax_PC_1700(model, driver.Object);

            bool isPressureSet = pneumax.SetPressure(value);

            Assert.That(isPressureSet, Is.EqualTo(expected));
        }

        [Test]
        [TestCase(PneumaxModel.Model_1_Bar, 50, 50)]
        public void TestWhetherDesiredPresureIsSetProperly(PneumaxModel model, int value, int expected)
        {
            Mock<IPneumax_PC_1700_Driver> driver = new Mock<IPneumax_PC_1700_Driver>();
            driver.Setup(x => x.SetPressure(value)).Returns(true);
            Pneumax_PC_1700 pneumax = new Pneumax_PC_1700(model, driver.Object);

            pneumax.SetPressure(value);

            Assert.That(pneumax.DesiredPresure, Is.EqualTo(expected));
        }

        [Test]
        [TestCase(PneumaxModel.Model_1_Bar, 50)]
        public void TestWhetherDesiredPresureReatainsAfterFailSetNewValue(PneumaxModel model, int value)
        {
            Mock<IPneumax_PC_1700_Driver> driver = new Mock<IPneumax_PC_1700_Driver>();
            driver.Setup(x => x.SetPressure(value)).Returns(true);
            Pneumax_PC_1700 pneumax = new Pneumax_PC_1700(model, driver.Object);

            pneumax.SetPressure(value);
            int oldValue = pneumax.DesiredPresure;

            driver.Setup(x => x.SetPressure(value)).Returns(false);
            pneumax.SetPressure(value);

            Assert.That(pneumax.DesiredPresure, Is.EqualTo(oldValue));
        }

        [Test]
        [TestCase(PneumaxModel.Model_1_Bar, 50)]
        public void TestWhetherDesiredPresureIsNotSetWhenPreviousValueIsTheSameAsNew(PneumaxModel model, int value)
        {
            Mock<IPneumax_PC_1700_Driver> driver = new Mock<IPneumax_PC_1700_Driver>();
            driver.Setup(x => x.SetPressure(value)).Returns(true);
            Pneumax_PC_1700 pneumax = new Pneumax_PC_1700(model, driver.Object);

            bool resultForFirstSet = pneumax.SetPressure(value);
            bool resultForSecondSet = pneumax.SetPressure(value);

            Assert.That(resultForFirstSet, Is.True);
            Assert.That(resultForSecondSet, Is.False);
        }

        [Test]
        [TestCase(PneumaxModel.Model_1_Bar, AnalogInputValue.UserSet, AnalogInputValue.UserSet)]
        public void TestWhetherAnalogInputValueIsSetProperly(PneumaxModel model, AnalogInputValue value, AnalogInputValue expected)
        {
            Mock<IPneumax_PC_1700_Driver> driver = new Mock<IPneumax_PC_1700_Driver>();
            driver.Setup(x => x.SetAnalogInputValue(value)).Returns(true);

            Pneumax_PC_1700 pneumax = new Pneumax_PC_1700(model, driver.Object);

            pneumax.SetAnalogInputValue(value);

            Assert.That(pneumax.AnalogInputValue, Is.EqualTo(expected));
        }

        [Test]
        public void TestWhetherSettingAnalogInputValueForUndefinedValueThrowsException()
        {
            Mock<IPneumax_PC_1700_Driver> driver = new Mock<IPneumax_PC_1700_Driver>();
            driver.Setup(x => x.SetAnalogInputValue((AnalogInputValue)5)).Returns(true);

            Pneumax_PC_1700 pneumax = new Pneumax_PC_1700(PneumaxModel.Model_1_Bar, driver.Object);

            Assert.Throws<NotSupportedException>(() => pneumax.SetAnalogInputValue((AnalogInputValue)5));
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