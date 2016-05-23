using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
    {
        protected const float k_MaxTirePressure = 28;
        protected const int k_NumOfWheels = 16;
        protected const FueledEngine.eFuelType k_FuelType = FueledEngine.eFuelType.Soler;
        private const float k_MaxFuelCapacity = 135f;
        protected bool m_IsCarryingToxic;
        List<memberTranslator> k_VehicleMembersList = new List<memberTranslator>
        {
            new memberTranslator("m_ModelType", "model type", typeof(string)),
            new memberTranslator("m_LicensePlate", "license plate", typeof(string)),
            new memberTranslator("m_WheelManufacturer", "wheels Manufacturer", typeof(string)),
            new memberTranslator("m_FuelType", "fuel type", typeof(FueledEngine.eFuelType)),
            new memberTranslator("m_CurrentFuelAmount", "current fuel amount", typeof(float)),
            new memberTranslator("m_IsCarryingToxic", "does the truck carring toxic metarials", typeof(bool)),
        };

        public Truck()
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
         bool i_IsCarryingToxic)
        {
            this.m_NumOfWheels = k_NumOfWheels;
            this.m_ModelType = i_ModelType;
            this.m_LicensePlate = i_LicensePlate;

            foreach (float currentTirePressure in i_TirePressures)
            {
                this.m_Wheels.Add(new Wheel(i_WheelManufacturer, currentTirePressure, k_MaxTirePressure));
            }
            this.m_Engine = new FueledEngine(i_CurrentFuelAmount, k_MaxFuelCapacity, k_FuelType);
            this.m_EnergyPrecentageLeft = i_CurrentFuelAmount / k_MaxFuelCapacity;
            this.m_IsCarryingToxic = i_IsCarryingToxic;
        }
    }
}