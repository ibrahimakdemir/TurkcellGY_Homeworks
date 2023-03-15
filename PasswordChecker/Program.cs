
bool exit = true;

while (exit)
{
    bool again = true;

    PasswordChecker checker = new PasswordChecker();

    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.Write("Please Enter The Password(Min 6 character): ");
    string password = Console.ReadLine();
    Console.ResetColor();

    // Checking the length of the password
    if (checker.lengthCheck(password))
    {
        Console.WriteLine(checker.characterCheck(password));
        Console.ResetColor();
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Please Enter At Least 6 Character!\n");
        Console.ResetColor();
    }

    while (again)
    {
        try
        {
            Console.WriteLine("\nAgain?\n1- Yes\n2- Exit\n");
            int close = Convert.ToInt32(Console.ReadLine());

            if (close == 1)
            {
                Console.Clear();
                again = false;
                exit = true;
            }
            else if (close == 2)
            {
                again = false;
                exit = false;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid Input!\n");
                Console.ResetColor();
            }

        }
        catch (Exception)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid Input!\n");
            Console.ResetColor();
        }
    }
}

public class PasswordChecker
{
    /// <summary>
    /// This function checks the length of the password it takes as a parameter. Returns false if the length of the password is less than 6 characters.
    /// </summary>
    /// <param name="password">Password entered by the user.</param>
    /// <returns></returns>
    public bool lengthCheck(string password)
    {
        return password.Length >= 6 ? true : false;
    }


    /// <summary>
    /// This function checks whether the password entered by the user contains letters, numbers and symbols. Returns "WEAN" if it consists of numbers or letters only, "MEDIUM" if it contains both numbers and letters but no symbols, and "STRONG" if it contains both numbers and letters and symbols.
    /// </summary>
    /// <param name="password">Password entered by the user.</param>
    /// <returns></returns>
    public string characterCheck(string password)
    {
        int countNumber = 0;
        int countLetter = 0;
        int countSymbol = 0;

        foreach (char character in password)
        {
            if (char.IsNumber(character))
            {
                countNumber++;
            }
            else if (char.IsLetter(character))
            {
                countLetter++;
            }
            else
            {
                countSymbol++;
            }
        }

        if (countLetter == password.Length || countNumber == password.Length)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            return "ZAYIF";
        }
        else if (countLetter > 0 && countNumber > 0 && countSymbol == 0)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            return "ORTA";
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Green;
            return "GÜÇLÜ";
        }
    }

}