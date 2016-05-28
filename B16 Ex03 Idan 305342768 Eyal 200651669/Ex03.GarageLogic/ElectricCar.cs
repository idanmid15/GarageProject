using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class ElectricCar : Car
    {
        private const float k_MaxChargeTime = 3.3f;

        public ElectricCar()
        {
            this.m_NumOfWheels = k_NumOfWheels;
            this.m_Wheels = new Wheel[k_NumOfWheels];
            this.m_VehicleMembersList.AddRange(m_CarMembersList);
            this.m_VehicleMembersList.Add(new MemberTranslator("m_ChargeTimeLeft", "charge time left", typeof(float)));
        }

        public override List<MemberTranslator> GetAllVehicleMembers()
        {
            return m_VehicleMembersList;
        }

        public Vehicle Construct(
            string i_ModelType,
            string i_LicensePlate,
            string i_WheelManufacturer,
            float[] i_TirePressures,
            eCarColor i_CarColor,
            eNumOfDoors i_NumOfDoors,
            float i_ChargeTimeLeft)
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
        
        public override string ToString()
        {
            StringBuilder toReturnBuilder = new StringBuilder();
            toReturnBuilder.AppendFormat("Vehicle Type: Electric Car{0}", Environment.NewLine);
            toReturnBuilder.Append(base.ToString());
            return toReturnBuilder.ToString();
        }
    }
}