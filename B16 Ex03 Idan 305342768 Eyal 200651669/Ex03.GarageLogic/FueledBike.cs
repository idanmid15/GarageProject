using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class FueledBike : Bike
    {
        private const float k_MaxFueledEngine = 7.2f;
        FueledEngine.eFuelType k_FuelType = FueledEngine.eFuelType.Octan95;

        public FueledBike()
        {
            this.m_NumOfWheels = k_NumOfWheels;
            this.m_Wheels = new Wheel[k_NumOfWheels];
            this.m_VehicleMembersList.AddRange(m_BikeMembersList);
            this.m_VehicleMembersList.Add(new MemberTranslator("m_CurrentFuelAmount", "current fuel amount", typeof(float)));
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
            eLicenseType i_LicenseType,
            int i_EngineVolume,
            float i_CurrentFuelAmount)
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

        public override string ToString()
        {
            StringBuilder toReturnBuilder = new StringBuilder();
            toReturnBuilder.AppendFormat("Vehicle Type: Fueled Bike{0}", Environment.NewLine);
            toReturnBuilder.Append(base.ToString());
            return toReturnBuilder.ToString();
        }
    }
}