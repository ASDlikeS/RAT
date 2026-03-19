using static RAT.Shell.Shell;
using static RAT.Utils.UtilsCollection;

namespace RAT.Menu;

static class Menu
{
    static void ShowMenu()
    {
        Console.WriteLine(
            @"
╔════════════════════════════════════════════════════════════╗
║                         MAIN MENU                          ║
╠════════════════════════════════════════════════════════════╣
║                         NETWORK                            ║
╠════════════════════════════════════════════════════════════╣
║  1. Test the availability of sockets                       ║
║                                                            ║
╠════════════════════════════════════════════════════════════╣
║                         PAYLOAD                            ║
╠════════════════════════════════════════════════════════════╣
║  2. See or change Config.json                              ║
║  3. Generate payload                                       ║
╠════════════════════════════════════════════════════════════╣
║                         HANDLING                           ║
╠════════════════════════════════════════════════════════════╣
║  4. Management of controlled machines                      ║
║  9  Switch to SHELL mode                                   ║
║  0. Exit                                                   ║
╚════════════════════════════════════════════════════════════╝"
        );
    }

    internal static void MainMenuLoop()
    {
        bool running = true;

        while (running)
        {
            Console.Clear();
            ShowMenu();

            Console.WriteLine("\n[>] Select option (0-9): ");
            string? input = Console.ReadLine()?.Trim();

            if (string.IsNullOrEmpty(input))
            {
                ShowErrorMessage("Input can not be empty");
                continue;
            }

            if (!int.TryParse(input, out int option))
            {
                ShowErrorMessage("Invalid input. Please type a number.");
                continue;
            }

            if (option < 0 || option > 9)
            {
                ShowErrorMessage("Value must be between 0 and 9");
                continue;
            }

            switch (option)
            {
                case 0:
                    Console.WriteLine("[*] Quitting...");
                    running = false;
                    break;
                case 1:
                    Console.WriteLine("This command not available");
                    break;

                case 2:
                    Console.WriteLine("This command not available");
                    break;

                case 3:
                    Console.WriteLine("This command not available");
                    break;

                case 4:
                    Console.WriteLine("This command not available");
                    break;

                case 5:
                    Console.WriteLine("This command not available");
                    break;

                case 6:
                    Console.WriteLine("This command not available");
                    break;

                case 7:
                    Console.WriteLine("This command not available");
                    break;

                case 8:
                    Console.WriteLine("This command not available");
                    break;

                case 9:
                    TurnShell();
                    break;
            }
        }
    }
}
