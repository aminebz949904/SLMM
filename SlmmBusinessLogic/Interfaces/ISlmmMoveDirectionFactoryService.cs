using Slmm.BusinessLogic.Interfaces;
using Slmm.Model;

namespace Slmm.BusinessLogic.Interfaces
{
    public interface ISlmmMoveDirectionFactoryService
    {
        ISlmmMove GetSlmmMoveDirection(DirectionEnum.Direction direction);
    }
}