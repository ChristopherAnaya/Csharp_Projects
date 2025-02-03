for (int x = 1; x <=100; x++)
{
    string finalMessage = $"{x}";
    if (x % 3 == 0) finalMessage += "Fizz";
    if (x % 5 == 0) finalMessage += "Buzz";
    Console.WriteLine(finalMessage);
}