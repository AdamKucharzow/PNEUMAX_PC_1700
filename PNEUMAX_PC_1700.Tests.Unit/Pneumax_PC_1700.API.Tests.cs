using NUnit.Framework;
using TL.PMEUMAX_PC_1700.Driver.API;
using TL.PMEUMAX_PC_1700.Driver;
using Moq;

namespace PNEUMAX_PC_1700.Tests.Unit
{
    public class Tests
    {
        [Test]
        public void TestWhetherProperModelIsInitializedProperly()
        {            
            PneumaxModel model = PneumaxModel.Model_1_Bar;

            Pneumax_PC_1700 pneumaxDriver = new Pneumax_PC_1700(model);

            Assert.That(pneumaxDriver.Model.Equals(model));
        }

        public void TestWhetherPressureHigherThanAllowedForModelCannotBeSet()
        {
            PneumaxModel model = PneumaxModel.Model_1_Bar;
            ICommandSender commandSender = Mock.Of<ICommandSender>();
            Pneumax_PC_1700 pneumaxDriver = new Pneumax_PC_1700(model, commandSender);
            int pressureToSet = 101;

            bool isPressureSet = pneumaxDriver.SetPressure(pressureToSet);

            Assert.That(isPressureSet.Equals(false));
        }
    }
}