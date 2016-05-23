using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class FueledBike : Bike
    {
        private const float k_MaxFueledEngine = 7.2f;
        List<memberTranslator> k_VehicleMembersList = new List<memberTranslator>
        {
            new memberTranslator("m_ModelType", "model type", typeof(string)),
            new memberTranslator("m_LicensePlate", "license plate", typeof(string)),
            new memberTranslator("m_WheelManufacturer", "wheels Manufacturer", typeof(string)),
            new memberTranslator("m_FuelType", "fuel type", typeof(FueledEngine.eFuelType)),
            new memberTranslator("m_CurrentFuelAmount", "current fuel amount", typeof(float)),
            new memberTranslator("m_LicenseType", "license type", typeof(eLicenseType)),
            new memberTranslator("m_EngineVolume", "engine volume", typeof(int)),
        };

        public FueledBike()
        {
            this.m_NumOfWheels = k_NumOfWheels;
        }

        public override List<memberTranslator> GetAllVehicleMembers()
        {
            return k_VehicleMembersList;
        }

        public void ConstructVehicle(
            string i_ModelType,
            string i_LicensePlate,
            string i_WheelManufacturer,
            float[] i_TirePressures,
            FueledEngine.eFuelType i_FuelType,
            float i_CurrentFuelAmount,
            eLicenseType i_LicenseType,
            int i_EngineVolume)
        {
            this.m_ModelType = i_ModelType;
            this.m_LicensePlate = i_LicensePlate;
            this.m_WheelManufacturer = i_WheelManufacturer;
            this.m_Wheels.Add(new Wheel(m_WheelManufacturer, i_TirePressures[0], k_MaxTirePressure));
            this.m_Wheels.Add(new Wheel(m_WheelManufacturer, i_TirePressures[1], k_MaxTirePressure));
            this.m_Engine = new FueledEngine(i_CurrentFuelAmount, k_MaxFueledEngine, FueledEngine.eFuelType.Octan95);
            this.m_EnergyPrecentageLeft = i_CurrentFuelAmount / k_MaxFueledEngine;
            this.m_LicenseType = i_LicenseType;
            this.m_EngineVolume = i_EngineVolume;
        }
    }
}