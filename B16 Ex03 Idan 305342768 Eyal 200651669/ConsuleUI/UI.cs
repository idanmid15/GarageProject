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

        public Dictionary<GarageManager.eSupportedVehciles, int> NumOfWheelsPerVehicle = new Dictionary<GarageManager.eSupportedVehciles, int>
        {
            {GarageManager.eSupportedVehciles.ElectricBike, 2},
            {GarageManager.eSupportedVehciles.ElectricCar, 4},
            {GarageManager.eSupportedVehciles.FueledBike, 2},
            {GarageManager.eSupportedVehciles.FueledCar, 4},
            {GarageManager.eSupportedVehciles.Truck, 16}
        };

        GarageManager m_GarageManager;
        GarageClient m_CurrentClient;

        public UI()
        {
            this.m_GarageManager = new GarageManager();
            this.m_CurrentClient = null;
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
                //create a new client profile
                this.m_CurrentClient = EnterNewClient();
                //enter the new client to our data structure
                this.m_GarageManager.setGarageDictonary(this.m_CurrentClient.m_Vehicle.GetLicensePlate(), this.m_CurrentClient);
            }

            Console.Clear();
            OutputToConsole("****Thank you! We've entered your details into our system****");
            ChooseUserActions(licensePlate);
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
            while (!isValidVehicleOption)
            {
                try
                {
                    clientVehicleOptionString = InputFromConsole();
                    clientVehicle = UserInputExceptions.ParseVehicleTypeInput(clientVehicleOptionString, this.m_GarageManager);
                    isValidVehicleOption = true;
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            Vehicle newVehicle = enterNewVehicleMembers(clientVehicle);

            string[] clientDetails = enterNewClientDetails();
            client = new GarageClient(clientDetails[0], clientDetails[1], newVehicle, GarageClient.eVehicleStatus.InRepair);
            return client;

        }

        private Vehicle enterNewVehicleMembers(GarageManager.eSupportedVehciles i_SupportedVehicle)
        {
            List<MemberTranslator> vehicleMembersList = null;
            List<object> membersFromInputList = new List<object>();
            object[] vehicleMembersArray = null;
            bool isMemberValid = false;
            string memberInput = string.Empty;
            int o_NumOfTires = 0;
            string o_ResultMembers = string.Empty;
            object ParsedMemberInput = null;

            vehicleMembersList = this.m_GarageManager.GetVehicleMembers(i_SupportedVehicle);

            foreach (MemberTranslator param in vehicleMembersList)
            {
                //filling the tires requires a different method to form a "tires array"
                if (param.m_MemberName.Equals("m_Wheels")) {
                    if (NumOfWheelsPerVehicle.TryGetValue(i_SupportedVehicle, out o_NumOfTires))
                    {
                        ParsedMemberInput = enterNewTiresArray(o_NumOfTires);
                        isMemberValid = true;
                    }
                //for all the rest of the members
                } else {
                    OutputToConsole(string.Format("enter {0}:", param.m_MemberTranslation));      
                    isMemberValid = false;
                }
                while (!isMemberValid)
                {
                    try
                    {
                        memberInput = InputFromConsole();
                        ParsedMemberInput = UserInputExceptions.ExceptionParser(memberInput, param.m_MemberType);
                        
                        isMemberValid = true;
                    }
                    catch (Exception e)
                    {
                        OutputToConsole(e.Message);
                    }
                }
                membersFromInputList.Add(ParsedMemberInput);

            }

            //create a new vehicle instance with all relevant params for the specific car type given
            vehicleMembersArray = membersFromInputList.ToArray();
            Vehicle vehicleInstance = this.m_GarageManager.CreateVehicle(i_SupportedVehicle, vehicleMembersArray);
            return vehicleInstance;
        }

        private float[] enterNewTiresArray(int i_NumOfWheels)
        {
            float[] tiresArray = new float[i_NumOfWheels];
            string memberInput = string.Empty;
            float o_Tire;
            bool isValid = false;

            for (int i = 0; i < tiresArray.Length; i++)
            {
                OutputToConsole(string.Format("enter pressure of tire No. {0}:", i));
                isValid = false;
                while (!isValid)
                {
                    memberInput = InputFromConsole();
                    if (Single.TryParse(memberInput, out o_Tire))
                    {
                        tiresArray[i] = o_Tire;
                        isValid = true;
                    }else
                    {
                        OutputToConsole("wheel pressure must be a positive float number");
                    }
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

        public void ChooseUserActions(string i_LicensePlate)
        {
            eUserOptions userOption = 0;
            string currentLicensePlate = this.m_CurrentClient.m_Vehicle.GetLicensePlate();
            bool isValidAction = false;
            string userActionInput = string.Empty;
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
                    userActionInput = InputFromConsole();
                    userOption = UserInputExceptions.ParseUserOptions(userActionInput);
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
                        //this.m_CurrentClient.FuelVehcile(i_LicensePlate, this.m_CurrentClient.m_Vehicle.GetEngine());
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
                    Console.Clear();
                    string outoutDetails = this.m_GarageManager.GetFullClientInfo(currentLicensePlate);
                    OutputToConsole(outoutDetails);
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
