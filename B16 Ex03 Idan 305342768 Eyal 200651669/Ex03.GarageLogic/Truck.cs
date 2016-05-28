using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
    {
        protected const float k_MaxTirePressure = 28;
        protected const int k_NumOfWheels = 16;
        protected const FueledEngine.eFuelType k_FuelType = FueledEngine.eFuelType.Soler;
        private const float k_MaxFueledEngine = 135f;
        protected bool m_IsCarryingToxic;

        public Truck()
        {
            this.m_NumOfWheels = k_NumOfWheels;
            this.m_Wheels = new Wheel[k_NumOfWheels];
            m_VehicleMembersList.Add(new MemberTranslator("m_CurrentFuelAmount", "current fuel amount", typeof(float)));
            m_VehicleMembersList.Add(new MemberTranslator("m_IsCarryingToxic", "does the truck carring toxic metarials", typeof(bool)));
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
         float i_CurrentFuelAmount,
         bool i_IsCarryingToxic)
        {
            this.m_NumOfWheels = k_NumOfWheels;
            this.m_ModelType = i_ModelType;
            this.m_LicensePlate = i_LicensePlate;
            this.m_WheelManufacturer = i_WheelManufacturer;

            for (int i = 0; i < k_NumOfWheels; i++)
            {
                this.m_Wheels[i] = new Wheel(m_WheelManufacturer, i_TirePressures[i], k_MaxTirePressure);
            }
            this.m_Engine = new FueledEngine(i_CurrentFuelAmount, k_MaxFueledEngine, k_FuelType);
            this.m_EnergyPrecentageLeft = i_CurrentFuelAmount / k_MaxFueledEngine;
            this.m_IsCarryingToxic = i_IsCarryingToxic;

            return this;
        }

        public override string ToString()
        {
            StringBuilder toReturnBuilder = new StringBuilder();
            toReturnBuilder.AppendFormat("Vehicle Type: Truck{0}Is carrying toxic: {1}", Environment.NewLine, m_IsCarryingToxic);
            toReturnBuilder.Append(base.ToString());
            return toReturnBuilder.ToString();
        }
    }
}