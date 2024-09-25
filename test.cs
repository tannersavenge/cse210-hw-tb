using System;

class Calculator
{
    // Function for addition
    static float Add(float num1, float num2)
    {
        return num1 + num2;
    }

    // Function for subtraction
    static float Subtract(float num1, float num2)
    {
        return num1 - num2;
    }

    // Function for multiplication
    static float Multiply(float num1, float num2)
    {
        return num1 * num2;
    }

    // Function for division
    static float Divide(float num1, float num2)
    {
        if (num2 == 0)
        {
            Console.WriteLine("Error! Division by zero.");
            return 0;
        }
        return num1 / num2;
    }

    // Main function to handle user input and operation choice
    static void Main(string[] args)
    {
        Console.WriteLine("Choose an operation:");
        Console.WriteLine("1 - Addition");
        Console.WriteLine("2 - Subtraction");
        Console.WriteLine("3 - Multiplication");
        Console.WriteLine("4 - Division");
        
        int choice = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter the first number:");
        float num1 = Convert.ToSingle(Console.ReadLine());

        Console.WriteLine("Enter the second number:");
        float num2 = Convert.ToSingle(Console.ReadLine());

        float result = 0;

        switch (choice)
        {
            case 1:
                result = Add(num1, num2);
                break;
            case 2:
                result = Subtract(num1, num2);
                break;
            case 3:
                result = Multiply(num1, num2);
                break;
            case 4:
                result = Divide(num1, num2);
                break;
            default:
                Console.WriteLine("Invalid choice");
                break;
        }

        if (choice >= 1 && choice <= 4)
        {
            Console.WriteLine("The result is: " + result);
        }
    }
}
