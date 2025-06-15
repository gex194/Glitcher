using Glitcher.Services;

namespace Glitcher;

class Program
{
    static void Main(string[] args)
    {
        Console.Title = "GL1TCH3R";
        Console.WindowWidth = 900;
        var _imageGlitcherService = new ImageGlitchService();
        var messages = new List<string>
        {
            "//_connecting_to_the_main_hub...",
            "//_initializing_GL1TCH3R_protocol...",
            "//_parsing_welcome_message...",
        };

        var asciiArt = new List<string>
        {
"   ░▒▓██████▓▒░░▒▓█▓▒░      ░▒▓█▓▒░▒▓████████▓▒░▒▓██████▓▒░░▒▓█▓▒░░▒▓█▓▒░▒▓████████▓▒░▒▓███████▓▒░  ",
"  ░▒▓█▓▒░░▒▓█▓▒░▒▓█▓▒░      ░▒▓█▓▒░  ░▒▓█▓▒░  ░▒▓█▓▒░░▒▓█▓▒░▒▓█▓▒░░▒▓█▓▒░▒▓█▓▒░      ░▒▓█▓▒░░▒▓█▓▒░ ",
"  ░▒▓█▓▒░      ░▒▓█▓▒░      ░▒▓█▓▒░  ░▒▓█▓▒░  ░▒▓█▓▒░      ░▒▓█▓▒░░▒▓█▓▒░▒▓█▓▒░      ░▒▓█▓▒░░▒▓█▓▒░ ",
"  ░▒▓█▓▒▒▓███▓▒░▒▓█▓▒░      ░▒▓█▓▒░  ░▒▓█▓▒░  ░▒▓█▓▒░      ░▒▓████████▓▒░▒▓██████▓▒░ ░▒▓███████▓▒░  ",
"  ░▒▓█▓▒░░▒▓█▓▒░▒▓█▓▒░      ░▒▓█▓▒░  ░▒▓█▓▒░  ░▒▓█▓▒░      ░▒▓█▓▒░░▒▓█▓▒░▒▓█▓▒░      ░▒▓█▓▒░░▒▓█▓▒░ ",
"  ░▒▓█▓▒░░▒▓█▓▒░▒▓█▓▒░      ░▒▓█▓▒░  ░▒▓█▓▒░  ░▒▓█▓▒░░▒▓█▓▒░▒▓█▓▒░░▒▓█▓▒░▒▓█▓▒░      ░▒▓█▓▒░░▒▓█▓▒░ ",
"   ░▒▓██████▓▒░░▒▓████████▓▒░▒▓█▓▒░  ░▒▓█▓▒░   ░▒▓██████▓▒░░▒▓█▓▒░░▒▓█▓▒░▒▓████████▓▒░▒▓█▓▒░░▒▓█▓▒░ ",
            "ver. 1.0.0         by <_zest> (2025)",
            "__________________________________",
            "type /help for available commands"
        };
        for (int position = 0; position < messages.Count; position++)
        {
            ShowMessage(messages[position], position);
        }

        for (int position = 0; position < asciiArt.Count; position++)
        {
            ShowMessage(asciiArt[position], position, 1, 5);
        }

        var number = 1;
        while (true)
        {
            var input = Console.ReadLine();
            var subStrings = input?.Split(' ');
            if (subStrings != null && subStrings.Contains("-n"))
            {
                number = int.Parse(subStrings[^1]);
            }
            else
            {
                number = 1;
            }

            if (input == null)
            {
                continue;
            }

            if (input.Contains("/glitch"))
            {
                _imageGlitcherService.GlitchImage("input.jpg", "test_glitched.jpg", number);
                
            } 
            else if (input.Contains("/help"))
            {
                Console.WriteLine("Available commands:");
                Console.WriteLine("- /glitch <-n> <number> - glitchify an image, default number is 1");
                Console.WriteLine("- /quit -  exit program");
            }
            else if (input.Contains("/quit"))
            {
                break;
            }
            else
            {
                Console.WriteLine("ERROR: Unknown command");
            }
        }
    }

    private static void ShowMessage(string text, int consoleTopPosition = 0, int textSpeedMs = 30,
        int waitTimeMs = 1000)
    {
        for (int i = 0; i < text.Length; i++)
        {
            Console.SetCursorPosition(i, consoleTopPosition);
            Console.Write(text[i]);
            Thread.Sleep(textSpeedMs);
        }

        Console.WriteLine();
        Thread.Sleep(waitTimeMs);
    }
}