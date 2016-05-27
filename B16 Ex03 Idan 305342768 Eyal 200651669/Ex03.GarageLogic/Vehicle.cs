using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        public string m_ModelType;

        public string m_LicensePlate;

        public float m_EnergyPrecentageLeft;

        public Engine m_Engine;

        public Wheel[] m_Wheels;

        public int m_NumOfWheels;

        public string m_WheelManufacturer;

        public abstract List<MemberTranslator> GetAllVehicleMembers();

        //public abstract void Construct();

        public string GetModelType()
        {
            return m_ModelType;
        }

        public string GetLicensePlate()
        {
            return m_LicensePlate;
        }

        public float GetEnergyPrecentageLeft()
        {
            return m_EnergyPrecentageLeft;
        }

        public Wheel[] GetWheels()
        {
            return m_Wheels;
        }

        public Engine GetEngine()
        {
            return m_Engine;
        }

        public string GetWheelManufacturer()
        {
            return m_WheelManufacturer;
        }
    }
}