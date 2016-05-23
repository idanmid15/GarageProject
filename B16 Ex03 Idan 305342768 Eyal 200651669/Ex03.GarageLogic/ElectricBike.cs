﻿using Ex03.GarageLogic;
using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class ElectricBike : Bike
    {
        private const float k_MaxChargeTime = 1.9f;
        List<memberTranslator> k_VehicleMembersList = new List<memberTranslator>
        {
            new memberTranslator("m_ModelType", "model type", typeof(string)),
            new memberTranslator("m_LicensePlate", "license plate", typeof(string)),
            new memberTranslator("m_WheelManufacturer", "wheels Manufacturer", typeof(string)),
            new memberTranslator("m_ChargeTimeLeft", "charge time left", typeof(float)),
            new memberTranslator("m_LicenseType", "license type", typeof(eLicenseType)),
            new memberTranslator("m_EngineVolume", "engine volume", typeof(int)),
        };


        public ElectricBike()
        {
            this.m_NumOfWheels = k_NumOfWheels;           
        }

        public override List<memberTranslator>  GetAllVehicleMembers()
        {
            return k_VehicleMembersList;
        }

        public void ConstructVehicle(
            string i_ModelType,
            string i_LicensePlate,
            string i_WheelManufacturer,
            float[] i_TirePressures,
            float i_ChargeTimeLeft,
            eLicenseType i_LicenseType,
            int i_EngineVolume)
        {
            this.m_ModelType = i_ModelType;
            this.m_LicensePlate = i_LicensePlate;
            this.m_WheelManufacturer = i_WheelManufacturer;
            this.m_Wheels.Add(new Wheel(m_WheelManufacturer, i_TirePressures[0], k_MaxTirePressure));
            this.m_Wheels.Add(new Wheel(m_WheelManufacturer, i_TirePressures[1], k_MaxTirePressure));
            this.m_Engine = new ElectricEngine(i_ChargeTimeLeft, k_MaxChargeTime);
            this.m_EnergyPrecentageLeft = i_ChargeTimeLeft / k_MaxChargeTime;
            this.m_LicenseType = i_LicenseType;
            this.m_EngineVolume = i_EngineVolume;
        }
    }
}