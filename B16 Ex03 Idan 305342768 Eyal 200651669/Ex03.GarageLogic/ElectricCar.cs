using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class ElectricCar : Car
    {
        private const float k_MaxChargeTime = 3.3f;
        List<MemberTranslator> k_VehicleMembersList = new List<MemberTranslator>
        {
            new MemberTranslator("m_ModelType", "model type", typeof(string)),
            new MemberTranslator("m_LicensePlate", "license plate", typeof(string)),
            new MemberTranslator("m_WheelManufacturer", "wheels Manufacturer", typeof(string)),
            new MemberTranslator("m_CarColor", "car color", typeof(eCarColor)),
            new MemberTranslator("m_NumOfDoors", "number of doors", typeof(eNumOfDoors)),
            new MemberTranslator("m_EnergyPrecentageLeft", "fuel amount left", typeof(float)),
            new MemberTranslator("m_Wheels", "pressure of all wheels", typeof(float[]))
        };

        public ElectricCar()
        {
            this.m_NumOfWheels = k_NumOfWheels;
            this.m_Wheels = new Wheel[k_NumOfWheels];
        }

        public override List<MemberTranslator> GetAllVehicleMembers()
        {
            return k_VehicleMembersList;
        }

        public Vehicle Construct(
            string i_ModelType,
            string i_LicensePlate,
            string i_WheelManufacturer,
            eCarColor i_CarColor,
            eNumOfDoors i_NumOfDoors,
            float i_ChargeTimeLeft,
            float[] i_TirePressures)
        {
            this.m_NumOfWheels = k_NumOfWheels;
            this.m_ModelType = i_ModelType;
            this.m_LicensePlate = i_LicensePlate;
            this.m_WheelManufacturer = i_WheelManufacturer;
            for (int i = 0; i < k_NumOfWheels; i++)
            {
                this.m_Wheels[i] = new Wheel(m_WheelManufacturer, i_TirePressures[i], k_MaxTirePressure);
            }

            this.m_CarColor = i_CarColor;
            this.m_NumOfDoors = i_NumOfDoors;
            this.m_Engine = new ElectricEngine(i_ChargeTimeLeft, k_MaxChargeTime);
            this.m_EnergyPrecentageLeft = i_ChargeTimeLeft / k_MaxChargeTime;


            return this;
        }

        public float getMaxTimeToCharge()
        {
            return k_MaxChargeTime;
        }
    }
}