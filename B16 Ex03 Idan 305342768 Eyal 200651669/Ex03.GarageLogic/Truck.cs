﻿using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
    {
        protected const float k_MaxTirePressure = 28;
        protected const int k_NumOfWheels = 16;
        protected const FueledEngine.eFuelType k_FuelType = FueledEngine.eFuelType.Soler;
        private const float k_MaxFuelCapacity = 135f;
        protected bool m_IsCarryingToxic;
        List<MemberTranslator> k_VehicleMembersList = new List<MemberTranslator>
        {
            new MemberTranslator("m_ModelType", "model type", typeof(string)),
            new MemberTranslator("m_LicensePlate", "license plate", typeof(string)),
            new MemberTranslator("m_WheelManufacturer", "wheels Manufacturer", typeof(string)),
            new MemberTranslator("m_CurrentFuelAmount", "current fuel amount", typeof(float)),
            new MemberTranslator("m_IsCarryingToxic", "does the truck carring toxic metarials", typeof(bool)),
            new MemberTranslator("m_Wheels", "pressure of all wheels", typeof(float[]))
        };

        public Truck()
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
         float i_CurrentFuelAmount,
         bool i_IsCarryingToxic,
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
            this.m_Engine = new FueledEngine(i_CurrentFuelAmount, k_MaxFuelCapacity, k_FuelType);
            this.m_EnergyPrecentageLeft = i_CurrentFuelAmount / k_MaxFuelCapacity;
            this.m_IsCarryingToxic = i_IsCarryingToxic;

            return this;
        }
    }
}