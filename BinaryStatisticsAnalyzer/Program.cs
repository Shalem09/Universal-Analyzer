using System;

namespace BinaryStatisticsAnalyzer
{
    public class Program
    {
        public static void Main()
        {
            binaryStatisticsAnalyzer();
        }

        private static bool validateBinaryNumber(string i_NumberToValidate)
        {
            bool isValid = false;

            if (i_NumberToValidate.Length == 8 &&
                int.TryParse(i_NumberToValidate, out int parsedNumber) &&
                parsedNumber >= 0)
            {
                isValid = true;

                foreach (char c in i_NumberToValidate)
                {
                    if (c != '0' && c != '1')
                    {
                        isValid = false;
                        break;
                    }
                }
            }

            return isValid;
        }

        private static int binaryToIntegerConvert(string i_BinaryNumberAsString)
        {
            int numberInBinary = int.Parse(i_BinaryNumberAsString);
            int decimalValue = 0;
            int baseValue = 1;

            while (numberInBinary > 0)
            {
                int lastDigit = numberInBinary % 10;
                decimalValue += lastDigit * baseValue;
                numberInBinary /= 10;
                baseValue *= 2;
            }

            return decimalValue;
        }

        private static double averageOfThreeNumbers(int[] i_DecimalNumbersArray)
        {
            double sumOfThreeNumbers = 0;

            foreach (int number in i_DecimalNumbersArray)
            {
                sumOfThreeNumbers += number;
            }

            return sumOfThreeNumbers / 3;
        }

        private static int countBinarySequence(string i_NumberToCount)
        {
            int maxLength = 0;
            int currentLength = 1;

            for (int i = 1; i < i_NumberToCount.Length; i++)
            {
                if (i_NumberToCount[i] == i_NumberToCount[i - 1])
                {
                    currentLength++;
                }
                else
                {
                    maxLength = Math.Max(maxLength, currentLength);
                    currentLength = 1;
                }
            }

            return Math.Max(maxLength, currentLength);
        }

        private static int longestBinarySequence(string[] i_BinaryNumbers)
        {
            int maxSequenceLength = 0;

            foreach (string binaryNumber in i_BinaryNumbers)
            {
                int currentSequence = countBinarySequence(binaryNumber);
                maxSequenceLength = Math.Max(maxSequenceLength, currentSequence);
            }

            return maxSequenceLength;
        }

        private static int countChangesInNumber(string i_NumberToCount)
        {
            int numberOfChanges = 0;

            for (int i = 1; i < i_NumberToCount.Length; i++)
            {
                if (i_NumberToCount[i] != i_NumberToCount[i - 1])
                {
                    numberOfChanges++;
                }
            }

            return numberOfChanges;
        }

        private static int countForZeros(string i_NumberToCheck)
        {
            int numberOfZeros = 0;

            foreach (char c in i_NumberToCheck)
            {
                if (c == '0')
                {
                    numberOfZeros++;
                }
            }

            return numberOfZeros;
        }

        private static string mostZerosAndLeastOnes(string[] i_BinaryNumbers)
        {
            string numberWithMostZeros = i_BinaryNumbers[0];
            int maxZeroCount = countForZeros(i_BinaryNumbers[0]);

            foreach (string binaryNumber in i_BinaryNumbers)
            {
                int zeroCount = countForZeros(binaryNumber);

                if (zeroCount > maxZeroCount)
                {
                    maxZeroCount = zeroCount;
                    numberWithMostZeros = binaryNumber;
                }
            }

            return numberWithMostZeros;
        }

        private static string[] getBinaryNumbersFromUser(int i_Count, int i_Length)
        {
            string[] binaryNumbers = new string[i_Count];
            int currentCount = 0;

            Console.WriteLine($"Enter {i_Count} binary numbers with {i_Length} digits each: ");
            while (currentCount < i_Count)
            {
                string userInput = Console.ReadLine();

                if (validateBinaryNumber(userInput) && userInput.Length == i_Length)
                {
                    binaryNumbers[currentCount++] = userInput;
                }
                else
                {
                    Console.WriteLine("Invalid binary number. Please try again.");
                }
            }

            return binaryNumbers;
        }

        private static int[] convertBinaryNumbersToDecimal(string[] i_BinaryNumbers)
        {
            int[] decimalNumbers = new int[i_BinaryNumbers.Length];

            for (int i = 0; i < i_BinaryNumbers.Length; i++)
            {
                decimalNumbers[i] = binaryToIntegerConvert(i_BinaryNumbers[i]);
            }

            return decimalNumbers;
        }

        private static void printResults(string[] i_BinaryNumbers, int[] i_DecimalNumbers, 
            string i_NumberWithMostZerosAndLeastOnes)
        {
            Console.WriteLine($"{Environment.NewLine}All binary numbers validated successfully!");
            Console.WriteLine($"The decimal values are: {string.Join(", ", i_DecimalNumbers)}.");
            Console.WriteLine($"The average value of the three numbers in decimal " +
                $"representation is: {averageOfThreeNumbers(i_DecimalNumbers).ToString("F2")}.");
            Console.WriteLine($"The longest sequence of bits (zeros or ones) " +
                $"among the three numbers is: {longestBinarySequence(i_BinaryNumbers)}.");
            Console.WriteLine("The number of transitions from 0 to 1 or from 1 to 0 in the numbers are:");
            for (int i = 0; i < i_BinaryNumbers.Length; i++)
            {
                Console.WriteLine($"In the number {i_BinaryNumbers[i]}: {countChangesInNumber(i_BinaryNumbers[i])}");
            }
            Console.WriteLine($"The number with the most 0s and the least 1s " +
                $"is: {binaryToIntegerConvert(i_NumberWithMostZerosAndLeastOnes)} " +
                $"(Binary: {i_NumberWithMostZerosAndLeastOnes}).");
        }

        private static void binaryStatisticsAnalyzer()
        {
            string[] binaryNumbers = getBinaryNumbersFromUser(3, 8);
            int[] decimalNumbers = convertBinaryNumbersToDecimal(binaryNumbers);

            string numberWithMostZerosAndLeastOnes = mostZerosAndLeastOnes(binaryNumbers);
            Array.Sort(decimalNumbers);

            printResults(binaryNumbers, decimalNumbers, numberWithMostZerosAndLeastOnes);
        }
    }
}
