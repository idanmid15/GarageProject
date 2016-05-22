using System;
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

        public UI()
        {
            m_GarageManager = new GarageManager();
        }

        public void RunUI()
        {
            string userAction = string.Empty;
            DisplayOutputToConsole(string.Format("Hello and Welcome to the garage.{0}what is your license plate number:",
                    Environment.NewLine));
            string licensePlate = RecieveInputFromConsole();

            if (this.m_GarageManager.ManageClient(licensePlate) == true)
            {
                DisplayOutputToConsole("your car is'nt in our garage.");
            }
            else
            {
                DisplayOutputToConsole("what action would you like to do:");
                userAction = RecieveInputFromConsole();
                ChooseUserActions(userAction, licensePlate);
            }

        }

        public static GarageClient EnterNewClient()
        {

            GarageClient client;
            string clientVehicleString = string.Empty;
            GarageManager.eSupportedVehciles clientVehicle;
            string carDetailsInput = string.Empty;
            DisplayOutputToConsole(string.Format("Please give us your details so we can recieve your car",
                Environment.NewLine));
            clientVehicleString =


            Dictionary < string, Type > vehicleMembers =



            return client;

        }

        public void DisplayFilteredGarageVehicles()
        {
            DisplayOutputToConsole(string.Format("would you like to filter the type of cars to display?{0}Type 1- for in repair staus{0}Type 2 - for not in repair", System.Environment.NewLine));
            bool isValidFilter = false;
            GarageClient.eVehicleStatus vehicleDisplayFilter;
            while (!isValidFilter)
            {
                try
                {
                    vehicleDisplayFilter = UserInputExceptions.ParsevehicleDisplayFilter(RecieveInputFromConsole());
                    this.m_GarageManager.DisplayVehcilesInGarage(vehicleDisplayFilter);
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
            }

        }

        public void ChooseUserActions(string i_UserOption, string i_LicensePlate)
        {
            eUserOptions userOption = eUserOptions.InsertNewVehicle;
            bool isValidAction = false;
            DisplayOutputToConsole(
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
                    this.m_GarageManager.UpdateCarStatus(i_LicensePlate);
                    break;
                case UI.eUserOptions.InflateTires:
                    this.m_GarageManager.SetTirePressureToMax(i_LicensePlate);
                    break;
                case UI.eUserOptions.RefuelVehicle:
                    this.m_GarageManager.FuelVehcile(i_LicensePlate);
                    break;
                case UI.eUserOptions.ReChargeVehicle:
                    this.m_GarageManager.ChargeVehicle(i_LicensePlate);
                    break;
                case UI.eUserOptions.DisplayCarInfo:
                    this.m_GarageManager.GetFullClientInfo(i_LicensePlate);
            }

        }

        public static void DisplayOutputToConsole(string i_Text)
        {
            System.Console.WriteLine(i_Text);
        }

        public static string RecieveInputFromConsole()
        {
            return System.Console.ReadLine();
        }
    }
}
