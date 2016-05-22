﻿using System;
using Ex03.GarageLogic;
using System.Collections.Generic;

namespace Ex03.ConsoleUI
{
    public class UI
    {
        public enum eUserOptions
        {
            InsertNewVehicle = 1,
            DisplayFilteredLicenses = 2,
            ChangeVehicleStatus = 3,
            InflateTires = 4,
            RefuelVehicle = 5,
            ReChargeVehicle = 6,
            DisplayCarInfo = 7
        }

        GarageManager m_GarageManager;
        GarageClient m_CurrentClient;

        public UI()
        {
            m_GarageManager = new GarageManager();
            m_CurrentClient = null;
        }

        public void RunUI()
        {
            string userAction = string.Empty;
            OutputToConsole(string.Format("Hello and Welcome to the garage.{0}what is your license plate number:",
                    Environment.NewLine));
            string licensePlate = InputFromConsole();

            if (this.m_GarageManager.ManageClient(licensePlate) == true)
            {
                OutputToConsole("your car is'nt in our garage.");
            }
            else
            {
                OutputToConsole("what action would you like to do:");
                userAction = InputFromConsole();
                ChooseUserActions(userAction, licensePlate);
            }

        }

        public GarageClient EnterNewClient()
        {
            GarageClient client = null;
            string clientVehicleOptionString = string.Empty;
            GarageManager.eSupportedVehciles clientVehicle = 0;
            string carDetailsInput = string.Empty;
            bool isValidVehicleOption = false;

            OutputToConsole(
@"please enter a number that matches your vehicle type from the given options
  in order to enter it to the garage:
1. Electric Bike
2. Electric Car
3. Fueled Bike
4. Fueled Car
5. Truck");
            clientVehicleOptionString = InputFromConsole();
            while (!isValidVehicleOption)
            {
                try
                {
                    clientVehicle = UserInputExceptions.ParseVehicleTypeInput(clientVehicleOptionString);
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
            }

            Vehicle newVehicle = enterNewVehicleMembers(clientVehicle);
            string[] clientDetails = enterNewClientDetails();
            client = new GarageClient(clientDetails[0], clientDetails[1], newVehicle, GarageClient.eVehicleStatus.InRepair);
            return client;

        }

        private Vehicle enterNewVehicleMembers(GarageManager.eSupportedVehciles i_VehicleType)
        {
            List<object> vehicleMembersList = null;
            object[] vehicleMembersArray = null;
            bool isMemberValid = false;
            float[] tiresArray = null;
            string memberInput = string.Empty;
            float o_Result = 0;
            Dictionary<string, Type> allVehicleMembers = this.m_GarageManager.GetVehicleMembers(i_VehicleType);

            //run over all the vehicle members and ask the user to fill them
            //it will ask to fill them until they're valid arguments
            foreach (KeyValuePair<string, Type> vehicleMember in allVehicleMembers)
            {
                OutputToConsole(string.Format("enter {0}:", vehicleMember.Key));
                while (!isMemberValid) {
                    try
                    {
                        //in case we've reached the part where we need to insert all tires pressures
                        if (vehicleMember.Value.Equals(typeof(float[])))
                        {
                            ///****TODO: how to get the number of wheels per vehicle type********///
                            tiresArray = enterNewTiresArray();
                        } else
                        {
                            memberInput = InputFromConsole();
                        }

                    } catch (Exception e) {
                        ///********TODO:need to solve how to enter the correct type of exception**********
                    }
                }

                vehicleMembersList.Add(memberInput);
            }

            //create a new vehicle with all relevant params for the specific car type given
            vehicleMembersArray = vehicleMembersList.ToArray();
            Vehicle newVehicle = this.m_GarageManager.CreateVehicle(i_VehicleType, vehicleMembersArray);
            return newVehicle;
        }

        private float[] enterNewTiresArray()
        {
            float[] tiresArray = new float[??????];
            string memberInput = string.Empty;
            float o_Tire;

            for (int i = 0; i < tiresArray.Length; i++)
            {
                OutputToConsole(string.Format("enter pressure of tire No. {0}:", i));
                memberInput = InputFromConsole();
                if (Single.TryParse(memberInput, out o_Tire))
                {
                    tiresArray[i] = o_Tire;
                }
            }

            return tiresArray;
        }

        private string[] enterNewClientDetails()
        {
            string[] clientDetails = new string[2];
            OutputToConsole("enter your name:");
            clientDetails[0] = InputFromConsole();
            OutputToConsole("enter your phone number:");
            clientDetails[1] = InputFromConsole();

            return clientDetails;
        }


        public void DisplayFilteredGarageVehicles()
        {
            OutputToConsole(string.Format("would you like to filter the type of cars to display?{0}Type 1- for in repair staus{0}Type 2 - for not in repair", System.Environment.NewLine));
            bool isValidFilter = false;
            GarageClient.eVehicleStatus vehicleDisplayFilter;
            while (!isValidFilter)
            {
                try
                {
                    vehicleDisplayFilter = UserInputExceptions.ParsevehicleDisplayFilter(InputFromConsole());
                    this.m_GarageManager.DisplayVehcilesInGarage(vehicleDisplayFilter);
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
            }

        }

        public void updateVehicleStatus(string i_LicensePlate)
        {
            bool isValidFilter = false;
            GarageClient.eVehicleStatus newStatus;
            while (!isValidFilter)
            {
                try
                {
                    OutputToConsole(string.Format("what is the new status of the vehicle?{0}Type 1- for in repair staus{0}Type 2 - for not in repair", System.Environment.NewLine));
                    newStatus = UserInputExceptions.ParsevehicleDisplayFilter(InputFromConsole());
                    this.m_GarageManager.DisplayVehcilesInGarage(newStatus);
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
                this.m_GarageManager.UpdateCarStatus(i_LicensePlate, newStatus);
            }
        }

        public void ChooseUserActions(string i_UserOption, string i_LicensePlate)
        {
            eUserOptions userOption = eUserOptions.InsertNewVehicle;
            bool isValidAction = false;
            OutputToConsole(
@"Choose the action you would like to make (by entering it's number):
1. Insert a new vehicle
2. Display lisence plates in garage (filtered)
3. Change vehicle status (by license plate)
4. set tires pressure (by license plate)
5. ReFuel vehicle (by license plate)
6. ReCharge vehicle (by license plate)
7. Display vehicle info (by license plate)");

            while (!isValidAction)
            {
                try
                {
                    userOption = UserInputExceptions.ParseUserOptions(i_UserOption);
                    isValidAction = true;
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
            }

            switch (userOption)
            {
                case UI.eUserOptions.InsertNewVehicle:
                    EnterNewClient();
                    break;
                case UI.eUserOptions.DisplayFilteredLicenses:
                    DisplayFilteredGarageVehicles();
                    break;
                case UI.eUserOptions.ChangeVehicleStatus:
                    updateVehicleStatus(i_LicensePlate);
                    break;
                case UI.eUserOptions.InflateTires:
                    this.m_GarageManager.SetTirePressureToMax(i_LicensePlate);
                    break;
                case UI.eUserOptions.RefuelVehicle:
                    if (this.m_CurrentClient.m_Vehicle.GetEngine().GetEngineType().Equals(Engine.eEngineType.Fuel)){
                        ///**********TODO:how to get fuel type************
                    this.m_GarageManager.FuelVehcile(i_LicensePlate, this.m_CurrentClient.m_Vehicle.GetEngine()........
                    }
                    break;
                case UI.eUserOptions.ReChargeVehicle:
                    OutputToConsole("enter amout of time to charge vehicle:");
                    float o_TimeToCharge;
                    bool isValidChargeTime = float.TryParse(InputFromConsole(), out o_TimeToCharge);
                    if (isValidChargeTime)
                    {
                        this.m_GarageManager.ChargeVehicle(i_LicensePlate , o_TimeToCharge);
                    }
                    break;
                case UI.eUserOptions.DisplayCarInfo:
                    this.m_GarageManager.GetFullClientInfo(i_LicensePlate);
                    break;
            }

        }

        public static void OutputToConsole(string i_Text)
        {
            Console.WriteLine(i_Text);
        }

        public static string InputFromConsole()
        {
            return Console.ReadLine();
        }
    }
}