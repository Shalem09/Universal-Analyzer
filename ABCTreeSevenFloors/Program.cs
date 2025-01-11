using System;

namespace ABCTreeSevenFloors
{
    public static class Program
    {
        public static void Main()
        {
            BuildTree(7, 1, 0);
        }

        public static void BuildTree(int i_Height, int i_RowIndex, int i_LetterIndex)
        {
            const string k_Letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            int maxDigits = i_Height.ToString().Length;

            if (i_RowIndex > i_Height)
            {
                return;
            }

            if (i_RowIndex <= i_Height - 2)
            {
                i_LetterIndex = printTreeRow(i_Height, i_RowIndex, i_LetterIndex, k_Letters, maxDigits);
            }
            else
            {
                printTreeTrunk(i_Height, i_RowIndex, i_LetterIndex, k_Letters, maxDigits);
            }

            BuildTree(i_Height, i_RowIndex + 1, i_LetterIndex);
        }

        private static int printTreeRow(int i_Height, int i_RowIndex, int i_LetterIndex, string i_Letters, int i_MaxDigits)
        {
            int numOfLettersInRow = 2 * i_RowIndex - 1;
            string row = "";

            for (int j = 0; j < numOfLettersInRow; j++)
            {
                row += i_Letters[i_LetterIndex % i_Letters.Length];
                if (j < numOfLettersInRow - 1)
                {
                    row += " ";
                }
                i_LetterIndex++;
            }

            string spaces = new string(' ', (i_Height - i_RowIndex) * 2);
            string lineNumber = i_RowIndex.ToString().PadLeft(i_MaxDigits);
            Console.WriteLine($"{lineNumber} {spaces}{row}{Environment.NewLine}");

            return i_LetterIndex;
        }

        private static void printTreeTrunk(int i_Height, int i_RowIndex, int i_LetterIndex, string i_Letters, int i_MaxDigits)
        {
            string trunkSpaces = new string(' ', ((i_Height - 1) * 2) - 1);
            string trunkLetter = i_Letters[i_LetterIndex % i_Letters.Length].ToString();
            string trunk = $"|{trunkLetter}|";
            string lineNumber = i_RowIndex.ToString().PadLeft(i_MaxDigits);

            Console.WriteLine($"{lineNumber} {trunkSpaces}{trunk}{Environment.NewLine}");
        }
    }
}