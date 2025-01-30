// Code sample 1
bool flag = true;
int value = 10;

if (flag)
{
    value += 10;
    Console.WriteLine($"Inside the code block: {value}");
}

Console.WriteLine($"Outside the code block: {value}");