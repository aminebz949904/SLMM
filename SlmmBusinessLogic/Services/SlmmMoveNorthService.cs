using Slmm.Model;
using Slmm.BusinessLogic.Interfaces;

namespace Slmm.BusinessLogic.Services
{
    public class SlmmMoveNorthService : SlmmMoveBase, ISlmmMove
    {
        private readonly IXCoordinateService _xCoordinateService;
        public SlmmMoveNorthService(IXCoordinateService xCoordinateService, IMowerHttpClient mowerHttpClient) : base(mowerHttpClient)
        {
            _xCoordinateService = xCoordinateService;
        }
        public void MoveOneStep(ISlmmService slmmService)
        {
            if (++slmmService.SmartMower.CurrentY > slmmService.SmartMower.MaxY)
            {
                _xCoordinateService.CheckXValues(slmmService);

                slmmService.Turn90();
                slmmService.Turn90();
                slmmService.SmartMower.Direction = DirectionEnum.Direction.South;
                slmmService.Clockwise = false;
                slmmService.SmartMower.CurrentY = slmmService.SmartMower.MaxY;
                slmmService.SlmMove = slmmService.GetSlmmMoveDirection();

            }
            PrintPosition(slmmService.SmartMower);
        }
    }
}
