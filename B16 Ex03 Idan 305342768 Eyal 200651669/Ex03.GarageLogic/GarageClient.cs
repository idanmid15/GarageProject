using System;
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

        public string m_ClientName;
        public string m_ClientPhone;
        public Vehicle m_Vehicle;
        public Type m_TypeOfVehicle;
        public eVehicleStatus m_Status;

        public GarageClient(
            string i_ClientName,
            string i_ClientPhone,
            Vehicle i_Vehicle,
            eVehicleStatus i_Status,
            GarageManager.eSupportedVehciles i_SupportedVehicle)
        {
            m_ClientName = i_ClientName;
            m_ClientPhone = i_ClientPhone;
            m_Vehicle = i_Vehicle;
            m_Status = i_Status;
            m_TypeOfVehicle = Type.GetType("Ex03.GarageLogic." + i_SupportedVehicle.ToString());
        }

        public override string ToString()
        {
            StringBuilder clientString = new StringBuilder();
            clientString.AppendFormat("Client Name: {0}{1}", m_ClientName, Environment.NewLine);
            clientString.AppendFormat("Phone Number: {0}{1}", m_ClientPhone, Environment.NewLine);
            clientString.AppendFormat("Vehicle Status: {0}{1}", m_Status, Environment.NewLine);
            MethodInfo methodToString = m_TypeOfVehicle.GetMethod("ToString");
            clientString.Append((methodToString.Invoke(m_Vehicle, null)));
            return clientString.ToString();
        }
    }
}
