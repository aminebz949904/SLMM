
namespace Slmm.BusinessLogic.Container
{
    public static class StartUp
    {
        public static StructureMap.Container SlmmContainer;

        static StartUp()
        {
            SlmmContainer = new StructureMap.Container(new Registering());
        }
    }
}
