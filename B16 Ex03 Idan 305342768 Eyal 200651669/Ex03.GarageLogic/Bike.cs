using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class Bike : Vehicle
    {
        public enum eLicenseType
        {
            A,
            A1,
            AB,
            B1
        }

        protected const float k_MaxTirePressure = 31;
        protected const int k_NumOfWheels = 2;
        protected eLicenseType m_LicenseType;
        protected int m_EngineVolume;
        protected List<MemberTranslator> m_BikeMembersList = new List<MemberTranslator>
        {
            new MemberTranslator("m_LicenseType", "license type", typeof(eLicenseType)),
            new MemberTranslator("m_EngineVolume", "engine volume", typeof(int))
        };

        public override string ToString()
        {
            StringBuilder toReturnBuilder = new StringBuilder();
            toReturnBuilder.Append(base.ToString());
            toReturnBuilder.AppendFormat("License Type: {0}{1}", m_LicenseType.ToString(), Environment.NewLine);
            toReturnBuilder.AppendFormat("Engine Volume: {0}{1}", m_EngineVolume, Environment.NewLine);
            return toReturnBuilder.ToString();
        }
    }
}