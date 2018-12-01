using IO.Swagger.Api.Slmm.HttpClient;
using Slmm.BusinessLogic.Container;
using Slmm.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlmmHttpConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            StartUp.SlmmContainer.Configure(x => x.For<IMowerApiHttpClient>().Use<MowerApiHttpClient>()
                .Ctor<string>("basePath").Is(@"http://localhost:61177"));

            var httpClient = ObjectsContainer.GetObject<IMowerApiHttpClient>();
            var mower = new SmartMowerMachine(1, 1, 10, 10, DirectionEnum.Direction.East);
            httpClient.Turn90AntiClockwise(mower);
        }
    }
}
