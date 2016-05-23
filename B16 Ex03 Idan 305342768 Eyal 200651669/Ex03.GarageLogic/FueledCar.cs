using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class FueledCar : Car
    {
        private const float k_MaxFueledEngine = 38f;
        List<memberTranslator> k_VehicleMembersList = new List<memberTranslator>
        {
            new memberTranslator("m_ModelType", "model type", typeof(string)),
            new memberTranslator("m_LicensePlate", "license plate", typeof(string)),
            new memberTranslator("m_WheelManufacturer", "wheels Manufacturer", typeof(string)),
            new memberTranslator("m_FuelType", "fuel type", typeof(FueledEngine.eFuelType)),
            new memberTranslator("m_CurrentFuelAmount", "current fuel amount", typeof(float)),
            new memberTranslator("m_CarColor", "car color", typeof(eCarColor)),
            new memberTranslator("m_NumOfDoors", "number of doors", typeof(eNumOfDoors)),
            new memberTranslator("m_EnergyPrecentageLeft", "fuel amount left", typeof(float)),
        };

        public FueledCar()
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
            eCarColor i_CarColor,
            eNumOfDoors i_NumOfDoors)
        {
            this.m_ModelType = i_ModelType;
            this.m_LicensePlate = i_LicensePlate;
            foreach (float currentTirePressure in i_TirePressures)
            {
                this.m_Wheels.Add(new Wheel(i_WheelManufacturer, currentTirePressure, k_MaxTirePressure));
            }

            this.m_Engine = new FueledEngine(i_CurrentFuelAmount, k_MaxFueledEngine, FueledEngine.eFuelType.Octan98);
            this.m_EnergyPrecentageLeft = i_CurrentFuelAmount / k_MaxFueledEngine;
            this.m_CarColor = i_CarColor;
            this.m_NumOfDoors = i_NumOfDoors;
        }
    }
}