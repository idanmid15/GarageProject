using System;

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
    }
}