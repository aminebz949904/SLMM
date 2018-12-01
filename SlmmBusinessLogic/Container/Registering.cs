using IO.Swagger.Api.Slmm.HttpClient;
using Slmm.BusinessLogic.Interfaces;
using Slmm.BusinessLogic.Services;
using StructureMap;

namespace Slmm.BusinessLogic.Container
{
    public class Registering : Registry
    {
        public Registering()
        {
            Scan(x =>
            {
                x.Assembly("Slmm.BusinessLogic");
                x.WithDefaultConventions();
            });
            For<ISlmmMove>().Use<SlmmMoveNorthService>().Named("SlmmMoveNorthService");
            For<ISlmmMove>().Use<SlmmMoveSouthService>().Named("SlmmMoveSouthService");
            For<ISlmmMove>().Use<SlmmMoveEastService>().Named("SlmmMoveEastService");
            For<ISlmmMove>().Use<SlmmMoveWestService>().Named("SlmmMoveWestService");
         //   For<IMowerApiHttpClient>().Use(new MowerApiHttpClient("http://localhost:611777"));

        }
    }
}
