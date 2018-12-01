using Slmm.BusinessLogic.Container;
using Slmm.BusinessLogic.Interfaces;
using Slmm.Model;
using System;

namespace Slmm.BusinessLogic.Services
{
    public class SlmmMoveDirectionFactoryService : ISlmmMoveDirectionFactoryService
    {
        public ISlmmMove GetSlmmMoveDirection(DirectionEnum.Direction direction)
        {
            switch (direction)
            {
                case DirectionEnum.Direction.North:
                    return ObjectsContainer.GetObjectByName<ISlmmMove>("SlmmMoveNorthService");
                case DirectionEnum.Direction.South:
                    return ObjectsContainer.GetObjectByName<ISlmmMove>("SlmmMoveSouthService");
                case DirectionEnum.Direction.East:
                    return ObjectsContainer.GetObjectByName<ISlmmMove>("SlmmMoveEastService");
                case DirectionEnum.Direction.West:
                    return ObjectsContainer.GetObjectByName<ISlmmMove>("SlmmMoveWestService");
                default:
                    throw new Exception(String.Format("Slmm Move not implemented for Direction : {0}", direction));
            }
        }
    }
}
