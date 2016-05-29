using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Ex03.GarageLogic
{
    public class GarageManager
    {
        public enum eSupportedVehciles
        {
            ElectricBike = 1,
            ElectricCar = 2,
            FueledBike = 3,
            FueledCar = 4,
            Truck = 5
        }

        public const string k_NameSpace = "Ex03.GarageLogic.";

        public Dictionary<string, GarageClient> m_GarageDictonary;
        public Vehicle m_CurrentVehicleConstruction;

        public GarageManager()
        {
            m_GarageDictonary = new Dictionary<string, GarageClient>();
            m_CurrentVehicleConstruction = null;
        }

        public Vehicle CallCreateVehicle(GarageManager.eSupportedVehciles i_SupportedVehicle, object[] i_InputParameters)
        {
            return VehicleFactory.CreateVehicle(i_SupportedVehicle, i_InputParameters, this.m_CurrentVehicleConstruction);
        }

        public bool ClientExists(string i_LicensePlate)
        {
            bool doesClientExist = false;
            GarageClient client = null;
            if (m_GarageDictonary.TryGetValue(i_LicensePlate, out client))
            {
                doesClientExist = true;
            }

            return doesClientExist;
        }

        public List<MemberTranslator> GetVehicleMembers(eSupportedVehciles i_SupportedVehicle)
        {
            //the method returns a list of all parametrs of specific constructor as <paramName, paramType>
            //the ui will translate each name to a string for the user input
            List<MemberTranslator> memberList = new List<MemberTranslator>();

            Type typeOfVehicle = Type.GetType(k_NameSpace + i_SupportedVehicle.ToString());
            this.m_CurrentVehicleConstruction = typeOfVehicle.GetConstructors()[0].Invoke(null) as Vehicle;
            return this.m_CurrentVehicleConstruction.GetAllVehicleMembers();
        }

        

        public string DisplayVehiclesInGarage(GarageClient.eVehicleStatus i_Status)
        {
            string clientLicensePlate = string.Empty;
            StringBuilder clientPropertiesString = new StringBuilder();
            int index = 1;
            //run over each vehicle, and add to a string builder only the filtered ones.
            foreach (KeyValuePair<string, GarageClient> vehicleEntry in this.m_GarageDictonary)
            {
                foreach (KeyValuePair<string, GarageClient.SingleVehicleInfo>  innerDictionary in vehicleEntry.Value.m_Vehicles)
                {
                    clientLicensePlate = innerDictionary.Value.m_Vehicle.GetLicensePlate();
                    if (i_Status == GarageClient.eVehicleStatus.None)
                    {
                        clientPropertiesString.Append(string.Format("{0}) License plate No. {1}{2}", index, clientLicensePlate, Environment.NewLine));
                    }
                    else if (innerDictionary.Value.m_Status == i_Status)
                    {
                        clientPropertiesString.Append(string.Format("{0}) License plate No. {1}{2}", index, clientLicensePlate, Environment.NewLine));
                    }

                    index++;
                }
            }

            if (clientPropertiesString.Length == 0)
            {
                clientPropertiesString.Append("sorry, no matching vehicles were found.");
            }

            return clientPropertiesString.ToString();
        }

        public void UpdateVehicleStatus(string i_MainLicensePlate, string i_CurrentLicensePlate, GarageClient.eVehicleStatus i_NewSatus)
        {
            GarageClient o_Client = null;
            GarageClient.SingleVehicleInfo o_InnerDict = null;
            if (m_GarageDictonary.TryGetValue(i_MainLicensePlate, out o_Client))
            {
                o_Client.m_Vehicles.TryGetValue(i_CurrentLicensePlate, out o_InnerDict);
                o_InnerDict.m_Status = i_NewSatus;
            }
            else
            {
                throw new Exception("License plate number not found in the garage");
            }
        }

        public void SetTirePressureToMax(string i_MainLicensePlate, string i_CurrentLicensePlate)
        {
            GarageClient o_Client = null;
            Wheel[] allCarWheels = null;
            GarageClient.SingleVehicleInfo o_InnerDict = null;
            if (m_GarageDictonary.TryGetValue(i_MainLicensePlate, out o_Client))
            {
                o_Client.m_Vehicles.TryGetValue(i_CurrentLicensePlate, out o_InnerDict);
                allCarWheels = o_InnerDict.m_Vehicle.GetWheels();
                foreach (Wheel currentWheel in allCarWheels)
                {
                    currentWheel.SetTirePressure(currentWheel.GetMaxTirePressure());
                }
            }
        }

        public void FuelVehicle(string i_MainLicensePlate, string i_CurrentLicensePlate, FueledEngine.eFuelType i_FuelType, float i_FuelAmount)
        {
            GarageClient o_Client = null;
            GarageClient.SingleVehicleInfo o_InnerDict = null;
            if (m_GarageDictonary.TryGetValue(i_MainLicensePlate, out o_Client))
            {
                if (o_Client.m_Vehicles.TryGetValue(i_CurrentLicensePlate, out o_InnerDict))
                {
                    o_InnerDict.m_Vehicle.GetEngine().RePower(i_FuelAmount);
                }
            }
        }

        public void ChargeVehicle(string i_MainLicensePlate, string i_CurrentLicensePlate, float i_MinutesToCharge)
        {
            GarageClient o_Client = null;
            GarageClient.SingleVehicleInfo o_InnerDict = null;
            if (m_GarageDictonary.TryGetValue(i_MainLicensePlate, out o_Client))
            {
                if (o_Client.m_Vehicles.TryGetValue(i_CurrentLicensePlate, out o_InnerDict))
                {
                    o_InnerDict.m_Vehicle.GetEngine().RePower(i_MinutesToCharge);
                }
            }
        }

        public string GetFullClientInfo(string i_LicensePlate)
        {
            GarageClient client = null;
            string toReturn = string.Empty;
            if (m_GarageDictonary.TryGetValue(i_LicensePlate, out client))
            {
                toReturn = client.ToString();
            }

            return toReturn;
        }

        public void AddClient(string i_LicensePlate, GarageClient i_Client)
        {
            this.m_GarageDictonary.Add(i_LicensePlate, i_Client);
        }
    }
}