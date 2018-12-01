
using System;
using System.Configuration;

namespace Slmm.Model
{
    public class SmartMowerMachine
    {

        public SmartMowerMachine()
        {
        }

        public SmartMowerMachine(int currentX, int currentY, int maxX, int maxY, DirectionEnum.Direction direction)
        {
            CurrentX = currentX;
            CurrentY = currentY;
            MaxX = maxX;
            MaxY = maxY;
            Direction = direction;
        }

        public int CurrentX { get; set; }
        public int CurrentY { get; set; }
        public int MaxX { get; set; }
        public int MaxY { get; set; }
        public DirectionEnum.Direction Direction { get; set; }

        public void ReadFromConfig()
        {
            int configInt;
            if (!int.TryParse(ConfigurationManager.AppSettings["CurrentX"], out configInt))
            {
                throw new Exception("Missing CurrentX config");
            }
            CurrentX = configInt;

            if (!int.TryParse(ConfigurationManager.AppSettings["CurrentY"], out configInt))
            {
                throw new Exception("Missing CurrentY config");
            }
            CurrentY = configInt;

            if (!int.TryParse(ConfigurationManager.AppSettings["MaxX"], out configInt))
            {
                throw new Exception("Missing MaxX config");
            }
            MaxX = configInt;

            if (!int.TryParse(ConfigurationManager.AppSettings["MaxY"], out configInt))
            {
                throw new Exception("Missing MaxY config");
            }
            MaxY = configInt;

            DirectionEnum.Direction direction;
            if (!Enum.TryParse(ConfigurationManager.AppSettings["Direction"], true, out direction))
            {
                throw new Exception("Missing Direction config");
            }
            Direction = direction;
        }
    }
}
