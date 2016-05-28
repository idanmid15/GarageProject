using System;
using System.Collections.Generic;
using System.Text;

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

        protected List<MemberTranslator> m_VehicleMembersList = new List<MemberTranslator>
        {
            new MemberTranslator("m_ModelType", "model type", typeof(string)),
            new MemberTranslator("m_LicensePlate", "license plate", typeof(string)),
            new MemberTranslator("m_WheelManufacturer", "wheels manufacturer", typeof(string)),
            new MemberTranslator("m_Wheels", "pressure of all wheels", typeof(float[]))
        };

        public abstract List<MemberTranslator> GetAllVehicleMembers();

        public override string ToString()
        {
            StringBuilder toReturnBuilder = new StringBuilder();
            toReturnBuilder.AppendFormat("License Plate: {0}{1}", m_LicensePlate, Environment.NewLine);
            toReturnBuilder.AppendFormat("Model Type: {0}{1}", m_ModelType, Environment.NewLine);
            toReturnBuilder.Append(m_Engine.ToString());
            toReturnBuilder.AppendFormat("Wheel manufacturer: {0}{1}", m_WheelManufacturer, Environment.NewLine);
            for (int i = 0; i < m_Wheels.Length; i++)
            {
                toReturnBuilder.AppendFormat("{0} {1}{2}", i + 1, m_Wheels[i], Environment.NewLine);
            }

            return toReturnBuilder.ToString();
        }

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