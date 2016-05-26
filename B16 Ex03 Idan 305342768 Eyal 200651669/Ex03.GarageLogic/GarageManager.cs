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

        public Dictionary<string, GarageClient> m_GarageDictonary;
        public Vehicle m_CurrentVehicleConstruction;

        public GarageManager()
        {
            m_GarageDictonary = new Dictionary<string, GarageClient>();
            m_CurrentVehicleConstruction = null;
        }

        public bool ManageClient(string i_LicensePlate)
        {
            //1 - means the car already in the shop, 0 means new car entry
            bool isNewClient = true;
            GarageClient client = null;
            if (m_GarageDictonary.TryGetValue(i_LicensePlate, out client))
            {
                client.m_Status = GarageClient.eVehicleStatus.InRepair;
                isNewClient = false;
            }

            return isNewClient;
        }

        public List<MemberTranslator> GetVehicleMembers(eSupportedVehciles i_SupportedVehicle)
        {
            //the method returns a list of all parametrs of specific constructor as <paramName, paramType>
            //the ui will translate each name to a string for the user input
            List<MemberTranslator> memberList = new List<MemberTranslator>();

            Type typeOfVehicle = Type.GetType("Ex03.GarageLogic." + i_SupportedVehicle.ToString());
            this.m_CurrentVehicleConstruction = typeOfVehicle.GetConstructors()[0].Invoke(null) as Vehicle;
            return this.m_CurrentVehicleConstruction.GetAllVehicleMembers();
        }

        public Vehicle CreateVehicle(eSupportedVehciles i_SupportedVehicle, object[] i_InputParameters)
        {
            Type typeOfVehicle = Type.GetType("Ex03.GarageLogic." + i_SupportedVehicle.ToString());
            MethodInfo constructMethod = typeOfVehicle.GetMethod("Construct");
            try
            {
                this.m_CurrentVehicleConstruction = constructMethod.Invoke(this.m_CurrentVehicleConstruction, i_InputParameters) as Vehicle;
            }
            catch (Exception)
            {
                throw new Exception();
            }
            return this.m_CurrentVehicleConstruction;
        }


        public GarageClient CreateNewClient(string i_ClientName, string i_ClientPhone, Vehicle i_Vehicle)
        {
            GarageClient newClient = new GarageClient(i_ClientName, i_ClientPhone,
                i_Vehicle, GarageClient.eVehicleStatus.InRepair);
            m_GarageDictonary.Add(i_Vehicle.GetLicensePlate(), newClient);
            return newClient;
        }

        public List<string> DisplayVehcilesInGarage(GarageClient.eVehicleStatus i_Status = GarageClient.eVehicleStatus.None)
        {
            string clientLicensePlate = string.Empty;
            List<string> filteredLicensePlates = new List<string>();
            //run over each vehicle, and add to a list the filtered ones.
            foreach (KeyValuePair<string, GarageClient> vehicleEntry in this.m_GarageDictonary)
            {
                clientLicensePlate = vehicleEntry.Value.m_Vehicle.GetLicensePlate();
                if (i_Status == GarageClient.eVehicleStatus.None)
                {
                    filteredLicensePlates.Add(clientLicensePlate);
                }
                else if (vehicleEntry.Value.m_Status == i_Status)
                {
                    filteredLicensePlates.Add(clientLicensePlate);
                }
            }

            return filteredLicensePlates;
        }

        public void UpdateCarStatus(string i_LicensePlate, GarageClient.eVehicleStatus i_NewSatus)
        {
            GarageClient client = null;
            if (m_GarageDictonary.TryGetValue(i_LicensePlate, out client))
            {
                client.m_Status = i_NewSatus;
            }
        }

        public void SetTirePressureToMax(string i_LicensePlate)
        {
            GarageClient client = null;
            Wheel[] allCarWheels = null;
            if (m_GarageDictonary.TryGetValue(i_LicensePlate, out client))
            {
                allCarWheels = client.m_Vehicle.GetWheels();
                foreach (Wheel currentWheel in allCarWheels)
                {
                    currentWheel.SetTirePressure(currentWheel.GetMaxTirePressure());
                }
            }
        }

        public void FuelVehcile(string i_LicensePlate, FueledEngine.eFuelType i_FuelType, float i_FuelAmount)
        {
            GarageClient client = null;
            if (m_GarageDictonary.TryGetValue(i_LicensePlate, out client))
            {
                client.m_Vehicle.GetEngine().RePower(i_FuelAmount);
            }
        }

        public void ChargeVehicle(string i_LicensePlate, float i_MinutesToCharge)
        {
            GarageClient client = null;
            if (m_GarageDictonary.TryGetValue(i_LicensePlate, out client))
            {
                client.m_Vehicle.GetEngine().RePower(i_MinutesToCharge);
            }
        }

        public string GetFullClientInfo(string i_LicensePlate)
        {
            StringBuilder clientProperties = new StringBuilder();
            GarageClient client = null;

            if (m_GarageDictonary.TryGetValue(i_LicensePlate, out client))
            {
                foreach (PropertyInfo objectMember in client.GetType().GetProperties())
                {
                    clientProperties.Append(string.Format("{0} : {1}{2}", objectMember.Name.Substring(2),
                        objectMember.GetValue(client, null).ToString(), Environment.NewLine));
                }
            }

            return clientProperties.ToString();
        }
    }
}