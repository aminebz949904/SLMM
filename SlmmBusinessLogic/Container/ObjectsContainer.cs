
namespace Slmm.BusinessLogic.Container
{
    public static class ObjectsContainer
    {
        public static T GetObject<T>()
        {
            return StartUp.SlmmContainer.GetInstance<T>();
        }

        public static void InjectObject<T>(object objectToInject)
        {
            StartUp.SlmmContainer.Inject(typeof(T), objectToInject);
        }

        public static T GetObjectByName<T>(string name)
        {
            return StartUp.SlmmContainer.GetInstance<T>(name);
        }

        public static void Reset()
        {
            StartUp.SlmmContainer = new StructureMap.Container(new Registering());
        }
    }
}
