﻿using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Ex03.GarageLogic
{
    public class GarageManager
    {
        public enum eSupportedVehciles
        {
            ElectricCar,
            FueledCar,
            ElectricBike,
            FueledBike,
            Truck,
            Other
        }

        public Dictionary<string, GarageClient> m_GarageDictonary;

        public GarageManager()
        {
            m_GarageDictonary = new Dictionary<string, GarageClient>();
        }

        public int ManageClient(string i_LicensePlate)
        {
            //1 - means the car already in the shop, 0 means new car entry
            int returnValue = 0;
            GarageClient client = null;
            if (m_GarageDictonary.TryGetValue(i_LicensePlate, out client))
            {
                client.m_Status = GarageClient.eVehicleStatus.InRepair;
                returnValue = 1;
            }

            return returnValue;
        }

        public List<string> GetVehicleMembers(eSupportedVehciles i_SupportedVehicle)
        {
            List<string> vehicleList = new List<string>();
            Type typeOfVehicle = Type.GetType(i_SupportedVehicle.ToString());
            foreach (PropertyInfo objectMember in typeOfVehicle.GetProperties())
            {
                // Receives only the name of the members without the "m_"
                vehicleList.Add(objectMember.Name.Substring(2));
            }
            return vehicleList;
        }

        public GarageClient CreateNewClient(string i_ClientName, string i_ClientPhone, Vehicle i_Vehicle, GarageClient.eVehicleStatus i_Status)
        {
            return new GarageClient(i_ClientName, i_ClientPhone, i_Vehicle, i_Status);
        }

        public List<string> DisplayVehcilesInGarage(GarageClient.eVehicleStatus i_Status = GarageClient.eVehicleStatus.None)
        {
            //////status execption here/////

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
            ////exceptions here?

            GarageClient client = null;
            if (m_GarageDictonary.TryGetValue(i_LicensePlate, out client))
            {
                client.m_Status = i_NewSatus;
            }
        }

        public void SetTirePressureToMax(string i_LicensePlate)
        {
            GarageClient client = null;
            List<Wheel> allCarWheels = null;
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
                ////need execption for fuel type here! (other exceptions are taking care of
                client.m_Vehicle.GetEngine().RePower(i_FuelAmount);
            }
        }

        public void ChargeVehicle(string i_LicensePlate, float i_MinutesToCharge)
        {
            GarageClient client = null;
            if (m_GarageDictonary.TryGetValue(i_LicensePlate, out client))
            {
                ////need execption for fuel type here! (other exceptions are taking care of
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