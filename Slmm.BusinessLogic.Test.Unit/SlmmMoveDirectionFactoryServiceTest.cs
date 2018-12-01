using System;
using IO.Swagger.Api.Slmm.HttpClient;
using Moq;
using NUnit.Framework;
using Slmm.BusinessLogic.Container;
using Slmm.BusinessLogic.Interfaces;
using Slmm.Model;

namespace Slmm.BusinessLogic.Test.Unit
{
    [TestFixture()]
    public class SlmmMoveDirectionFactoryServiceTest
    {

        [Test]
        [TestCase(DirectionEnum.Direction.East, "Slmm.BusinessLogic.Services.SlmmMoveEastService")]
        [TestCase(DirectionEnum.Direction.West, "Slmm.BusinessLogic.Services.SlmmMoveWestService")]
        [TestCase(DirectionEnum.Direction.North, "Slmm.BusinessLogic.Services.SlmmMoveNorthService")]
        [TestCase(DirectionEnum.Direction.South, "Slmm.BusinessLogic.Services.SlmmMoveSouthService")]
        public void GetSlmmMoveDirectiontest(DirectionEnum.Direction direction, string expectedType)
        {
            var mowerApiHttpClientMock = new Mock<IMowerApiHttpClient>();
            ObjectsContainer.InjectObject<IMowerApiHttpClient>(mowerApiHttpClientMock.Object);
            var slmmMoveDirectionFactoryService = ObjectsContainer.GetObject<ISlmmMoveDirectionFactoryService>();
            var res = slmmMoveDirectionFactoryService.GetSlmmMoveDirection(direction);
            Assert.AreEqual(expectedType, res.GetType().ToString());
        }

        [Test]
        public void GetSlmmMoveDirectionNotImplementedtest()
        {
            var slmmMoveDirectionFactoryService = ObjectsContainer.GetObject<ISlmmMoveDirectionFactoryService>();

            Assert.That(()=> slmmMoveDirectionFactoryService.GetSlmmMoveDirection(DirectionEnum.Direction.SouthEast),
                Throws.Exception.TypeOf<Exception>().With.Property("Message").EqualTo("Slmm Move not implemented for Direction : SouthEast"));
        } 
    }
}
