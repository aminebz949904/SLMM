using System;
using IO.Swagger.Api.Slmm.HttpClient;
using Slmm.BusinessLogic.Interfaces;
using Slmm.Model;

namespace Slmm.BusinessLogic.Services
{
    public class MowerHttpClient : IMowerHttpClient
    {
        private readonly IMowerApiHttpClient _mowerApiHttpClient;

        public MowerHttpClient(IMowerApiHttpClient mowerApiHttpClient)
        {
            _mowerApiHttpClient = mowerApiHttpClient;
        }

        public void Turn90AntiClockwise(SmartMowerMachine smartMowerMachine)
        {
            _mowerApiHttpClient.Turn90AntiClockwise(smartMowerMachine);
            Console.WriteLine("Turn90AntiClockwise");
        }

        public void Turn90Clockwise(SmartMowerMachine smartMowerMachine)
        {
            _mowerApiHttpClient.Turn90Clockwise(smartMowerMachine);
            Console.WriteLine("Turn90Clockwise");
        }

        public void MoveForward(SmartMowerMachine smartMowerMachine)
        {
            _mowerApiHttpClient.MoveForward(smartMowerMachine);
            Console.WriteLine("MoveForward");
        }
    }
}
