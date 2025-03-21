// Credit for purchase , Wasn't much here just experimented with for loop and while loop
/*"for" loop is basically used when the number of times loop statements are to be executed is known beforehand. U will see comments in my code 
try for fun to understand looping */

using System;

class CreditCheck
{
    static void Main()
    {
        Console.Write("Enter the number of customers: ");
        int n = int.Parse(Console.ReadLine()); // Read the number of customers

        for (int i = 1; i <= n; i++) // Loop for each customer
        {
            Console.WriteLine($"\nCustomer {i}:");

            // Read credit limit
            Console.Write("Enter your credit limit: ");
            double creditLimit = double.Parse(Console.ReadLine());

            // Read item price
            Console.Write("Enter the price of the item: ");
            double price = double.Parse(Console.ReadLine());

            double totalValue;/* When using for loop instead of "while(true)" below set this to
                                 double totalValue = 0;/*
            int quantity; 
            
            /* Below u can replace with for loop  "for (int i = 1; i <= n; i++)" as long as u initialize
            value of "totalValue to 1 as shown above if not firmiliar with using Boolean */
            
            while (true) 
            {
                Console.Write("Enter the quantity of items you want to purchase: ");
                quantity = int.Parse(Console.ReadLine());

                totalValue = price * quantity; // Calculate total value

                if (totalValue > creditLimit)
                {
                    Console.WriteLine("Sorry, you cannot purchase goods worth such a value on credit.");
                    Console.WriteLine("Please re-enter a valid quantity.");
                }
                else
                {
                    break; // Exit loop if the purchase is valid
                }
            }

            Console.WriteLine($"Thank You for purchasing from us!");
            Console.WriteLine($"Total Purchase Value: {totalValue:C}"); // Displays value in currency format
        }
    }
}
