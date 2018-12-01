
using Slmm.BusinessLogic.Interfaces;

namespace Slmm.BusinessLogic.Services
{
    public class XCoordinateService : IXCoordinateService
    {
        public void CheckXValues(ISlmmService slmm)
        {
                if (slmm.Clockwise)
                {
                    if (++slmm.SmartMower.CurrentX > slmm.SmartMower.MaxX)
                    {
                        slmm.SmartMower.CurrentX = slmm.SmartMower.MaxX;
                        slmm.Clockwise = false;
                    }
                }
                else
                {
                    if (--slmm.SmartMower.CurrentX < 1)
                    {
                        slmm.SmartMower.CurrentX = 1;
                        slmm.Clockwise = true;
                    }
                }
        }
    }
}
