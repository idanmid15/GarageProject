using System;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class UserInputExceptions
    {
        public static float ParseFloatInput(string i_Input)
        {
            float floatInput;
            bool isValid;

            isValid = float.TryParse(i_Input, out floatInput);
            if (!isValid)
            {
                throw new FormatException("Invalid input, must be of floating point type. Please try again");
            }

            return floatInput;
        }

        public static int ParseIntegerInput(string i_Input)
        {
            int integerInput;
            bool isValid;

            isValid = int.TryParse(i_Input, out integerInput);
            if (!isValid)
            {
                throw new FormatException("Invalid input, must be of floating point type. Please try again");
            }

            return integerInput;
        }

        public static Type ParseVehicleTypeInput(string i_Input, GarageManager i_GarageManager)
        {
            Type vehicleTypeInput =null;
            Type o_Result = null;
            GarageManager.eSupportedVehciles typeOfInput = (GarageManager.eSupportedVehciles)(Enum.Parse(typeof(GarageManager.eSupportedVehciles), i_Input));
            switch (typeOfInput)
            {
                case GarageManager.eSupportedVehciles.ElectricBike:
                    //vehicleTypeInput = typeof(GarageManager.eSupportedVehciles.ElectricBike;
                    if (i_GarageManager.SupportedTypesDictionary.TryGetValue(typeOfInput, out o_Result))
                    {
                        vehicleTypeInput = o_Result;
                    }
                    break;
                case GarageManager.eSupportedVehciles.ElectricCar:
                    if (i_GarageManager.SupportedTypesDictionary.TryGetValue(typeOfInput, out o_Result))
                    {
                        vehicleTypeInput = o_Result;
                    }
                    break;
                case GarageManager.eSupportedVehciles.FueledBike:
                    if (i_GarageManager.SupportedTypesDictionary.TryGetValue(typeOfInput, out o_Result))
                    {
                        vehicleTypeInput = o_Result;
                    }
                    break;
                case GarageManager.eSupportedVehciles.FueledCar:
                    if (i_GarageManager.SupportedTypesDictionary.TryGetValue(typeOfInput, out o_Result))
                    {
                        vehicleTypeInput = o_Result;
                    }
                    break;
                case GarageManager.eSupportedVehciles.Truck:
                    if (i_GarageManager.SupportedTypesDictionary.TryGetValue(typeOfInput, out o_Result))
                    {
                        vehicleTypeInput = o_Result;
                    }
                    break;
                default:
                    throw new FormatException("Invalid input, must be a valid vehicle");
            }
            return vehicleTypeInput;
        }

        public static UI.eUserOptions ParseUserOptions(string i_UserOption)
        {
            UI.eUserOptions userOption = 0;
            switch ((UI.eUserOptions)(Enum.Parse(typeof(GarageManager.eSupportedVehciles), i_UserOption)))
            {
                case UI.eUserOptions.InsertNewVehicle:
                    userOption = UI.eUserOptions.InsertNewVehicle;
                    break;
                case UI.eUserOptions.DisplayFilteredLicenses:
                    userOption = UI.eUserOptions.DisplayFilteredLicenses;
                    break;
                case UI.eUserOptions.ChangeVehicleStatus:
                    userOption = UI.eUserOptions.ChangeVehicleStatus;
                    break;
                case UI.eUserOptions.InflateTires:
                    userOption = UI.eUserOptions.InflateTires;
                    break;
                case UI.eUserOptions.RefuelVehicle:
                    userOption = UI.eUserOptions.RefuelVehicle;
                    break;
                case UI.eUserOptions.ReChargeVehicle:
                    userOption = UI.eUserOptions.ReChargeVehicle;
                    break;
                case UI.eUserOptions.DisplayCarInfo:
                    userOption = UI.eUserOptions.DisplayCarInfo;
                    break;
                default:
                    throw new FormatException("Invalid input, must be 1-7");
            }
            return userOption;
        }

        public static GarageClient.eVehicleStatus ParsevehicleDisplayFilter(string i_Input)
        {
            GarageClient.eVehicleStatus userOption = 0;
            switch ((GarageClient.eVehicleStatus)(Enum.Parse(typeof(GarageClient.eVehicleStatus), i_Input)))
            {
                case GarageClient.eVehicleStatus.InRepair:
                    userOption = GarageClient.eVehicleStatus.InRepair;
                    break;
                case GarageClient.eVehicleStatus.NotInRepair:
                    userOption = GarageClient.eVehicleStatus.NotInRepair;
                    break;
                default:
                    throw new FormatException("Invalid input, must be 1 or 2");
            }
            return userOption;
        }
    }
}
