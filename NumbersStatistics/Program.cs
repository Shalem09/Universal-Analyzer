using System;
using System.Text;

namespace NumbersStatistics
{
    public static class Program
    {
        public static void Main()
        {
            numericalStatistics();
        }

        private static bool validateNumber(string i_StringToValidate)
        {
            bool isNumber = false;

            if (!string.IsNullOrEmpty(i_StringToValidate) && i_StringToValidate.Length == 9)
            {
                isNumber = true;

                foreach (char c in i_StringToValidate)
                {
                    if (!char.IsDigit(c))
                    {
                        isNumber = false;
                        break;
                    }
                }
            }

            return isNumber;
        }

        private static int digitsBiggerThanUnits(string i_StringToCheck)
        {
            int digitsBiggerThanUnits = 0;
            StringBuilder sb = new StringBuilder(i_StringToCheck);
            char numberOfunits = i_StringToCheck[8];

            sb.Remove(sb.Length - 1, 1);
            foreach (char c in sb.ToString())
            {
                if (c > numberOfunits)
                {
                    digitsBiggerThanUnits++;
                }
            }

            return digitsBiggerThanUnits;
        }

        private static int howManyDividesByFour(string i_StringToCheck)
        {
            int digitsThatDividesByFour = 0;
            StringBuilder sb = new StringBuilder(i_StringToCheck);

            while (sb.Length > 0)
            {
                int numberOfUnits = int.Parse(sb[sb.Length - 1].ToString());
                if (numberOfUnits % 4 == 0)
                {
                    digitsThatDividesByFour++;
                }
                sb.Remove(sb.Length - 1, 1);
            }

            return digitsThatDividesByFour;
        }

        private static double maxDigitMinDigitRatio(string i_StringToCheck)
        {
            int maxDigit = 0;
            int minDigit = 9;
            int currDigit;
            double ratio;

            for (int i = 0; i < i_StringToCheck.Length; i++)
            {
                currDigit = (int)char.GetNumericValue(i_StringToCheck[i]);

                if (currDigit > maxDigit)
                {
                    maxDigit = currDigit;
                }

                if (currDigit < minDigit && currDigit != 0)
                {
                    minDigit = currDigit;
                }
            }

            ratio = (double)maxDigit / (double)minDigit;

            return ratio;
        }

        private static int sumOfMathSeries(int i_NumberOfReturns)
        {
            int firstNumber = 1;
            int lastNumber = i_NumberOfReturns;
            int sum = (i_NumberOfReturns * (firstNumber + lastNumber)) / 2;

            return sum;
        }

        private static int numberOfCouples(string i_StringToCheck)
        {
            int numberOfCouples = 0;
            int countNumbersArraySize = 10;
            int[] countNumbersArray = new int[countNumbersArraySize];

            foreach (char c in i_StringToCheck)
            {
                countNumbersArray[int.Parse(c.ToString())]++;
            }

            for (int i = 0; i < countNumbersArraySize; i++)
            {
                if (countNumbersArray[i] >= 2)
                {
                    numberOfCouples += sumOfMathSeries(countNumbersArray[i] - 1);
                }
            }

            return numberOfCouples;
        }

        private static void numericalStatistics()
        {
            string getUserInput;
            bool isValidated = true;

            Console.WriteLine("Enter a string with 9 characters: ");

            while (isValidated)
            {
                getUserInput = Console.ReadLine();

                if (validateNumber(getUserInput))
                {
                    isValidated = false;

                    Console.WriteLine("Number of digits bigger than units number:" +
                        $" {digitsBiggerThanUnits(getUserInput)}");
                    Console.WriteLine("Number of digits divided by 4:" +
                        $" {howManyDividesByFour(getUserInput)}");
                    Console.WriteLine("Ratio between biggest and smallest digits:" +
                        $" {string.Format("{0:F2}", maxDigitMinDigitRatio(getUserInput))}");
                    Console.WriteLine("Number of identical couples:" +
                        $" {numberOfCouples(getUserInput)}");
                }
                else
                {
                    Console.WriteLine("Invalid number. Please try again.");
                }
            }
        }
    }
}