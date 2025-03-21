    QN1.
    using System;

class GameProgram
{ 
    static void Main()
    {
        int totalScore = 0;
        Random rand = new Random(); // Choose to set  secret num as random variable,keeps it interesting its a game after all 
        int secretNumber = rand.Next(2, 10); // Generates a random secret number between 2 and 9

        Console.WriteLine($"(Secret number has been randomly chosen!)");

        Console.Write("Enter the number of rounds: ");
        int rounds = int.Parse(Console.ReadLine());

        for (int i = 1; i <= rounds; i++)
        {
            Console.Write($"Enter your lucky number for round {i} Champ !!: ");
            int luckyNumber = int.Parse(Console.ReadLine());

            int remainder = luckyNumber % secretNumber;

            if (remainder == 0)
            {
                totalScore += 1; // Draw
                Console.WriteLine("Draw! +1 point, one on one my guy niko na wewe HAHAHA..");
            }
            else if (remainder % 2 == 0) // Being divisble by 2 without reminder makes it even
            {
                totalScore += 3; // Win
                Console.WriteLine("Win! +3 points");
            }
            else
            {
                totalScore -= 3; // Loss
                Console.WriteLine("Loss! -3 points, Don't cry on my keyboard!!");
            }
        }

        Console.WriteLine($"\nFinal Score: {totalScore}");
        Console.WriteLine($"(The secret number was: {secretNumber})"); // Revealing the secret number at the end

        if (totalScore > 0)
            Console.WriteLine("Congratulations! You win! , You must really be lucky!");
        else
            Console.WriteLine("Game over! You lose. Give me 50 Pushups!!");
    }
}
