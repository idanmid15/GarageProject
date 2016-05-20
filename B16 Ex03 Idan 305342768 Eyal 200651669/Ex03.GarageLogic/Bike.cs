using System;

namespace Ex03.GarageLogic
{
    public class Bike : Vehicle
    {
        public enum eLicenseType
        {
            A,
            A1,
            AB,
            B1
        }

        protected const float k_MaxTirePressure = 31;
        protected eLicenseType m_LicenseType;
        protected int m_EngineVolume;
    }
}