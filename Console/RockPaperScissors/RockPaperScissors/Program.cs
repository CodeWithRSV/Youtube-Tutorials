while (true)
{
    Console.WriteLine("Type ROCK,PAPER or SCISSORS:");
    string input = Console.ReadLine();
    if (Enum.TryParse(input, out RPS enumValue))
    {
        Random random = new Random();
        RPS rPS = (RPS)random.Next(0, 3);
        Console.WriteLine("Computer chose " + rPS.ToString());
        if (rPS == enumValue)
        {
            Console.WriteLine("Draw");
        }
        else if (rPS == enumValue + 1 || rPS == enumValue - 2)
        {
            Console.WriteLine("Computer wins");
        }
        else
        {
            Console.WriteLine("You win");
        }
    }
    else
    {
        Console.WriteLine("!!Invalid Input!!");
    }
    Console.WriteLine("Do you want to play again?(Y/N)");
    string choice = Console.ReadLine();
    if (choice != "Y") break;
}

enum RPS
{
    ROCK,PAPER,SCISSORS
}

