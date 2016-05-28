using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class Car : Vehicle
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

        protected List<MemberTranslator> m_CarMembersList = new List<MemberTranslator>
        {
            new MemberTranslator("m_CarColor", "car color", typeof(eCarColor)),
            new MemberTranslator("m_NumOfDoors", "number of doors", typeof(eNumOfDoors)),
        };

        public override string ToString()
        {
            StringBuilder toReturnBuilder = new StringBuilder();
            toReturnBuilder.Append(base.ToString());
            toReturnBuilder.AppendFormat("Car Color: {0}{1}", m_CarColor, Environment.NewLine);
            toReturnBuilder.AppendFormat("Number of doors: {0}{1}", m_NumOfDoors, Environment.NewLine);
            return toReturnBuilder.ToString();
        }
    }  
}