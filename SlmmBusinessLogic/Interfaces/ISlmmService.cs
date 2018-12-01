using Slmm.Model;

namespace Slmm.BusinessLogic.Interfaces
{
    public interface ISlmmService
    {
        bool Clockwise { get; set; }
        ISlmmMove SlmMove { get; set; }
        SmartMowerMachine SmartMower { get; set; }

        ISlmmMove GetSlmmMoveDirection();
        void StartMovingSlmm();
        void Turn90();
    }
}