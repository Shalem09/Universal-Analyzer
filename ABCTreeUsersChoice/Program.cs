using System;

namespace ABCTreeUsersChoice
{
    public static class Program
    {
        public static void Main()
        {
            int treeHeight = getTreeHeight();

            ABCTreeSevenFloors.Program.BuildTree(treeHeight, 1, 0);
        }

        private static int getTreeHeight()
        {
            Console.Write("Please insert tree height: ");
            bool isValidHeight = validateHeight(Console.ReadLine(), out int height);

            while (!isValidHeight)
            {
                Console.Write($"Invalid height.{Environment.NewLine}Please try again and enter a positive value between 1-15: ");
                isValidHeight = validateHeight(Console.ReadLine(), out height);
            }

            return height;
        }

        private static bool validateHeight(string i_UserInput, out int o_Height)
        {
            return int.TryParse(i_UserInput, out o_Height) && o_Height > 0 && o_Height <= 15;
        }
    }
}