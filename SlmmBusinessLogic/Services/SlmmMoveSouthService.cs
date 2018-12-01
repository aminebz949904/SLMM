using Slmm.Model;
using Slmm.BusinessLogic.Interfaces;
namespace Slmm.BusinessLogic.Services
{
    public class SlmmMoveSouthService : SlmmMoveBase, ISlmmMove
    {
        private readonly IXCoordinateService _xCoordinateService;
        public SlmmMoveSouthService(IXCoordinateService xCoordinateService, IMowerHttpClient mowerHttpClient) : base(mowerHttpClient)
        {
            _xCoordinateService = xCoordinateService;
        }
        public void MoveOneStep(ISlmmService slmmService)
        {
            
            if (--slmmService.SmartMower.CurrentY< 1)
            {
               
                slmmService.SmartMower.CurrentY = 1;
                slmmService.Turn90();
                slmmService.Turn90();
                slmmService.SmartMower.Direction = DirectionEnum.Direction.North;
                slmmService.Clockwise = true;
                _xCoordinateService.CheckXValues(slmmService);
                slmmService.SlmMove = slmmService.GetSlmmMoveDirection();

            }
            base.PrintPosition(slmmService.SmartMower);
        }
    }
}
