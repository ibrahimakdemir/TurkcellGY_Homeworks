using System;

int lengthArray = 0;
Random random = new Random();
while (true)
{
    try
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\n\t\t******************Welcome******************\n");

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\n1- Enter the length of the array");
        Console.WriteLine("2- Randomizing the length of the array");

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("\nDetermining the length of the array:");

        Console.ForegroundColor = ConsoleColor.Red;
        int choose = Convert.ToInt32(Console.ReadLine());

        switch (choose)
        {
            case 1:
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("Enter the length of the array: ");
                lengthArray = Convert.ToInt32(Console.ReadLine());
                break;
            case 2:
                // Random length
                lengthArray = random.Next(5, 30);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write($"\nThe length of the array: {lengthArray}\n");
                break;
            default:
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Please enter 1 or 2!\n\n");
                break;
        }

        // Randomly adding the number to the array 
        int[] numbers = new int[lengthArray];

        for (int i = 0; i < lengthArray; i++)
        {
            numbers[i] = random.Next(0, 100);
        }

        // Printing the array
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("\nThe array: ");
        for (int i = 0; i < lengthArray; i++)
        {
            if (i == lengthArray - 1)
            {
                Console.Write($"{numbers[i]}");
            }
            else
            {
                Console.Write($"{numbers[i]}, ");
            }
        }

        // Finding smallest and largest number in the array

        int smallestNumber = numbers[0];
        int largestNumber = numbers[0];

        for (int i = 0; i < lengthArray - 1; i++)
        {
            if (smallestNumber >= numbers[i + 1])
            {
                smallestNumber = numbers[i + 1];
            }

            if (largestNumber <= numbers[i + 1])
            {
                largestNumber = numbers[i + 1];
            }
        }

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"\n\nThe smallest number: {smallestNumber}");
        Console.WriteLine($"The largest number: {largestNumber}");


        // Calculating the sum and average of numbers in the array

        int sum = 0;
        double average = 0;
        for (int i = 0; i < lengthArray; i++)
        {
            sum += numbers[i];
        }

        average = (double)sum / lengthArray;

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"\nThe sum of the numbers: {sum}");
        Console.WriteLine($"The average of the numbers: {average}");

        // Finding the odd and even numbers in the array

        int[] oddNumbers = new int[lengthArray];
        int[] evenNumbers = new int[lengthArray];
        // We don't know how many odd-even numbers there are so we choose the length of the this array assuming they are all odd-even 

        for (int i = 0; i < lengthArray; i++)
        {
            if (numbers[i] % 2 == 0)
            {
                evenNumbers[i] = numbers[i];
                oddNumbers[i] = -1;     // By putting -1 I indicate that there isn't a number in this index
            }
            else
            {
                oddNumbers[i] = numbers[i];
                evenNumbers[i] = -1;    // By putting -1 I indicate that there isn't a number in this index
            }
        }

        // Printing the even-odd numbers
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("\nThe even numbers: ");
        for (int i = 0; i < lengthArray; i++)
        {
            if (evenNumbers[i] != -1)
            {
                Console.Write($"{evenNumbers[i]} ");
            }

        }

        Console.Write("\nThe odd numbers: ");
        for (int i = 0; i < lengthArray; i++)
        {
            if (oddNumbers[i] != -1)
            {
                Console.Write($"{oddNumbers[i]} ");
            }
        }


        // Finding the prime numbers in the array
        int[] primeNumbers = new int[lengthArray];
        bool isPrime = false;

        for (int i = 0; i < lengthArray; i++)
        {

            for (int j = 2; j < numbers[i]; j++)
            {
                if (numbers[i] == 2)
                {
                    isPrime = true;
                    break;
                }
                else if (numbers[i] > 2)
                {
                    if (numbers[i] % j == 0)
                    {
                        isPrime = false;
                        break;
                    }
                    else
                    {
                        isPrime = true;
                    }
                }
                else
                {
                    isPrime = false;
                    break;
                }
            }

            if (isPrime)
            {
                primeNumbers[i] = numbers[i];
            }
            else
            {
                primeNumbers[i] = -1;
                // By putting -1 I indicate that there isn't a number in this index

            }

        }

        // Printing the prime numbers
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("\nThe prime numbers: ");
        for (int i = 0; i < lengthArray; i++)
        {
            if (primeNumbers[i] != -1)
            {
                Console.Write($"{primeNumbers[i]} ");
            }
        }

    }
    catch (FormatException)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Please enter 1 or 2!\n\n");
    }
    Console.WriteLine("\n\n");

    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("Again?");
    Console.WriteLine("1- Yes");
    Console.WriteLine("2- Exit");
    int again = Convert.ToInt32(Console.ReadLine());

    if (again == 1)
    {
        Console.Clear();
    }
    else
    {
        Console.ResetColor();
        break;
    }

}