using System;
using Ex03.GarageLogic;
using System.Collections.Generic;
namespace ConsuleUI
{
    class UI
    {
        public void RunUI()
        {
            DisplayOutputToConsole(string.Format("Hello and Welcome to the garage.{0}what is your license plate number:",
                    Environment.NewLine));
            string licensePlate = RecieveInputFromConsole();
            GarageManager GarageManager = new GarageManager();

            if (GarageManager.ManageClient(licensePlate) == true)
            {
                EnterNewClient();
            }
            else
            {

            }

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

}

