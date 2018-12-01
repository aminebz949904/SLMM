using Slmm.Model;

namespace Slmm.BusinessLogic.Interfaces
{
    public interface IMowerHttpClient
    {
        void Turn90Clockwise(SmartMowerMachine smartMowerMachine);
        void Turn90AntiClockwise(SmartMowerMachine smartMowerMachine);
        void MoveForward(SmartMowerMachine smartMowerMachine);
    }
}