
using NUnit.Framework;
using NUnit.Framework.Internal;
using Slmm.BusinessLogic.Container;
using Slmm.BusinessLogic.Interfaces;
using Slmm.Model;

namespace Slmm.BusinessLogic.Test.Unit
{
    [TestFixture()]
    public class XCoordinateServiceTest
    {
        [Test]
        [TestCase(5, 5, 10, 10, DirectionEnum.Direction.East, true,  6, true)]
        [TestCase(10, 5, 10, 10, DirectionEnum.Direction.East, true, 10, false)]
        [TestCase(5, 5, 10, 10, DirectionEnum.Direction.East, false, 4, false)]
        [TestCase(1, 5, 10, 10, DirectionEnum.Direction.East, false, 1, true)]
        public void test(int currentX, int currentY, int maxX, int maxY, DirectionEnum.Direction direction, bool clockwise, int expectedCurrentX, bool expectedClockwise)
        {
            //Arrange
            var slmmService = ObjectsContainer.GetObject<ISlmmService>();
            slmmService.SmartMower = new SmartMowerMachine(currentX,  currentY,  maxX,  maxY, direction);
            slmmService.Clockwise = clockwise;
            var xCoordinateService = ObjectsContainer.GetObject<IXCoordinateService>();

            //Act
            xCoordinateService.CheckXValues(slmmService);

            //Assert
            Assert.AreEqual(expectedCurrentX, slmmService.SmartMower.CurrentX);
            Assert.AreEqual(expectedClockwise, slmmService.Clockwise);

        }
    }
}
