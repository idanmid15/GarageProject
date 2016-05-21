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

        public static GarageManager.eSupportedVehciles ParseVehicleTypeInput(string i_Input)
        {
            GarageManager.eSupportedVehciles vehicleTypeInput = 0;
            
            switch ((GarageManager.eSupportedVehciles)(Enum.Parse(typeof(GarageManager.eSupportedVehciles), i_Input)))
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
                case default :
                    throw new FormatException("Invalid input, must be a valid vehicle");
            }
            return vehicleTypeInput;
        }
    }
}