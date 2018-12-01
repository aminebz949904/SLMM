using Moq;
using NUnit.Framework;
using Slmm.BusinessLogic.Container;
using Slmm.BusinessLogic.Interfaces;
using Slmm.Model;

namespace Slmm.BusinessLogic.Test.Unit
{
    [TestFixture()]
    public class SlmmMoveWestServiceTest
    {
        [Test]
        [TestCase(5, 5, 10, 10, DirectionEnum.Direction.West, 5, 5, DirectionEnum.Direction.North, 1, 0)]
        [TestCase(10, 9, 10, 10, DirectionEnum.Direction.West, 10, 9, DirectionEnum.Direction.North, 1, 0)]
        [TestCase(1, 1, 10, 10, DirectionEnum.Direction.West, 1, 1, DirectionEnum.Direction.North, 1, 0)]
        [TestCase(1, 10, 10, 10, DirectionEnum.Direction.West, 1, 10, DirectionEnum.Direction.North, 1, 0)]
        [TestCase(10, 10, 10, 10, DirectionEnum.Direction.West, 10, 10, DirectionEnum.Direction.North, 1, 0)]
        public void MoveOneSteptest(int currentX, int currentY, int maxX, int maxY, DirectionEnum.Direction direction, int expectedCurrentX, int expectedCurrentY, DirectionEnum.Direction expectedDirection, int expectedClockWise90, int expectedAntiClockWise90)
        {
            //Arrange
            var mowerHttpClientMock = new Mock<IMowerHttpClient>();
            ObjectsContainer.InjectObject<IMowerHttpClient>(mowerHttpClientMock.Object);
            var slmmService = ObjectsContainer.GetObject<ISlmmService>();
            slmmService.SmartMower = new SmartMowerMachine(currentX, currentY, maxX, maxY, direction);
            var slmmMoveService = ObjectsContainer.GetObjectByName<ISlmmMove>("SlmmMoveWestService");

            //Act
            slmmMoveService.MoveOneStep(slmmService);

            //Assert
            Assert.AreEqual(expectedCurrentX, slmmService.SmartMower.CurrentX);
            Assert.AreEqual(expectedCurrentY, slmmService.SmartMower.CurrentY);
            Assert.AreEqual(expectedDirection, slmmService.SmartMower.Direction);

            mowerHttpClientMock.Verify(a => a.Turn90Clockwise(slmmService.SmartMower), Times.Exactly(expectedClockWise90));
            mowerHttpClientMock.Verify(a => a.Turn90AntiClockwise(slmmService.SmartMower), Times.Exactly(expectedAntiClockWise90));
        }
    }
}
