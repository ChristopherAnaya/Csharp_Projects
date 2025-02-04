/* Console.WriteLine("Enter an integer value between 5 and 10");
int number = 0;
while (number < 5 || number > 10)
{
    string? answer = Console.ReadLine();
    bool convert = int.TryParse(answer, out number);
    if (!convert)
    {
        Console.WriteLine("Sorry, you entered an invalid number, please try again");
    }
    else if (number < 5 || number > 10)
    {
        Console.WriteLine($"You entered {number}. Please enter a number between 5 and 10.");
    }
    else
    {
        Console.WriteLine($"Your input value ({number}) has been accepted.");
    }
} */
/* Console.WriteLine("Enter your role name (Administrator, Manager, or User)");
bool accepted = false;
while (accepted == false)
{
    string? answer = Console.ReadLine().Trim().ToLower();
    if (answer != "administrator" && answer != "manager" && answer != "user")
    {
        Console.WriteLine(@$"The role name that you entered, ""{answer}"" is not valid. Enter your role name (Administrator, Manager, or User)");
    }
    else
    {
        Console.WriteLine($"Your input value ({answer}) has been accepted.");
        accepted = true;
    }
} */
string[] myStrings = new string[2] { "I like pizza. I like roast chicken. I like salad", "I like all three of the menu choices" };
int periodLocation;
