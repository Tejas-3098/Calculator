using System;

namespace Calculator
{
    class Calculator
    {
        public static double DoOperation(double no1, double no2, string op)
        {
            double res = double.NaN; // Setting default value as "Not-A-Number" in the case when an operation like division could return an error.
            switch (op)
            {
                case "A":
                    res = no1 + no2;
                    break;
                case "S":
                    res = no1 - no2;
                    break;
                case "M":
                    res = no1 * no2;
                    break;
                case "D":
                    if (no2 != 0)
                    {
                        res = no1 / no2;
                    }
                    break;
                default:
                    break;
            }
            return res;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            bool quitApp = false;
            //Displaying the title of the calculator
            Console.WriteLine("Console Calculator in C#\r");
            Console.WriteLine("-------------------------\n");

            while (!quitApp)
            {
                //Declaring variables as empty strings
                String firstNumber = "";
                String secondNumber = "";
                double result = 0;
                //Prompting the user to enter the first number.
                Console.WriteLine("Please type a number and then press Enter");
                firstNumber = Console.ReadLine();

                double cleanFirstNumber = 0;
                while (!double.TryParse(firstNumber, out cleanFirstNumber))
                {
                    Console.Write("This is an invalid input. Please enter an integer value!");
                    firstNumber = Console.ReadLine();

                }
                //Prompting the user to enter the first number.
                Console.WriteLine("Please type another number and then press Enter");
                secondNumber = Console.ReadLine();

                double cleanSecondNumber = 0;
                while (!double.TryParse(secondNumber, out cleanSecondNumber))
                {
                    Console.Write("This is an invalid input. Please enter an integer value!");
                    secondNumber = Console.ReadLine();

                }

                //Asking the user to choose which operation they want to perform
                Console.WriteLine("Please choose the operation you want to do from the following list:");
                Console.WriteLine("\tA - Add");
                Console.WriteLine("\tS - Subtract");
                Console.WriteLine("\tM - Multiply");
                Console.WriteLine("\tD - Divide");
                Console.Write("Which option? ");

                String op = Console.ReadLine();
                try
                {
                    result = Calculator.DoOperation(cleanFirstNumber, cleanSecondNumber, op);
                    if (double.IsNaN(result))
                    {
                        Console.WriteLine("This operation will result in a mathematical error.\n");
                    }
                    else Console.WriteLine("Your result: {0:0.##}\n", result);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Oh no! An exception occurred trying to do the math.\n - Details: " + e.Message);
                }

                Console.WriteLine("------------------------\n");

                // Wait for the user to respond before closing.
                Console.Write("Press 'n' and Enter to close the app, or press any other key and Enter to continue: ");
                if (Console.ReadLine() == "n") quitApp = true;

                Console.WriteLine("\n"); // Friendly linespacing.
            }
            return;
        }
    }
}

