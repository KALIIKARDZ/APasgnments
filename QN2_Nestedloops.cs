//Nested loops :Nested loops are those loops that are present inside another loop. 
    // For this question i found 2 ways to do it :
    /*a) Since number of rows and columns are equal(6) u assign it to a single variable
    e.g in my code "size" set to 6. If u look closely diagonally notice & , Kwa code cheki when 
    "j=i" when index of row and column are the same ndo" &" when not the same" *"*/

 using System;

class PatternProgram
{
    static void Main()
    {
        int size = 6; // Number of rows and columns

        for (int i = 0; i < size; i++) // Outer loop for rows
        {
            for (int j = 0; j < size; j++) // Inner loop for columns
            {
                // First and last rows should be all '&'
                if (i == 0 || i == size - 1)
                    Console.Write("& ");
                // Print '&' at column equal to row index
                else if (i == j)
                    Console.Write("& ");
                else
                    Console.Write("* ");
            }
            Console.WriteLine(); // Move to the next line after each row
        }
    }
}

/*b) So i wondered what if we were given different number of rows and columns lets say 4 rows
5 columns. Code is below , u can replace values of row and column with 6 and still get the same 
result as the 1st example*/

using System;

class PatternProgram
{
    static void Main()
    {
        int rows = 4;  // Number of rows , to match the question weka 6
        int cols = 5;  // Number of columns, same here weka 6

        for (int i = 0; i < rows; i++) // Outer loop for rows
        {
            for (int j = 0; j < cols; j++) // Inner loop for columns
            {
                // First and last row should be all '&'
                if (i == 0 || i == rows - 1)
                    Console.Write("& ");
                // Print '&' where row index and column index are the same (diagonal)
                else if (i == j)
                    Console.Write("& ");
                else
                    Console.Write("* ");
            }
            Console.WriteLine(); // Move to the next line after each row
        }
    }
}
