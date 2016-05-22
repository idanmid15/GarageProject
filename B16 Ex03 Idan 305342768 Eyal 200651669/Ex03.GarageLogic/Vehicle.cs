using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class Vehicle
    {
        protected string m_ModelType;

        protected string m_LicensePlate;

        protected float m_EnergyPrecentageLeft;

        protected Engine m_Engine;

        protected List<Wheel> m_Wheels;

        protected int m_NumOfWheels;

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

        public List<Wheel> GetWheels()
        {
            return m_Wheels;
        }

        public Engine GetEngine()
        {
            return m_Engine;
        }
    }
}