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

        public static GarageManager.eSupportedVehciles ParseVehicleTypeInput(string i_Input, GarageManager i_GarageManager)
        {
            GarageManager.eSupportedVehciles vehicleTypeInput = 0;
            //Type o_Result = null;
            GarageManager.eSupportedVehciles typeOfInput = (GarageManager.eSupportedVehciles)(Enum.Parse(typeof(GarageManager.eSupportedVehciles), i_Input));
            switch (typeOfInput)
            {
                case GarageManager.eSupportedVehciles.ElectricBike:
                    vehicleTypeInput = GarageManager.eSupportedVehciles.ElectricBike;
                   /* if (i_GarageManager.SupportedTypesDictionary.TryGetValue(typeOfInput, out o_Result))
                    {
                        vehicleTypeInput = o_Result;
                    }*/
                    break;
                case GarageManager.eSupportedVehciles.ElectricCar:
                    vehicleTypeInput = GarageManager.eSupportedVehciles.ElectricCar;
                    /*if (i_GarageManager.SupportedTypesDictionary.TryGetValue(typeOfInput, out o_Result))
                    {
                        vehicleTypeInput = o_Result;
                    }*/
                    break;
                case GarageManager.eSupportedVehciles.FueledBike:
                    vehicleTypeInput = GarageManager.eSupportedVehciles.FueledBike;
                    /*if (i_GarageManager.SupportedTypesDictionary.TryGetValue(typeOfInput, out o_Result))
                    {
                        vehicleTypeInput = o_Result;
                    }*/
                    break;
                case GarageManager.eSupportedVehciles.FueledCar:
                    vehicleTypeInput = GarageManager.eSupportedVehciles.FueledCar;
                    /*if (i_GarageManager.SupportedTypesDictionary.TryGetValue(typeOfInput, out o_Result))
                    {
                        vehicleTypeInput = o_Result;
                    }*/
                    break;
                case GarageManager.eSupportedVehciles.Truck:
                    vehicleTypeInput = GarageManager.eSupportedVehciles.Truck;
                    /*if (i_GarageManager.SupportedTypesDictionary.TryGetValue(typeOfInput, out o_Result))
                    {
                        vehicleTypeInput = o_Result;
                    }*/
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

        public static Car.eCarColor ParseCarColorInput(string i_Input)
        {
            Car.eCarColor userOption = 0;
            switch ((Car.eCarColor)(Enum.Parse(typeof(Car.eCarColor), i_Input)))
            {
                case Car.eCarColor.Black:
                    userOption = Car.eCarColor.Black;
                    break;
                case Car.eCarColor.Red:
                    userOption = Car.eCarColor.Red;
                    break;
                case Car.eCarColor.White:
                    userOption = Car.eCarColor.White;
                    break;
                case Car.eCarColor.Yellow:
                    userOption = Car.eCarColor.Yellow;
                    break;
                default:
                    throw new FormatException("Invalid input, must be 1,2,3 or 4");
            }
            return userOption;
        }

        public static Car.eNumOfDoors ParseNumOfDoorsInput(string i_Input)
        {
            Car.eNumOfDoors userOption = 0;
            switch ((Car.eNumOfDoors)(Enum.Parse(typeof(Car.eNumOfDoors), i_Input)))
            {
                case Car.eNumOfDoors.Two:
                    userOption = Car.eNumOfDoors.Two;
                    break;
                case Car.eNumOfDoors.Three:
                    userOption = Car.eNumOfDoors.Three;
                    break;
                case Car.eNumOfDoors.Four:
                    userOption = Car.eNumOfDoors.Four;
                    break;
                case Car.eNumOfDoors.Five:
                    userOption = Car.eNumOfDoors.Five;
                    break;
                default:
                    throw new FormatException("Invalid input, must be 2,3,4 or 5");
            }
            return userOption;
        }

        public static FueledEngine.eFuelType ParseFuelTypeInput(string i_Input)
        {
            FueledEngine.eFuelType userOption = 0;
            switch ((FueledEngine.eFuelType)(Enum.Parse(typeof(FueledEngine.eFuelType), i_Input)))
            {
                case FueledEngine.eFuelType.Octan95:
                    userOption = FueledEngine.eFuelType.Octan95;
                    break;
                case FueledEngine.eFuelType.Octan96:
                    userOption = FueledEngine.eFuelType.Octan96;
                    break;
                case FueledEngine.eFuelType.Octan98:
                    userOption = FueledEngine.eFuelType.Octan98;
                    break;
                case FueledEngine.eFuelType.Soler:
                    userOption = FueledEngine.eFuelType.Soler;
                    break;
                default:
                    throw new FormatException("Invalid input, must be 1,2,3 or 4");
            }
            return userOption;
        }

        public static bool ParseToxicInput(string i_Input)
        {
            bool userOption = false;
            switch (i_Input)
            {
                case "yes":
                    userOption = true;
                    break;
                case "no":
                    userOption = false;
                    break;
                default:
                    throw new FormatException("Invalid input, must be 'yes' or 'no'");
            }
            return userOption;
        }
    }
}
