using Raylib_cs;
using System.Numerics;

public class Program
{
    public static void Main()
    {
        bool isTypingNumber1 = true;
        bool isTypingNumber2 = true;
        const int screenWidth = 400;
        const int screenHeight = 300;

        Raylib.InitWindow(screenWidth, screenHeight, "Calculator");

        string number1Text = "";
        string number2Text = "";
        string resultText = "";

        Rectangle number1Box = new Rectangle(100, 50, 200, 30);
        Rectangle clearButton = new Rectangle(300, 130, 40, 40);
        Rectangle number2Box = new Rectangle(100, 90, 200, 30);
        Rectangle addButton = new Rectangle(100, 130, 40, 40);
        Rectangle subtractButton = new Rectangle(150, 130, 40, 40);
        Rectangle multiplyButton = new Rectangle(200, 130, 40, 40);
        Rectangle divideButton = new Rectangle(250, 130, 40, 40);

        bool isFirstDigitEntered = false;

        while (!Raylib.WindowShouldClose())
        {
            // Input thingy
            if (Raylib.IsMouseButtonPressed(MouseButton.MOUSE_LEFT_BUTTON))
            {
                Vector2 mousePosition = Raylib.GetMousePosition();

                if (Raylib.CheckCollisionPointRec(mousePosition, number1Box))
                {
                    isTypingNumber1 = true;
                    isTypingNumber2 = false;
                }
                else if (Raylib.CheckCollisionPointRec(mousePosition, number2Box))
                {
                    isTypingNumber1 = false;
                    isTypingNumber2 = true;
                }
                else if (Raylib.CheckCollisionPointRec(mousePosition, addButton))
                {
                    // calculate addition
                    if (float.TryParse(number1Text, out float num1) && float.TryParse(number2Text, out float num2))
                    {
                        float result = num1 + num2;
                        resultText = result.ToString();
                    }
                }
                else if (Raylib.CheckCollisionPointRec(mousePosition, subtractButton))
                {
                    // calculate subtraction
                    if (float.TryParse(number1Text, out float num1) && float.TryParse(number2Text, out float num2))
                    {
                        float result = num1 - num2;
                        resultText = result.ToString();
                    }
                }
                else if (Raylib.CheckCollisionPointRec(mousePosition, multiplyButton))
                {
                    // Perform multiplication calculation
                    if (float.TryParse(number1Text, out float num1) && float.TryParse(number2Text, out float num2))
                    {
                        float result = num1 * num2;
                        resultText = result.ToString();
                    }
                }
                else if (Raylib.CheckCollisionPointRec(mousePosition, divideButton))
                {
                    // Perform division calculation
                    if (float.TryParse(number1Text, out float num1) && float.TryParse(number2Text, out float num2))
                    {
                        if (num2 != 0)
                        {
                            float result = num1 / num2;
                            resultText = result.ToString();
                        }
                        else
                        {
                            resultText = "Error: Division by zero";
                        }
                    }
                }
                else if (Raylib.CheckCollisionPointRec(mousePosition, clearButton))
                {
                        number1Text = "";
                        number2Text = "";
                        resultText = "";
            }

            }

            // refer to text input
            if (isTypingNumber1)
            {
                HandleTextInput(ref number1Text);
            }
            else if (isTypingNumber2)
            {
                HandleTextInput(ref number2Text);
            }

            // 
            // Keyboard input
if (Raylib.IsKeyPressed(KeyboardKey.KEY_BACKSPACE))
{
    if (isTypingNumber2 && number2Text.Length > 0)
    {
        number2Text = number2Text.Substring(0, number2Text.Length - 1);
    }
    else if (isTypingNumber1 && number1Text.Length > 0)
    {
        number1Text = number1Text.Substring(0, number1Text.Length - 1);
        isFirstDigitEntered = number1Text.Length > 0;
    }
}


else if (Raylib.IsKeyPressed(KeyboardKey.KEY_ENTER))
{
    if (float.TryParse(number1Text, out float num1) && float.TryParse(number2Text, out float num2))
    {
        float result = num1 + num2;
        resultText = result.ToString();
    }
}
else if (Raylib.IsKeyPressed(KeyboardKey.KEY_ESCAPE))
{
    Raylib.CloseWindow();
}
else if (Raylib.IsKeyPressed(KeyboardKey.KEY_ZERO) ||
         Raylib.IsKeyPressed(KeyboardKey.KEY_ONE) ||
         Raylib.IsKeyPressed(KeyboardKey.KEY_TWO) ||
         Raylib.IsKeyPressed(KeyboardKey.KEY_THREE) ||
         Raylib.IsKeyPressed(KeyboardKey.KEY_FOUR) ||
         Raylib.IsKeyPressed(KeyboardKey.KEY_FIVE) ||
         Raylib.IsKeyPressed(KeyboardKey.KEY_SIX) ||
         Raylib.IsKeyPressed(KeyboardKey.KEY_SEVEN) ||
         Raylib.IsKeyPressed(KeyboardKey.KEY_EIGHT) ||
         Raylib.IsKeyPressed(KeyboardKey.KEY_NINE))
{
    int key = (int)Raylib.GetCharPressed();

    if (key >= 48 && key <= 57) // ASCII range for digits 0-9
    {
        char keyChar = (char)key;

        if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT_SHIFT) || Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT_SHIFT))
        {
            number2Text += keyChar;
        }
        else
        {
            if (!isFirstDigitEntered && keyChar == '0')
            {
                // Ignore leading zeros
                continue;
            }
            number1Text += keyChar;
            isFirstDigitEntered = true;
        }
    }
}


            // Draw background
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.RAYWHITE);

            // Draw number1Box
            if (Raylib.CheckCollisionPointRec(Raylib.GetMousePosition(), number1Box))
            {
                Raylib.DrawRectangleLinesEx(number1Box, 2, Color.RED);
            }
            else
            {
                Raylib.DrawRectangleLinesEx(number1Box, 2, Color.BLACK);
            }

            // Draw number2Box
            if (Raylib.CheckCollisionPointRec(Raylib.GetMousePosition(), number2Box))
            {
                Raylib.DrawRectangleLinesEx(number2Box, 2, Color.RED);
            }
            else
            {
                Raylib.DrawRectangleLinesEx(number2Box, 2, Color.BLACK);
            }

            if (Raylib.CheckCollisionPointRec(Raylib.GetMousePosition(), addButton))
{
    Raylib.DrawRectangleLinesEx(addButton, 2, Color.RED);
}
else
{
    Raylib.DrawRectangleLinesEx(addButton, 2, Color.BLACK);
}

