using System;

class DiceRoller
{
    public static void Main()
    {
        Console.WriteLine("Welcome to the Grand Circus Casino!");

        int sides = GetValidIntegerInput("How many sides should each die have? ");

        char rollAgain;
        int rollCount = 1;

        do
        {
            Console.WriteLine($"\nRoll {rollCount}:");

            int die1 = RollDie(sides);
            int die2 = RollDie(sides);
            int total = die1 + die2;

            Console.WriteLine($"You rolled a {die1} and a {die2} ({total} total)");

            // Check special messages for 6-sided dice
            if (sides == 6)
            {
                string comboMessage = GetSixSidedCombo(die1, die2);
                string totalMessage = GetSixSidedTotal(total);

                if (!string.IsNullOrEmpty(comboMessage))
                {
                    Console.WriteLine(comboMessage);
                }

                if (!string.IsNullOrEmpty(totalMessage))
                {
                    Console.WriteLine(totalMessage);
                }
            }

            Console.Write("Roll again? (y/n): ");
            rollAgain = Console.ReadKey().KeyChar;
            Console.WriteLine();

            rollCount++;
        } while (rollAgain == 'y' || rollAgain == 'Y');

        Console.WriteLine("Thanks for playing!!");
    }

    // Static method to validate integer input
    public static int GetValidIntegerInput(string prompt)
    {
        int number;
        Console.Write(prompt);
        while (!int.TryParse(Console.ReadLine(), out number) || number < 1)
        {
            Console.WriteLine("Invalid input. Please enter a valid integer greater than 0.");
            Console.Write(prompt);
        }
        return number;
    }

    // Static method to roll a die with the specified number of sides
    public static int RollDie(int sides)
    {
        Random rand = new Random();
        return rand.Next(1, sides + 1);
    }

    // Static method to check special combinations for six-sided dice
    public static string GetSixSidedCombo(int die1, int die2)
    {
        if (die1 == 1 && die2 == 1) return "Snake Eyes";
        if ((die1 == 1 && die2 == 2) || (die1 == 2 && die2 == 1)) return "Ace Deuce";
        if (die1 == 6 && die2 == 6) return "Boxcars";
        return string.Empty;
    }

    // Static method to check special totals for six-sided dice
    public static string GetSixSidedTotal(int total)
    {
        if (total == 7 || total == 11) return "Win!";
        if (total == 2 || total == 3 || total == 12) return "Craps!";
        return string.Empty;
    }
}