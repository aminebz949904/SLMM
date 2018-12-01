using Slmm.Model;
using Slmm.BusinessLogic.Interfaces;

namespace Slmm.BusinessLogic.Services
{
    public class SlmmMoveWestService : SlmmMoveBase, ISlmmMove
    {
        public SlmmMoveWestService(IMowerHttpClient mowerHttpClient) : base(mowerHttpClient)
        {
        }
        public void MoveOneStep(ISlmmService slmm)
        {
            slmm.Clockwise = true;
            slmm.Turn90();
            slmm.SmartMower.Direction = DirectionEnum.Direction.North;
            slmm.SlmMove = slmm.GetSlmmMoveDirection();
            base.PrintPosition(slmm.SmartMower);
        }

        
    }
}
