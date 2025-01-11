using System;

namespace StringAnalyzer
{
    public static class Program
    {
        public static void Main()
        {
            analyzeString();
        }

        private static bool isNumber(string i_StringToValidate)
        {
            bool isNumber = false;

            if (!string.IsNullOrEmpty(i_StringToValidate))
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

        private static bool isLetters(string i_StringToValidate)
        {
            bool isLetters = false;

            if (!string.IsNullOrEmpty(i_StringToValidate))
            {
                isLetters = true;

                foreach (char c in i_StringToValidate)
                {
                    if (!char.IsLetter(c))
                    {
                        isLetters = false;
                        break;
                    }
                }
            }

            return isLetters;
        }

        private static eTypeOfStrings validateString(string i_StringToValidate)
        {
            eTypeOfStrings type = eTypeOfStrings.False;

            if (!string.IsNullOrEmpty(i_StringToValidate) && i_StringToValidate.Length == 10)
            {
                if (isLetters(i_StringToValidate))
                {
                    type = eTypeOfStrings.Letters;
                }
                else if (isNumber(i_StringToValidate))
                {
                    type = eTypeOfStrings.Numerical;
                }
                else
                {
                    type = eTypeOfStrings.False;
                }
            }

            return type;
        }

        private static string isPalindromeRec(string i_IsStringPalindrome, int i_StartIndex, int i_EndIndex)
        {
            string result;

            if (i_StartIndex > i_EndIndex)
            {
                result = "Yes";
            }
            else if (i_IsStringPalindrome[i_StartIndex] != i_IsStringPalindrome[i_EndIndex])
            {
                result = "No";
            }
            else
            {
                result = isPalindromeRec(i_IsStringPalindrome, i_StartIndex + 1, i_EndIndex - 1);
            }

            return result;
        }

        private static string isDividedByFour(string i_StringToCheck)
        {
            double stringAsNumber = double.Parse(i_StringToCheck);
            string isDividedByFour;

            if (stringAsNumber % 4 == 0)
            {
                isDividedByFour = "Yes";
            }
            else
            {
                isDividedByFour = "No";
            }

            return isDividedByFour;
        }

        private static int countLowerCaseLetters(string i_StringToCheck)
        {
            int numberOfLowerCaseLetters = 0;

            foreach (char c in i_StringToCheck)
            {
                if (char.IsLower(c))
                {
                    numberOfLowerCaseLetters++;
                }
            }

            return numberOfLowerCaseLetters;
        }

        private static string descendingAlphabeticalOrder(string i_StringToCheck)
        {
            string stringToCheckAsLowerCase = i_StringToCheck.ToLower();
            string isDescending = "Yes";

            for (int i = 1; i < i_StringToCheck.Length; i++)
            {
                if (stringToCheckAsLowerCase[i - 1] <= stringToCheckAsLowerCase[i])
                {
                    isDescending = "No";
                }
            }

            return isDescending;
        }

        private static void analyzeString()
        {
            bool isInputValid = false;
            string userInput;

            Console.WriteLine("Enter a string with 10 characters: ");

            while (!isInputValid)
            {
                userInput = Console.ReadLine();

                if (string.IsNullOrEmpty(userInput) || userInput.Length != 10)
                {
                    Console.WriteLine("Invalid input. Please ensure the string has exactly 10 characters.");
                    continue;
                }

                eTypeOfStrings validatedStringType = validateString(userInput);

                switch (validatedStringType)
                {
                    case eTypeOfStrings.False:
                        Console.WriteLine("Invalid input. Please try again.");
                        break;

                    case eTypeOfStrings.Letters:
                        analyzeLetters(userInput);
                        isInputValid = true;
                        break;

                    case eTypeOfStrings.Numerical:
                        analyzeNumbers(userInput);
                        isInputValid = true;
                        break;
                }
            }
        }

        private static void analyzeLetters(string i_Input)
        {
            Console.WriteLine($"Is a palindrome: {isPalindromeRec(i_Input, 0, i_Input.Length - 1)}");
            Console.WriteLine($"Number of lowercase letters: {countLowerCaseLetters(i_Input)}");
            Console.WriteLine($"Is in descending alphabetical order: {descendingAlphabeticalOrder(i_Input)}");
        }

        private static void analyzeNumbers(string i_Input)
        {
            Console.WriteLine($"Is a palindrome: {isPalindromeRec(i_Input, 0, i_Input.Length - 1)}");
            Console.WriteLine($"Is divisible by 4 without remainder: {isDividedByFour(i_Input)}");
        }
    }
}
