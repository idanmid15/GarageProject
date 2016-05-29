using System;
using System.Collections.Generic;
using Ex03.GarageLogic;

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
            { GarageManager.eSupportedVehciles.ElectricBike, 2 },
            { GarageManager.eSupportedVehciles.ElectricCar, 4 },
            { GarageManager.eSupportedVehciles.FueledBike, 2 },
            { GarageManager.eSupportedVehciles.FueledCar, 4 },
            { GarageManager.eSupportedVehciles.Truck, 16 }
        };

        private GarageManager m_GarageManager;
        private GarageClient m_CurrentClient;
        private string m_MainClientLicensePlate;
        private string m_CurrentVehicleLicensePlate;

        public UI()
        {
            this.m_GarageManager = new GarageManager();
            this.m_CurrentClient = null;
        }

        public static void OutputToConsole(string i_Text)
        {
            Console.WriteLine(i_Text);
        }

        public static string InputFromConsole()
        {
            return Console.ReadLine();
        }

        public static void OutputClearConsole()
        {
            Console.Clear();
        }

        public void RunUI()
        {
            string userAction = string.Empty;
            while (true)
            {
                userAction = string.Empty;
                OutputToConsole(
@"Hello and Welcome to the garage
what is your license plate number?
Notice: since you can have multiple cars in our garage we need the license plate
of your main vehicle:");
                m_MainClientLicensePlate = InputFromConsole();
                m_CurrentVehicleLicensePlate = m_MainClientLicensePlate;
                if (!this.m_GarageManager.ClientExists(m_MainClientLicensePlate))
                {
                    OutputToConsole("your car is'nt in our garage.");
                    
                    ///create a new client profile
                    this.m_CurrentClient = EnterNewClient(m_MainClientLicensePlate);
                    
                    ///enter the new client to our data structure
                    this.m_GarageManager.AddClient(m_MainClientLicensePlate, this.m_CurrentClient);
                    OutputClearConsole();
                    OutputToConsole(string.Format("****Thank you! We've entered your details into our system****{0}", Environment.NewLine));
                }
                else
                {
                    OutputClearConsole();
                    OutputToConsole(string.Format("****Thank you! We've found your details in our system****{0}", Environment.NewLine));
                }

                ChooseUserActions(m_MainClientLicensePlate);
            }
        }

        public GarageClient EnterNewClient(string i_LicensePlate)
        {
            GarageManager.eSupportedVehciles clientVehicle;
            Vehicle newVehicle = EnterNewVehicle(i_LicensePlate, out clientVehicle); 
            string[] clientDetails = enterNewClientDetails();
            return new GarageClient(clientDetails[0], clientDetails[1], newVehicle, GarageClient.eVehicleStatus.InRepair, clientVehicle);
        }

        private Vehicle EnterNewVehicle(string i_LicensePlate, out GarageManager.eSupportedVehciles o_ClientVehicle)
        {
            string clientVehicleOptionString = string.Empty;
            o_ClientVehicle = 0;
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
                    o_ClientVehicle = UserInputExceptions.ParseVehicleTypeInput(clientVehicleOptionString, this.m_GarageManager);
                    isValidVehicleOption = true;
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            return enterNewVehicleMembers(o_ClientVehicle);
        }

        private Vehicle enterNewVehicleMembers(GarageManager.eSupportedVehciles i_SupportedVehicle)
        {
            List<MemberTranslator> vehicleMembersList = null;
            List<object> membersFromInputList = new List<object>();
            Vehicle vehicleInstance = null;
            object[] vehicleMembersArray = null;
            bool isMemberValid = false;
            string memberInput = string.Empty;
            int o_NumOfTires = 0;
            string o_ResultMembers = string.Empty;
            object parsedMemberInput = null;

            vehicleMembersList = this.m_GarageManager.GetVehicleMembers(i_SupportedVehicle);

            foreach (MemberTranslator param in vehicleMembersList)
            {
                ///filling the tires require a different method to form a "tires array"
                if (param.m_MemberName.Equals("m_Wheels"))
                {
                    if (NumOfWheelsPerVehicle.TryGetValue(i_SupportedVehicle, out o_NumOfTires))
                    {
                        parsedMemberInput = enterNewTiresArray(o_NumOfTires, i_SupportedVehicle);
                        isMemberValid = true;
                    }
                    
                    ///for all the rest of the members
                }
                else if (param.m_MemberName == "m_LicensePlate")
                {
                    parsedMemberInput = m_CurrentVehicleLicensePlate;
                    isMemberValid = true;
                }
                else if (param.m_MemberName == "m_CurrentFuelAmount" || param.m_MemberName == "m_ChargeTimeLeft")
                {
                    isMemberValid = false;
                    OutputToConsole(string.Format("enter {0}:", param.m_MemberTranslation));
                    while (!isMemberValid)
                    {
                        try
                        {
                            parsedMemberInput = UserInputExceptions.ParseFuelOrChargeAmount(i_SupportedVehicle, InputFromConsole());
                            isMemberValid = true;                  
                        }
                        catch (ValueOutOfRangeException e)
                        {
                            OutputToConsole(string.Format("{0} Only {1} - {2}{3}", e.Message, e.MinValue, e.MaxValue, Environment.NewLine));
                        }
                        catch (Exception e)
                        {
                            OutputToConsole(e.Message);
                        }
                    }
                }
                else
                {
                    OutputToConsole(string.Format("enter {0}:", param.m_MemberTranslation));
                    isMemberValid = false;
                }

                while (!isMemberValid)
                {
                    try
                    {
                        memberInput = InputFromConsole();
                        parsedMemberInput = UserInputExceptions.ExceptionParser(memberInput, param.m_MemberType);
                        isMemberValid = true;
                    }
                    catch (Exception e)
                    {
                        OutputToConsole(e.Message);
                    }
                }

                membersFromInputList.Add(parsedMemberInput);
                }
           
            ///create a new vehicle instance with all relevant params for the specific car type given
            vehicleMembersArray = membersFromInputList.ToArray();
            vehicleInstance = this.m_GarageManager.CallCreateVehicle(i_SupportedVehicle, vehicleMembersArray);
            return vehicleInstance;
        }

        private float[] enterNewTiresArray(int i_NumOfWheels, GarageManager.eSupportedVehciles i_Vehicle)
        {
            float[] tiresArray = new float[i_NumOfWheels];
            string memberInput = string.Empty;
            float o_Tire;
            bool isValid = false;

            for (int i = 0; i < tiresArray.Length; i++)
            {
                OutputToConsole(string.Format("enter pressure of tire No. {0}:", i + 1));
                isValid = false;
                while (!isValid)
                {
                    memberInput = InputFromConsole();
                    if (float.TryParse(memberInput, out o_Tire))
                    {
                        try
                        {
                            UserInputExceptions.ParseTirePressure(i_Vehicle, memberInput);
                            tiresArray[i] = o_Tire;
                            isValid = true;
                        }
                        catch (ValueOutOfRangeException e)
                        {
                            OutputToConsole(string.Format("{0} Only {1} - {2}{3}", e.Message, e.MinValue, e.MaxValue, Environment.NewLine));
                        }
                    }
                    else
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
            bool isValidPhoneNumber = false;

            while (!isValidPhoneNumber)
            {
                try
                {
                    clientDetails[1] = UserInputExceptions.ParsePhoneNumber(InputFromConsole());
                    isValidPhoneNumber = true;
                }
                catch (Exception e)
                {
                    OutputToConsole(e.Message);
                }
            }

            return clientDetails;
        }

        public void DisplayFilteredGarageVehicles()
        {
            OutputToConsole(string.Format(
@"what is the new status of the vehicle?
enter 1 (or 'InRepair') for vehicle in repair status
enter 2 (or 'NotInRepair') for vehicle not in repair status
enter 3 (or 'None') for no filter on the results"));
            bool isValidFilter = false;
            GarageClient.eVehicleStatus vehicleDisplayFilter;
            string displayFilterString = string.Empty;
            while (!isValidFilter)
            {
                try
                {
                    vehicleDisplayFilter = UserInputExceptions.ParseVehicleDisplayFilter(InputFromConsole());
                    displayFilterString = this.m_GarageManager.DisplayVehiclesInGarage(vehicleDisplayFilter);
                    isValidFilter = true;
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
            }

            OutputToConsole(displayFilterString);
        }

        public void updateVehicleStatus(string i_LicensePlate)
        {
            bool isValidFilter = false;
            GarageClient.eVehicleStatus newStatus;
            OutputToConsole("Please enter the license plate for the status update");
            m_CurrentVehicleLicensePlate = InputFromConsole();

            while (!isValidFilter)
            {
                try
                {
                    OutputToConsole(string.Format(
@"what is the new status of the vehicle?
enter 1 (or 'InRepair') - for in repair status
enter 2 (or 'NotInRepair') - for not in repair status"));
                    newStatus = UserInputExceptions.ParseVehcileStatusChange(InputFromConsole());
                    isValidFilter = true;
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }

                this.m_GarageManager.UpdateVehicleStatus(m_MainClientLicensePlate, m_CurrentVehicleLicensePlate, newStatus);
                OutputToConsole(string.Format("License plate No. {0} changed status to {1}", i_LicensePlate, newStatus.ToString()));
            }
        }

        public void RePowerVehcile(bool isFuelEngine)
        {
            bool isValidInput = false;
            float repowerAmountInput = 0;
            string fuelTypeInput = string.Empty;

            OutputToConsole("Enter license plate number:");
            m_CurrentVehicleLicensePlate = InputFromConsole();
            if (isFuelEngine)
            {
                OutputToConsole("Enter the amount you wish to fuel:");
            }
            else
            { 
                OutputToConsole("Enter how much time you wish to charge:");
            }

            while (!isValidInput)
            {
                try
                {
                    repowerAmountInput = UserInputExceptions.ParseFloatInput(InputFromConsole());
                    isValidInput = true;
                }
                catch (FormatException e)
                {
                    OutputToConsole(e.Message);
                    continue;
                }
            }

            ///now try to parse the input regarding rePower the vehicle
            try
            {
                ///repower the vehicle
                if (isFuelEngine)
                {
                    OutputToConsole(string.Format(
@"Enter Fuel type:
Enter 'Octan95' (or 1), 'Ocatan96' (or 2), , 'Ocatan98' (or 3) or 'Soler' (or 4)"));
                    fuelTypeInput = InputFromConsole();
                    FueledEngine.eFuelType parsedFuelType = UserInputExceptions.ParseFuelTypeInput(fuelTypeInput);
                    UserInputExceptions.CheckIfRepowerArgsExceptions(m_CurrentVehicleLicensePlate, repowerAmountInput, isFuelEngine, m_GarageManager, m_MainClientLicensePlate, parsedFuelType);
                    this.m_GarageManager.FuelVehicle(m_MainClientLicensePlate, m_CurrentVehicleLicensePlate, parsedFuelType, repowerAmountInput);
                    OutputToConsole(string.Format("vehicle {0} has been fueled with {1} liters", m_CurrentVehicleLicensePlate, repowerAmountInput));
                }
                else
                {
                    UserInputExceptions.CheckIfRepowerArgsExceptions(m_CurrentVehicleLicensePlate, repowerAmountInput, isFuelEngine, m_GarageManager, m_MainClientLicensePlate);
                    this.m_GarageManager.ChargeVehicle(m_MainClientLicensePlate, m_CurrentVehicleLicensePlate, repowerAmountInput);
                    OutputToConsole(string.Format("vehicle {0} has been charged with {1} hours", m_CurrentVehicleLicensePlate, repowerAmountInput));
                }
            }
            catch (Exception e)
            {
                OutputToConsole(e.Message);
            }
        }

        public void ChooseUserActions(string i_LicensePlate)
        {
            eUserOptions userOption = 0;
            string currentLicensePlate = m_MainClientLicensePlate;
            bool isValidAction = false;
            string userActionInput = string.Empty;
            const bool v_IsFueledEngine = true;
            OutputToConsole(
@"Choose the action you would like to make (by entering it's number):
1. Insert a new vehicle
2. Display license plates in garage (filtered)
3. Change vehicle status (by license plate)
4. Set tires pressure (by license plate)
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

            OutputClearConsole();
            switch (userOption)
            {
                case UI.eUserOptions.InsertNewVehicle:
                    GarageManager.eSupportedVehciles o_VehicleType;
                    OutputToConsole(string.Format("Please enter a new license plate for your new vehicle{0}", Environment.NewLine));
                    m_CurrentVehicleLicensePlate = InputFromConsole();
                    Vehicle newVehicle = EnterNewVehicle(m_MainClientLicensePlate, out o_VehicleType);
                    this.m_CurrentClient.AddVehicleToClient(newVehicle, GarageClient.eVehicleStatus.InRepair, o_VehicleType, m_CurrentVehicleLicensePlate);
                    break;
                case UI.eUserOptions.DisplayFilteredLicenses:
                    DisplayFilteredGarageVehicles();
                    break;
                case UI.eUserOptions.ChangeVehicleStatus:
                    OutputClearConsole();
                    updateVehicleStatus(currentLicensePlate);
                    break;
                case UI.eUserOptions.InflateTires:
                    this.m_GarageManager.SetTirePressureToMax(m_MainClientLicensePlate, m_CurrentVehicleLicensePlate);
                    OutputToConsole("We have inflated your tires");
                    break;
                case UI.eUserOptions.RefuelVehicle:
                    RePowerVehcile(v_IsFueledEngine);
                    break;
                case UI.eUserOptions.ReChargeVehicle:
                    RePowerVehcile(!v_IsFueledEngine);
                    break;
                case UI.eUserOptions.DisplayCarInfo:
                    string outoutDetails = this.m_GarageManager.GetFullClientInfo(currentLicensePlate);
                    OutputToConsole(outoutDetails);
                    break;
            }
        }
    }
}
