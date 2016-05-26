using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class Car : Vehicle
    {
        public enum eCarColor
        {
            Yellow = 1,
            White = 2,
            Red = 3,
            Black = 4
        }

        public enum eNumOfDoors
        {
            Two = 2,
            Three = 3,
            Four = 4,
            Five = 5,
        }

        protected const float k_MaxTirePressure = 31;
        protected const int k_NumOfWheels = 4;
        protected eCarColor m_CarColor;
        protected eNumOfDoors m_NumOfDoors;

        public override List<MemberTranslator> GetAllVehicleMembers()
        {
            return null;
        }
    }
}