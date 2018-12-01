using Slmm.BusinessLogic.Interfaces;
using Slmm.Model;

namespace Slmm.BusinessLogic.Services
{
    public class SlmmService : ISlmmService
    {
        private readonly IMowerHttpClient _mowerHttpClient;
        private readonly ISlmmMoveDirectionFactoryService _slmmMoveDirectionFactoryService;
        public SlmmService(IMowerHttpClient mowerHttpClient, ISlmmMoveDirectionFactoryService slmmMoveDirectionFactoryService)
        {
            _mowerHttpClient = mowerHttpClient;
            _slmmMoveDirectionFactoryService = slmmMoveDirectionFactoryService;
            Clockwise = true;
        }

        #region Properties
        public ISlmmMove SlmMove { get; set; }
        public SmartMowerMachine SmartMower { get; set; }
        public bool Clockwise { get; set; }
        #endregion

        
        public void Turn90()
        {
            if(Clockwise)
            {
                _mowerHttpClient.Turn90Clockwise(SmartMower);
            }
            else
            {
                _mowerHttpClient.Turn90AntiClockwise(SmartMower);
            }
        }
        
        public ISlmmMove GetSlmmMoveDirection()
        {
            return _slmmMoveDirectionFactoryService.GetSlmmMoveDirection(SmartMower.Direction);
        }

        public void StartMovingSlmm()
        {
            SlmMove = GetSlmmMoveDirection();
            var i = 1;
            while (i++<= 500)
            {
              SlmMove.MoveOneStep(this);
            }
          
        }
    }
}
