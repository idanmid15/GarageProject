using System;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class UserInputExceptions
    {
        public static object ExceptionParser(string i_Input, Type i_Type)
        {

            object parsedMemberInput = null;
            switch (i_Type.ToString())
            {
                case "System.String":
                    parsedMemberInput = i_Input;
                    break;
                case "System.Single":
                    parsedMemberInput = ParseFloatInput(i_Input);
                    break;
                case "System.Int32":
                    parsedMemberInput = ParseIntegerInput(i_Input);
                    break;
                case "System.Boolean":
                    parsedMemberInput = ParseToxicInput(i_Input);
                    break;
                case "Ex03.GarageLogic.Bike+eLicenseType":
                    parsedMemberInput = ParseBikeLicenseType(i_Input);
                    break;
                case "Ex03.GarageLogic.Car+eNumOfDoors":
                    parsedMemberInput = ParseNumOfDoorsInput(i_Input);
                    break;
                case "Ex03.GarageLogic.Car+eCarColor":
                    parsedMemberInput = ParseCarColorInput(i_Input);
                    break;
                default:
                    break;
            }

            return parsedMemberInput;
        }

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
                throw new FormatException("Invalid input, must be of integer type. Please try again");
            }

            return integerInput;
        }

        public static string ParsePhoneNumber(string i_Input)
        {
            int integerInput;
            bool isValid;

            isValid = int.TryParse(i_Input, out integerInput) || (integerInput > 0); 
            if (!isValid)
            {
                throw new FormatException("Invalid input, must be a positiv integer, without a colon in between. Please try again");
            }

            return i_Input;
        }

        public static GarageManager.eSupportedVehciles ParseVehicleTypeInput(string i_Input, GarageManager i_GarageManager)
        {
            GarageManager.eSupportedVehciles vehicleTypeInput = 0;
            GarageManager.eSupportedVehciles typeOfInput = 0;
            try
            {
                typeOfInput = (GarageManager.eSupportedVehciles)(Enum.Parse(typeof(GarageManager.eSupportedVehciles), i_Input));
            }
            catch
            {
                throw new FormatException("Invalid input, must be a valid vehicle");
            }

            switch (typeOfInput)
            {
                case GarageManager.eSupportedVehciles.ElectricBike:
                    vehicleTypeInput = GarageManager.eSupportedVehciles.ElectricBike;
                    break;
                case GarageManager.eSupportedVehciles.ElectricCar:
                    vehicleTypeInput = GarageManager.eSupportedVehciles.ElectricCar;
                    break;
                case GarageManager.eSupportedVehciles.FueledBike:
                    vehicleTypeInput = GarageManager.eSupportedVehciles.FueledBike;
                    break;
                case GarageManager.eSupportedVehciles.FueledCar:
                    vehicleTypeInput = GarageManager.eSupportedVehciles.FueledCar;
                    break;
                case GarageManager.eSupportedVehciles.Truck:
                    vehicleTypeInput = GarageManager.eSupportedVehciles.Truck;
                    break;
                default:
                    throw new FormatException("Invalid input, you must enter a number (1-5) represting a supported vehicle");
            }
            return vehicleTypeInput;
        }

        public static UI.eUserOptions ParseUserOptions(string i_UserOption)
        {
            UI.eUserOptions userOption = 0;
            try
            {
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
                        throw new FormatException("Invalid input, you must enter a number (1-7) represting an action in our garage");
                }
            } catch
            {
                throw new FormatException("Invalid input, you must enter a number (1-7) represting an action in our garage");
            }
            return userOption;
        }

        public static GarageClient.eVehicleStatus ParseVehicleDisplayFilter(string i_Input)
        {
            GarageClient.eVehicleStatus userOption = 0;
            try
            {
                switch ((GarageClient.eVehicleStatus)(Enum.Parse(typeof(GarageClient.eVehicleStatus), i_Input)))
                {
                    case GarageClient.eVehicleStatus.InRepair:
                        userOption = GarageClient.eVehicleStatus.InRepair;
                        break;
                    case GarageClient.eVehicleStatus.NotInRepair:
                        userOption = GarageClient.eVehicleStatus.NotInRepair;
                        break;
                    case GarageClient.eVehicleStatus.None:
                        userOption = GarageClient.eVehicleStatus.None;
                        break;
                    default:
                        throw new FormatException("Invalid input, must be 1 (or 'InRepair'), 2 (or 'NotInRepair') or 3 (or 'None') for no filter");
                }
            }
            catch
            {
                throw new FormatException("Invalid input, must be 1 (or 'InRepair'), 2 (or 'NotInRepair') or 3 (or 'None') for no filter");
            }
            return userOption;
        }

        public static GarageClient.eVehicleStatus ParseVehcileStatusChange(string i_Input)
        {
            GarageClient.eVehicleStatus userOption = 0;
            try
            {
                switch ((GarageClient.eVehicleStatus)(Enum.Parse(typeof(GarageClient.eVehicleStatus), i_Input)))
                {
                    case GarageClient.eVehicleStatus.InRepair:
                        userOption = GarageClient.eVehicleStatus.InRepair;
                        break;
                    case GarageClient.eVehicleStatus.NotInRepair:
                        userOption = GarageClient.eVehicleStatus.NotInRepair;
                        break;
                    default:
                        throw new FormatException("Invalid input, must be 1 (or 'InRepair'), 2 (or 'NotInRepair')");
                }
            }
            catch
            {
                throw new FormatException("Invalid input, must be 1 (or 'InRepair'), 2 (or 'NotInRepair')");
            }
            return userOption;
        }

        public static Car.eCarColor ParseCarColorInput(string i_Input)
        {
            Car.eCarColor userOption = 0;
            try
            {
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
                        throw new FormatException("Invalid input, must be 'Black', 'Red', 'White' or 'Yellow'");
                }
            }
            catch
            {
                throw new FormatException("Invalid input, must be 'Black', 'Red', 'White' or 'Yellow'");
            }
            return userOption;
        }

        public static Car.eNumOfDoors ParseNumOfDoorsInput(string i_Input)
        {
            Car.eNumOfDoors userOption = 0;
            try
            {
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
                        throw new FormatException("Invalid input, must be 'Two', 'Three', 'Four' or 'Five'");
                }
            }
            catch
            {
                throw new FormatException("Invalid input, must be 'Two', 'Three', 'Four' or 'Five'");
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
                 case FueledEngine.eFuelType.Octan98:
                     userOption = FueledEngine.eFuelType.Octan98;
                     break;
                 case FueledEngine.eFuelType.Soler:
                     userOption = FueledEngine.eFuelType.Soler;
                     break;
                 default:
                     throw new FormatException("Invalid input, must be 'Octan95', 'Octan96', Octan98' or 'Soler'");
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


        public static Bike.eLicenseType ParseBikeLicenseType(string i_Input)
        {
            Bike.eLicenseType userOption = 0;
            try
            {
                switch ((Bike.eLicenseType)(Enum.Parse(typeof(Bike.eLicenseType), i_Input)))
                {
                    case Bike.eLicenseType.A:
                        userOption = Bike.eLicenseType.A;
                        break;
                    case Bike.eLicenseType.A1:
                        userOption = Bike.eLicenseType.A1;
                        break;
                    case Bike.eLicenseType.AB:
                        userOption = Bike.eLicenseType.AB;
                        break;
                    case Bike.eLicenseType.B1:
                        userOption = Bike.eLicenseType.B1;
                        break;
                    default:
                        throw new FormatException("Invalid input, valid licenses are: 'A', 'A1', 'AB' or 'B1'");
                }
            }
            catch
            {
                throw new FormatException("Invalid input, valid licenses are: 'A', 'A1', 'AB' or 'B1'");
            }
            return userOption;
        }
    }
}
