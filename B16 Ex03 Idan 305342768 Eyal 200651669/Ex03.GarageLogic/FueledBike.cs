using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class FueledBike : Bike
    {
        private const float k_MaxFueledEngine = 7.2f;
        FueledEngine.eFuelType k_FuelType = FueledEngine.eFuelType.Octan95;
        List<MemberTranslator> k_VehicleMembersList = new List<MemberTranslator>
        {
            new MemberTranslator("m_ModelType", "model type", typeof(string)),
            new MemberTranslator("m_LicensePlate", "license plate", typeof(string)),
            new MemberTranslator("m_WheelManufacturer", "wheels Manufacturer", typeof(string)),
            new MemberTranslator("m_CurrentFuelAmount", "current fuel amount", typeof(float)),
            new MemberTranslator("m_LicenseType", "license type", typeof(eLicenseType)),
            new MemberTranslator("m_EngineVolume", "engine volume", typeof(int)),
            new MemberTranslator("m_Wheels", "pressure of all wheels", typeof(float[]))
        };

        public FueledBike()
        {
            this.m_NumOfWheels = k_NumOfWheels;
            this.m_Wheels = new Wheel[k_NumOfWheels];
        }

        public override List<MemberTranslator> GetAllVehicleMembers()
        {
            return k_VehicleMembersList;
        }

        public Vehicle Constructor(
            string i_ModelType,
            string i_LicensePlate,
            string i_WheelManufacturer,
            float i_CurrentFuelAmount,
            eLicenseType i_LicenseType,
            int i_EngineVolume,
            float[] i_TirePressures)
        {
            this.m_ModelType = i_ModelType;
            this.m_LicensePlate = i_LicensePlate;
            this.m_WheelManufacturer = i_WheelManufacturer;
            for (int i = 0; i < k_NumOfWheels; i++)
            {
                this.m_Wheels[i] = new Wheel(m_WheelManufacturer, i_TirePressures[i], k_MaxTirePressure);
            }
            this.m_Engine = new FueledEngine(i_CurrentFuelAmount, k_MaxFueledEngine, k_FuelType);
            this.m_EnergyPrecentageLeft = i_CurrentFuelAmount / k_MaxFueledEngine;
            this.m_LicenseType = i_LicenseType;
            this.m_EngineVolume = i_EngineVolume;

            return this;
        }
    }
}