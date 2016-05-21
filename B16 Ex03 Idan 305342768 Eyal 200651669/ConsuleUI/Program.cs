using System;
using Ex03.GarageLogic;

namespace ConsuleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            displayOutputToConsole(string.Format("Hello and Welcome to the garage.{0}what is your license plate number:",
                Environment.NewLine));
            string licensePlate = recieveInputFromConsole();
            GarageManager GarageManager = new GarageManager();
            
            if (GarageManager.ManageClient(licensePlate) == true)
            {
                enterNewClient();
            } else
            {

            }

        }

        public static GarageClient enterNewClient()
        {

            GarageClient client;
            displayOutputToConsole(string.Format("i see your car is not in out database.{0} please give us your details to recieve your car",
                Environment.NewLine));

            return client;
            
        }

        public static void displayOutputToConsole(string i_Text)
        {
            System.Console.WriteLine(i_Text);
        }

        public static string recieveInputFromConsole()
        {
            return System.Console.ReadLine();
        }
    }
}
