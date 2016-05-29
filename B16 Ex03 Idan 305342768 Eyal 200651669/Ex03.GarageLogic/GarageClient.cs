using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Ex03.GarageLogic
{
    public class GarageClient
    {
        public enum eVehicleStatus
        {
            InRepair = 1,
            NotInRepair = 2,
            None = 3
        }

        public class SingleVehicleInfo
        {
            public Vehicle m_Vehicle;
            public Type m_TypeOfVehicle;
            public eVehicleStatus m_Status;
            public SingleVehicleInfo(Vehicle i_Vehicle, Type i_TypeOfVehicle, eVehicleStatus i_Status)
            {
                m_Vehicle = i_Vehicle;
                m_TypeOfVehicle = i_TypeOfVehicle;
                m_Status = i_Status;
            }

            public override String ToString()
            {
                StringBuilder clientString = new StringBuilder();
                clientString.AppendFormat("Vehicle Status: {0}{1}", m_Status, Environment.NewLine);
                MethodInfo methodToString = m_TypeOfVehicle.GetMethod("ToString");
                clientString.Append((methodToString.Invoke(m_Vehicle, null)));
                return clientString.ToString();
            }
        }

        public string m_ClientName;
        public string m_ClientPhone;
        public Dictionary <string ,SingleVehicleInfo> m_Vehicles;

        public GarageClient(
            string i_ClientName,
            string i_ClientPhone,
            Vehicle i_Vehicle,
            eVehicleStatus i_Status,
            GarageManager.eSupportedVehciles i_SupportedVehicle)
        {
            m_ClientName = i_ClientName;
            m_ClientPhone = i_ClientPhone;
            m_Vehicles = new Dictionary<string, SingleVehicleInfo>();
            AddVehicleToClient(i_Vehicle, i_Status, i_SupportedVehicle, i_Vehicle.GetLicensePlate());
        }

        public void AddVehicleToClient(
            Vehicle i_Vehicle,
            eVehicleStatus i_Status,
            GarageManager.eSupportedVehciles i_SupportedVehicle,
            string i_LicensePlate
            )
            {
                m_Vehicles.Add(i_LicensePlate ,new SingleVehicleInfo(i_Vehicle, Type.GetType(GarageManager.k_NameSpace + i_SupportedVehicle.ToString()), i_Status));
            }

        public override string ToString()
        {
            StringBuilder clientString = new StringBuilder();
            clientString.AppendFormat("Client Name: {0}{1}", m_ClientName, Environment.NewLine);
            clientString.AppendFormat("Phone Number: {0}{1}", m_ClientPhone, Environment.NewLine);
            foreach (KeyValuePair<string, SingleVehicleInfo> vehicleEntry in m_Vehicles)
            {
                clientString.Append(vehicleEntry.Value.ToString());
                clientString.AppendFormat("***********************************{0}", Environment.NewLine);                
            }
            return clientString.ToString();
        }
    }
}
