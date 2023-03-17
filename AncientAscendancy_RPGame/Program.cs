Console.ForegroundColor = ConsoleColor.Yellow;

string startingMessage = "While exploring an ancient city, you will fight to survive and collect necessary resources to obtain the power of the ancient gods. You will venture into the forest, find keys and codes, defeat enemies to earn money and purchase weapons. You will progress through the locations by teleporting. Your ultimate goal is to reach the power of the ancient gods and control the world. As you develop and collect resources, you will become stronger against challenging enemies. At the end of the game, you can showcase your skills and achievements to become the best player in the world.";

foreach (char c in sentence)
{
    Console.Write(c);
    Thread.Sleep(50); // waits 50 milliseconds between each character
}
Console.Clear();
Console.ForegroundColor= ConsoleColor.Green;
Console.WriteLine("Good luck!");
Console.ReadLine();
