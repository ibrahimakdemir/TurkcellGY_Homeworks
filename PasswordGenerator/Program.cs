
PasswordGenerator passwordGenerator = new PasswordGenerator();
PasswordChecker passwordChecker = new PasswordChecker();


// Generate and check passwords until a "WEAK" password is generated.
// Prints the number of tries it took to generate a "WEAK" password to the console
/*
string password = string.Empty;
int numberOfTry = 0;
do
{
    password = passwordGenerator.GeneratePassword(15);
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine($"Password: {password}");

    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine($"Password is {passwordChecker.characterCheck(password)}");
    numberOfTry++;
} while (passwordChecker.characterCheck(password) != "WEAK");

Console.WriteLine($"Number of try: {numberOfTry}");
*/


string password = passwordGenerator.GeneratePassword(passwordGenerator.PasswordLength());
Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine($"Password: {password}");

Console.ForegroundColor = ConsoleColor.Cyan;
Console.WriteLine($"Password is {passwordChecker.characterCheck(password)}");
Console.ResetColor();

public class PasswordGenerator
{
    /// <summary>
    /// a method that prompts the user to enter a password length and validates their input to ensure that the length is at least 6 characters long.
    /// </summary>
    /// <returns></returns>
    public int PasswordLength()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        while (true)
        {
            try
            {
                Console.Write("Enter the length of the password(at least 6):");
                int passwordLength = int.Parse(Console.ReadLine());

                if (passwordLength < 6)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please enter a number greater than 5!");
                    Console.ResetColor();

                }
                else
                {
                    return passwordLength;
                }
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please enter a number!");
                Console.ResetColor();

            }
        }
    }


    /// <summary>
    /// a method that generates a random password of a specified length using ASCII characters.
    /// </summary>
    /// <param name="length">Length of the password</param>
    /// <returns></returns>
    public string GeneratePassword(int length)
    {
        string password = string.Empty;
        Random random = new Random();

        for (int i = 0; i < length; i++)
        {
            int randomAsciiNumber = random.Next(33, 127);
            password += (char)randomAsciiNumber;
        }
        return password;

    }
}
