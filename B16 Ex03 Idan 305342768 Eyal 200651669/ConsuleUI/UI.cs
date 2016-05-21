using System;
using Ex03.GarageLogic;
using System.Collections.Generic;

namespace ConsuleUI
{
    class UI
    {
        public enum eUserOptions
        {
            InsertNewVehicle = 1,
            DisplayFilteredLicenses = 2,
            ChangeVehicleStatus = 3,
            SetTires = 4,
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
            DisplayOutputToConsole(string.Format("Hello and Welcome to the garage.{0}what is your license plate number:",
                    Environment.NewLine));
            string licensePlate = RecieveInputFromConsole();

            if (this.m_GarageManager.ManageClient(licensePlate) == true)
            {
                DisplayOutputToConsole("your car is'nt in our garage.");
            }
            else
            {
                DisplayOutputToConsole("your vehicle is already in our garage. what would you like to do?");
                ChooseUserActions();
            }

        }

        public static GarageClient EnterNewClient()
        {

            GarageClient client;
            string clientVehicleString = string.Empty;
            GarageManager.eSupportedVehciles clientVehicle;
            string carDetailsInput = string.Empty;
            DisplayOutputToConsole(string.Format("i see your car is'nt in our database.{0} please give us your details so we can recieve your car",
                Environment.NewLine));
            clientVehicleString =


            Dictionary < string, Type > vehicleMembers =



            return client;

        }

        public static void DisplayOutputToConsole(string i_Text)
        {
            System.Console.WriteLine(i_Text);
        }

        public static string RecieveInputFromConsole()
        {
            return System.Console.ReadLine();
        }

        public void ChooseUserActions(string i_UserOption)
        {
            eUserOptions userOption = ParseUserOptions(i_UserOption);
        }

    }
}

