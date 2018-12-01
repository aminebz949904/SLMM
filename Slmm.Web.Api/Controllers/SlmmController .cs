using Microsoft.AspNetCore.Mvc;
using Slmm.Api;
using Slmm.Model;

namespace Slmm.Web.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    public class SlmmController : Controller
    {

        [HttpPost]
        public void MoveForward([FromBody]SmartMowerMachine mowerMachine)
        {
            MowerState.MowerMachine = mowerMachine;
            System.Threading.Thread.Sleep(5000);
        }


        [HttpPost]
        public void Turn90Clockwise([FromBody]SmartMowerMachine mowerMachine)
        {
            MowerState.MowerMachine = mowerMachine;
            System.Threading.Thread.Sleep(2000);
        }

        [HttpPost]
        public void Turn90AntiClockwise([FromBody]SmartMowerMachine mowerMachine)
        {
            MowerState.MowerMachine = mowerMachine;
            System.Threading.Thread.Sleep(2000);
        }

        [HttpGet]
        public SmartMowerMachine GetCurrentPosition()
        {
            return MowerState.MowerMachine;
        }

    }
}
