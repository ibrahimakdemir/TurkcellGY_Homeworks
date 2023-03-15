# Array With Conditions And Loops

## 👉Introduction

I developed this console application to reinforce the topics taught by our instructor [Türkay Ürkmez](https://github.com/turkayurkmez) during the Turkcell's "Gençlere Yatırım, Geleceğe Yazılım!"

>**Here I will add detailed explanations of how each step of the code is performed. This reinforces the knowledge I have used while writing the code.**

Using the knowledge I acquired from this week's lessons, including array, while, for, try-catch, switch-case, Random, and flag, I have developed a console application. This application will use arrays to display the highest and lowest numbers, separate odd-even-prime numbers, and calculate the average and sum of the numbers.

The application will go through the following steps:

* The length of the array will be determined, either by user input or by a random number. The user will choose this using a switch-case statement.
* Using a for loop, the numbers will be randomly selected and an array will be created.
* The console will display the highest and lowest numbers, separate odd-even-prime numbers, and the average and sum of the numbers.

---

## 🔎Code Overview

>**I used `Console.ForegroundColor` to change the colors as I don't like the default terminal colors.**

### 🚦Determining The Length Of The Array

```C#
    switch (choose)
        {
            case 1:
                // Entering the length of the array
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
```

Here I control the user's choice with switch-case. The user entering 1 indicates that the user wants to determine the length of the array himself, while entering 2 indicates that the user wants the length of the array to be determined randomly. `lengthArray = random.Next(5, 30);` with this code, I access the `Next()` function using the object named `random` that I created from the Random library and generate a random number between 5 and 30. Random selected length is printed using '**interpolated strings**'.

---

### 📲Randomly Adding The Number To The Array

```C#

    int[] numbers = new int[lengthArray];

    for (int i = 0; i < lengthArray; i++)
    {
        numbers[i] = random.Next(0, 100);
    }
```

In this code block, I define an integer array of the specified length. After creating the array, a randomly selected number between 0 and 100 is written to each index using the for loop. With the code block below, I print the array that I have finished assigning values ​​to, using the for loop in the same way. Also, after writing the value in the last index, I check with 'if-else statement' if I am in the last index to avoid putting ','.

```C#

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
```

---

### 📐Finding The Smallest And Largest Number In The Array

```C#
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
```

In order to find the largest and smallest number, first I define two variables named `smallestNumber` and `largestNumber` which are equal to the first element of the defined array. I am comparing `smallestNumber` variable with other values ​​in array using for loop. If the next value is a smaller number, I write this value to the `smallestNumber` variable. For `largestNumber`, if there is a larger value than itself, I write that value to the variable. So I can find the smallest and largest number.

---

### 💻Calculating The Sum And Average Of Numbers In The Array

```C#
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
```

I define a variable named `sum` and `average` and use the `addition assignment operator` in the for loop and write the 'sum' variable by summing the values ​​in all indexes. I calculated the average by dividing the `sum` value by the length of the array.

---

### 🎭Finding The Odd And Even Numbers In The Array

```C#
int[] oddNumbers = new int[lengthArray];
int[] evenNumbers = new int[lengthArray];

for (int i = 0; i < lengthArray; i++)
{
    if (numbers[i] % 2 == 0)
    {
        evenNumbers[i] = numbers[i];
        oddNumbers[i] = -1;
    }
    else
    {
        oddNumbers[i] = numbers[i];
        evenNumbers[i] = -1;
    }
}
```

This snippet splits odd and even numbers in a `numbers` array into two arrays named `oddNumbers` and `evenNumbers` separately. First, the arrays `oddNumbers` and `evenNumbers` are created as empty as the length of the `numbers` array. Then, using a 'for' loop, the 'numbers' array is traversed and each element is checked for odd or even numbers. If the element is an even number, that element is assigned to the `evenNumbers` array and the `oddNumbers` array in the same index is assigned the value -1. Thus, elements with a value of -1 in the `oddNumbers` array replace elements that are not actually even numbers. If the element is an odd number, that element is assigned to the array `oddNumbers` and the `evenNumbers` array in the same index is assigned the value -1. Thus, elements with a value of -1 in the `evenNumbers` array replace elements that are not actually odd numbers. As a result, there are only odd numbers in the `oddNumbers` array, and only even numbers in the `evenNumbers` array. I print values that are not equal to -1 in the arrays I obtain.

```C#
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
```

---

### 🔎Finding the prime numbers in the array

```C#
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
    }

}
```

In this code block, I first define a new array of integers named `primeNumbers` which is the same length as `numbers`. I also define a bool variable `isPrime` as false. I then check the mode of each number in the `numbers` array with all the integers from 2 to itself if its mode is equal to 0 then that number is not prime. If it is not divisible by any number, it is a prime number. I also check if this number is 2 or a smaller number. If the number is equal to 2, I am stating that the number is prime without using the mod operation. If the number is less than 2, it is not prime. Here I can tell if a number is prime or not with the `isPrime` flag. If it is a prime number, I add this number to the `primeNumbers` array. If not, I add the number -1. Thus, when I want to see the elements of the array, I can select those that are not equal to -1.

```C#
// The prime numbers
Console.ForegroundColor = ConsoleColor.Cyan;
Console.Write("\nThe prime numbers: ");
for (int i = 0; i < lengthArray; i++)
{
    if (primeNumbers[i] != -1)
    {
        Console.Write($"{primeNumbers[i]} ");
    }
}
```

---

### 🔚The End Of The Application

At the end of the application, I want to prompt the user to decide whether they want to run the program again or exit. The code first outputs three lines of text to the console, asking the user if they want to run the program again. The user can choose either option 1 (Yes) or 2 (Exit) by entering a number. If the user selects option 1, the code clears the console and the program starts again from the beginning. If the user selects option 2 , the program will close.

```C#
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
```

---

### The Screenshots Of The Application

1. Determining The Length Of The Array

    ![Screenshot1](/Arrays/Screenshots/1.png)

2. Showing Result

    ![Screenshot1](/Arrays/Screenshots/1.png)

3. The End Of The Application

    ![Screenshot1](/Arrays/Screenshots/1.png)

---

<br>
<br>
<p style="text-align: center;"><a href="https://github.com/ibrahimakdemir" target="blank"><img align="center" src="https://raw.githubusercontent.com/rahuldkjain/github-profile-readme-generator/master/src/images/icons/Social/github.svg" alt="ibrakdemir" height="30" width="40" style="text-align:center"/></a>
<a href="https://instagram.com/ibrakdemir" target="blank"><img align="center" src="https://raw.githubusercontent.com/rahuldkjain/github-profile-readme-generator/master/src/images/icons/Social/instagram.svg" alt="ibrakdemir" height="30" width="40" /></a>
<a href="https://www.linkedin.com/in/ibrakdemir/" target="blank"><img align="center" src="https://raw.githubusercontent.com/rahuldkjain/github-profile-readme-generator/master/src/images/icons/Social/linked-in-alt.svg" alt="ibrakdemir" height="30" width="40" /></a>
</p>

