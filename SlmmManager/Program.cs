using System;
using System.Configuration;
using IO.Swagger.Api.Slmm.HttpClient;
using Slmm.BusinessLogic.Container;
using Slmm.BusinessLogic.Interfaces;
using Slmm.Model;


namespace SlmmManager
{
    public class Program
    {
        static void Main(string[] args)
        {
            var basePath = ConfigurationManager.AppSettings["baseUrl"];
            if (string.IsNullOrWhiteSpace(basePath))
            {
                throw new Exception("Missing basePath config");
            }
            StartUp.SlmmContainer.Configure(x => x.For<IMowerApiHttpClient>().Use<MowerApiHttpClient>()
                .Ctor<string>("basePath").Is(basePath));
            var slmmService = ObjectsContainer.GetObject<ISlmmService>();
            slmmService.SmartMower = new SmartMowerMachine();
            slmmService.SmartMower.ReadFromConfig();
            slmmService.StartMovingSlmm();
            Console.ReadLine();
        }
    }
}
