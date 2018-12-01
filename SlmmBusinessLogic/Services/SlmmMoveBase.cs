using Slmm.Model;
using System;
using Slmm.BusinessLogic.Interfaces;

namespace Slmm.BusinessLogic.Services
{
    public class SlmmMoveBase
    {
        private readonly IMowerHttpClient _mowerHttpClient;

        public SlmmMoveBase(IMowerHttpClient mowerHttpClient)
        {
            _mowerHttpClient = mowerHttpClient;
        }

        public void PrintPosition(SmartMowerMachine smartMowerMachine)
        {
            _mowerHttpClient.MoveForward(smartMowerMachine);
            Console.WriteLine(string.Format("( {0}, {1} ) Direction : {2} ; Time: {3}", smartMowerMachine.CurrentX, smartMowerMachine.CurrentY, smartMowerMachine.Direction, DateTime.Now.ToString("HH:mm:ss")));
        }
    }
}
