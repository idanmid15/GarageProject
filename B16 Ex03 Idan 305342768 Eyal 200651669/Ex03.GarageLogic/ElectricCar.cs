using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class ElectricCar : Car
    {
        private const float k_MaxChargeTime = 3.3f;
        List<memberTranslator> k_VehicleMembersList = new List<memberTranslator>
        {
            new memberTranslator("m_ModelType", "model type", typeof(string)),
            new memberTranslator("m_LicensePlate", "license plate", typeof(string)),
            new memberTranslator("m_WheelManufacturer", "wheels Manufacturer", typeof(string)),
            new memberTranslator("m_CarColor", "car color", typeof(eCarColor)),
            new memberTranslator("m_NumOfDoors", "number of doors", typeof(eNumOfDoors)),
            new memberTranslator("m_EnergyPrecentageLeft", "fuel amount left", typeof(float)),
        };

        public ElectricCar()
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
            eCarColor i_CarColor,
            eNumOfDoors i_NumOfDoors,
            string i_WheelManufacturer,
            float[] i_TirePressures,
            float i_ChargeTimeLeft)
        {
            this.m_NumOfWheels = k_NumOfWheels;
            this.m_ModelType = i_ModelType;
            this.m_LicensePlate = i_LicensePlate;
            this.m_WheelManufacturer = i_WheelManufacturer;
            foreach (float currentTirePressure in i_TirePressures)
            {
                this.m_Wheels.Add(new Wheel(m_WheelManufacturer, currentTirePressure, k_MaxTirePressure));
            }

            this.m_CarColor = i_CarColor;
            this.m_NumOfDoors = i_NumOfDoors;
            this.m_Engine = new ElectricEngine(i_ChargeTimeLeft, k_MaxChargeTime);
            this.m_EnergyPrecentageLeft = i_ChargeTimeLeft / k_MaxChargeTime;
        }
    }
}