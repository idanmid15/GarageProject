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

        public static GarageManager.eSupportedVehciles ParseCarTypeInput(string i_Input)
        {
            GarageManager.eSupportedVehciles vehicleTypeInput;
            bool isValid = false;
            
            switch (i_Input)
            {
                case GarageManager.eSupportedVehciles.ElectricBike.ToString():
                    isValid = true;
                    break;
                
            }
        }
    }
}