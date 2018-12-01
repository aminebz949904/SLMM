using Slmm.Model;
using Slmm.BusinessLogic.Interfaces;

namespace Slmm.BusinessLogic.Services
{
    public class SlmmMoveEastService : SlmmMoveBase, ISlmmMove
    {
        public SlmmMoveEastService(IMowerHttpClient mowerHttpClient) : base(mowerHttpClient)
        {
        }
        public void MoveOneStep(ISlmmService slmm)
        {
            slmm.Clockwise = false;
            slmm.Turn90();
            slmm.Clockwise = true;
            slmm.SmartMower.Direction = DirectionEnum.Direction.North;
            slmm.SlmMove = slmm.GetSlmmMoveDirection();
            base.PrintPosition(slmm.SmartMower);
        }

        
    }
}
