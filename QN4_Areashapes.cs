// QN 4 Area of shapes 
using System;
    class Program
{
   static void Main()
    {
        const int maxattempts = 3; //Sets max attempts to 3 , a constant
        int attempts = 0;  // Initial attempts set to 0
        bool validChoice = false;

        while (attempts < maxattempts && !validChoice)// && this is an 'and' operator in C# 
        {
            Console.WriteLine("Choose shape u want to get area of :");
            Console.WriteLine("1.Triangle");
            Console.WriteLine("2. Rectangle");
            Console.WriteLine("3.Circle ");
            string choice = Console.ReadLine(); // now this is something new ,so whatever input in writeline is converted to a string named choice which we will be used in switch method cause of diff inputs

            switch (choice) // For cases remember to add break run into sum issues by ommiting it ,executes a code block from a list of case conditions for which the expression validates as true
            {
                case "1":
                    validChoice = true;
                    Console.WriteLine("Enter base of the triangle:");
                    double tribase = Convert.ToDouble(Console.ReadLine());

                    Console.WriteLine("Enter height of the triangle:");
                    double triheight = Convert.ToDouble(Console.ReadLine());

                    double areatri = tribase * triheight * 0.5;
                    Console.WriteLine("The area of the Trianagle is :" + areatri);
                    break;

                case "2":
                    validChoice = true;
                    Console.WriteLine("Enter lenghth of the rectangle: ");
                    double rectLength = Convert.ToDouble(Console.ReadLine());

                    Console.WriteLine("Enter width of the rectangle: ");
                    double rectWidth = Convert.ToDouble(Console.ReadLine());

                    double areaRect = rectLength * rectWidth;
                    Console.WriteLine("Area of the Rectangle is : " + areaRect);
                    break;

                case "3":
                    validChoice = true;
                    Console.WriteLine("Enter radius of the circle: ");
                    double radiCircle = Convert.ToDouble(Console.ReadLine());

                    double areaCircle = Math.PI * radiCircle * radiCircle;
                    Console.WriteLine("Area of the CIrcle is : " + areaCircle);
                    break;

                default: // incase of errors to show number of attempts remaining to input correct value
                    attempts++;
                    Console.WriteLine("Invalid input." + (maxattempts - attempts) + " Attemps remaining ");
                    if (maxattempts == attempts)
                    {
                        Console.WriteLine("NO attempts remaining , Existing the program");
                    }
                    break;

            }
        }
    }
}
