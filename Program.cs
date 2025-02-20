Random random = new Random();
Console.CursorVisible = false;
int height = Console.WindowHeight - 1;
int width = Console.WindowWidth - 5;
bool shouldExit = false;
bool[] eaten = new bool[] { false, false, false, false, false };

// Console position of the player
int playerX = 0;
int playerY = 0;

// Console position of the food
int foodX = 0;
int foodY = 0;

// Available player and food strings
string[] states = { "('-')", "(^-^)", "(X_X)" };
string[] foods = { "@@@@@", "$$$$$", "#####" };

// Current player string displayed in the Console
string player = states[0];

// Index of the current food
int food = 0;

InitializeGame();
while (!shouldExit)
{
    if (TerminalResized())
    {
        Console.Clear();
        Console.WriteLine("Console was resized. Program exiting.");
        shouldExit = true;
        break;
    }
    else
    {
        Move();
        if (GotFood())
        {
            ChangePlayer();
            FreezePlayer();
            ShowFood();
        }
    }
}

// Returns true if the Terminal was resized 
bool TerminalResized()
{
    return height != Console.WindowHeight - 1 || width != Console.WindowWidth - 5;
}

// Displays random food at a random location
void ShowFood()
{
    // Update food to a random index
    food = random.Next(0, foods.Length);

    // Update food position to a random location
    foodX = random.Next(0, width - player.Length);
    foodY = random.Next(0, height - 1);

    // Display the food at the location
    Console.SetCursorPosition(foodX, foodY);
    Console.Write(foods[food]);
}

// Changes the player to match the food consumed
void ChangePlayer()
{
    player = states[food];
    Console.SetCursorPosition(playerX, playerY);
    Console.Write(player);
}

// Temporarily stops the player from moving
void FreezePlayer()
{
    if (player == "(X_X)")
    {
        System.Threading.Thread.Sleep(1000);
        player = states[0];
    }
}


bool GotFood()
{
    if (playerY == foodY)
    {
        if (playerX - foodX >= 0)
        {
            for (int pos = playerX - foodX; pos < 5; pos++)
            {
                eaten[pos] = true;
            }
        }
        else if (playerX + 4 - foodX >= 0 && playerX + 4 - foodX < 5)
        {
            for (int pos = playerX + 4 - foodX; pos >= 0; pos--)
            {
                eaten[pos] = true;
            }
        }

    }
    bool gotten = true;
    foreach (bool x in eaten)
    {
        if (!x)
        {
            gotten = false;
        }
    }
    if (gotten)
    {
        for (int i = 0; i < 5; i ++)
        {
            eaten[i] = false;
        }
    }
    return gotten;
}

// Reads directional input from the Console and moves the player
void Move()
{
    int lastX = playerX;
    int lastY = playerY;
    int playerSpeed = 1;
    if (player == "(^-^)")
    {
        playerSpeed = 3;
    }

    switch (Console.ReadKey(true).Key)
    {
        case ConsoleKey.UpArrow:
            playerY--;
            break;
        case ConsoleKey.DownArrow:
            playerY++;
            break;
        case ConsoleKey.LeftArrow:
            playerX -= playerSpeed;
            break;
        case ConsoleKey.RightArrow:
            playerX += playerSpeed;
            break;
        default:
            shouldExit = true;
            Console.Clear();
            break;

    }

    // Clear the characters at the previous position
    Console.SetCursorPosition(lastX, lastY);
    for (int i = 0; i < player.Length; i++)
    {
        Console.Write(" ");
    }

    // Keep player position within the bounds of the Terminal window
    playerX = (playerX < 0) ? 0 : (playerX >= width ? width : playerX);
    playerY = (playerY < 0) ? 0 : (playerY >= height ? height : playerY);

    // Draw the player at the new location
    Console.SetCursorPosition(playerX, playerY);
    Console.Write(player);
}

// Clears the console, displays the food and player
void InitializeGame()
{
    Console.Clear();
    ShowFood();
    Console.SetCursorPosition(0, 0);
    Console.Write(player);
}