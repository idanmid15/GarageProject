using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class Car : Vehicle
    {
        public enum eCarColor
        {
            Yellow,
            White,
            Red,
            Black
        }

        public enum eNumOfDoors
        {
            Two,
            Three,
            Four,
            Five,
        }

        protected const float k_MaxTirePressure = 31;
        protected const int k_NumOfWheels = 4;
        protected eCarColor m_CarColor;
        protected eNumOfDoors m_NumOfDoors;

       /* public override List<MemberTranslator> GetAllVehicleMembers()
        {
            return null;
        }*/
    }
}