// Draw subtractButton
if (Raylib.CheckCollisionPointRec(Raylib.GetMousePosition(), subtractButton))
{
    Raylib.DrawRectangleLinesEx(subtractButton, 2, Color.RED);
}
else
{
    Raylib.DrawRectangleLinesEx(subtractButton, 2, Color.BLACK);
}

// Draw multiplyButton
if (Raylib.CheckCollisionPointRec(Raylib.GetMousePosition(), multiplyButton))
{
    Raylib.DrawRectangleLinesEx(multiplyButton, 2, Color.RED);
}
else
{
    Raylib.DrawRectangleLinesEx(multiplyButton, 2, Color.BLACK);
}

// Draw divideButton
if (Raylib.CheckCollisionPointRec(Raylib.GetMousePosition(), divideButton))
{
    Raylib.DrawRectangleLinesEx(divideButton, 2, Color.RED);
}
else
{
    Raylib.DrawRectangleLinesEx(divideButton, 2, Color.BLACK);
}

// Draw clearButton
if (Raylib.CheckCollisionPointRec(Raylib.GetMousePosition(), clearButton))
{
    Raylib.DrawRectangleLinesEx(clearButton, 2, Color.RED);
}
else
{
    Raylib.DrawRectangleLinesEx(clearButton, 2, Color.BLACK);
}

            Raylib.DrawText("Number 1:", 100, 30, 20, Color.BLACK);
            Raylib.DrawText(number1Text, (int)number1Box.x + 5, (int)number1Box.y + 8, 20, Color.BLACK);

            Raylib.DrawText("Number 2:", 100, 70, 20, Color.BLACK);
            Raylib.DrawText(number2Text, (int)number2Box.x + 5, (int)number2Box.y + 8, 20, Color.BLACK);

            Raylib.DrawText("+", (int)addButton.x + 15, (int)addButton.y + 10, 20, Color.BLACK);

            Raylib.DrawText("-", (int)subtractButton.x + 15, (int)subtractButton.y + 10, 20, Color.BLACK);

            Raylib.DrawText("x", (int)multiplyButton.x + 15, (int)multiplyButton.y + 10, 20, Color.BLACK);

            Raylib.DrawText("/", (int)divideButton.x + 15, (int)divideButton.y + 10, 20, Color.BLACK);

            Raylib.DrawText("Result: " + resultText, 100, 200, 20, Color.BLACK);

            Raylib.DrawText("C", (int)clearButton.x + 15, (int)clearButton.y + 10, 20, Color.BLACK);


            Raylib.EndDrawing();
        }

        Raylib.CloseWindow();
    }

   
    static void HandleTextInput(ref string inputText)
    {
        int key = Raylib.GetCharPressed();

        if (key >= 32 && key <= 125)
        {
            char keyChar = (char)key;

            if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT_SHIFT) || Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT_SHIFT))
            {
                inputText += char.ToUpper(keyChar);
            }
            else
            {
                inputText += keyChar;
            }
        }
        else if (key == (int)KeyboardKey.KEY_BACKSPACE)
        {
            if (inputText.Length > 0)
            {
                inputText = inputText.Substring(0, inputText.Length - 1);
            }
        }
}



    }