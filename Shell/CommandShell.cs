using RAT.Utils;
using static RAT.Menu.Menu;

namespace RAT.Shell;

static class Shell
{
    private static readonly Dictionary<string, Action<string[]>> _commands = [];

    internal static void InitializeCommands()
    {
        Console.WriteLine("[*] Initializing shell commands...");
        // Базовые команды
        _commands["help"] = (args) => ShowHelp();
        _commands["menu"] = (args) => OpenMenu();
        _commands["clear"] = (args) => Console.Clear();
        _commands["cls"] = (args) => Console.Clear();
        _commands["exit"] = (args) => Environment.Exit(0);
        _commands["quit"] = (args) => Environment.Exit(0);

        // Команда machine
        _commands["machine"] = HandleMachineCommand;
        _commands["m"] = HandleMachineCommand;

        // Команда config
        _commands["config"] = HandleConfigCommand;
        _commands["cfg"] = HandleConfigCommand;
        Console.WriteLine("[+] Initializing completed");
    }

    internal static void TurnShell()
    {
        while (true)
        {
            Console.Write($"[{UtilsCollection.userName}@{UtilsCollection.machineName}]$ ");
            string? input = Console.ReadLine()?.Trim();

            if (string.IsNullOrEmpty(input))
            {
                continue;
            }

            ParseEndExecute(input);
        }
    }

    private static void ParseEndExecute(string input)
    {
        var args = input.Split(' ');
        string command = args[0].ToLower();
        var commandArgs = args.Skip(1).ToArray();
        if (_commands.TryGetValue(command, out Action<string[]>? value))
        {
            try
            {
                value(commandArgs);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error executing command: {ex.Message}");
            }
        }
        else
        {
            Console.WriteLine(
                $"Unknown command: {command}. Type 'help' for seeing available commands"
            );
        }
    }

    private static void OpenMenu()
    {
        MainMenuLoop();
    }

    private static void HandleMachineCommand(string[] args)
    {
        if (args.Length < 2)
        {
            Console.WriteLine("Command [machine] requires an option. Use --help");
            return;
        }

        string option = args[0].ToLower();

        switch (option)
        {
            case "--list":
            case "-l":
                Console.WriteLine("List of machines...");
                break;
            case "--info":
            case "-i":
                if (args.Length < 2)
                    Console.WriteLine("Usage: machine --info <id1, id2,...>");
                else
                    Console.WriteLine("Information about machine...");
                break;
            case "--rename":
            case "-rn":
                if (args.Length < 3)
                    Console.WriteLine("Usage: machine --rename <id|name> <new_name>");
                else
                    Console.WriteLine("Rename machine...");
                break;
            case "--delete":
            case "-d":
                if (args.Length < 2)
                    Console.WriteLine("Usage: machine --delete <id|name>");
                else if (!UtilsCollection.isAdmin)
                    Console.WriteLine("[!] Error: Admin right required to delete machine");
                else
                    Console.WriteLine("Deleting machine...");
                break;
            case "--open":
            case "-o":
                if (args.Length < 2)
                    Console.WriteLine("Usage: machine --open <id|name>");
                else
                    Console.WriteLine("Opening machine...");
                break;
            case "--ping":
            case "-p":
                if (args.Length < 2)
                    Console.WriteLine("Usage: machine --ping <all|id1,id2,...>");
                else
                    Console.WriteLine("Pinging machines...");
                break;
            case "--help":
            case "-h":
                ShowMachineHelp();
                break;
            default:
                Console.WriteLine(
                    $"Unknown option: {option}. Use --help to see available options."
                );
                break;
        }
    }

    private static void HandleConfigCommand(string[] args)
    {
        if (args.Length != 1)
        {
            Console.WriteLine("Command [config] requires an option. Use --help");
            return;
        }

        string option = args[0].ToLower();

        switch (option)
        {
            case "--re-generate":
            case "-rg":
                if (!UtilsCollection.isAdmin)
                    Console.WriteLine("[!] Error: Admin rights required to regenerate config");
                else
                    Console.WriteLine("Regenerating config...");
                break;
            case "--change-path":
            case "-p":
                if (args.Length < 2)
                    Console.WriteLine("Usage: config --change-path <PATH>");
                else
                    Console.WriteLine("Changing path...");
                break;
            case "--how-to-use":

            case "--help":
            case "-h":
                ShowConfigHelp();
                break;
            default:
                Console.WriteLine(
                    $"Unknown option: {option}. Use --help to see available options."
                );
                break;
        }
    }

    private static void ShowHelp()
    {
        string help =
            @"
Shell usage: <command> [options]

Available commands:

  help                          Show this help message
  menu                          Open main menu
  clear / cls                   Clear terminal
  exit / quit                   Close program

  machine [options]             Manage controlled machines
    --list, -l                    List all controlled machines
    --info, -i <ids>              Show info about specific machines
    --rename, -rn <id> <name>     Rename a machine
    --delete, -d <id>             Delete a machine (admin only)
    --open, -o <id>               Open machine controller
    --ping, -p <all|ids>          Ping machines

  config [options]              Manage utility config
    --re-generate, -rg            Regenerate config (admin only)
    --change-path, -p <PATH>      Change config file path
    --how-to-use, -htu            Shows all properties and values

Examples:
  machine --list
  machine --info 001,002,003
  machine --rename 001 home-pc
  machine --ping all
  config --change-path ./config.json
";
        Console.WriteLine(help);
    }

    private static void ShowMachineHelp()
    {
        Console.WriteLine(
            @"
machine command options:
  --list, -l                   List all controlled machines
  --info, -i <ids>             Show info about specific machines
  --rename, -rn <id> <name>    Rename a machine
  --delete, -d <id>            Delete a machine (admin only)
  --open, -o <id>              Open machine controller
  --ping, -p <all|ids>         Ping machines
"
        );
    }

    private static void ShowConfigHelp()
    {
        Console.WriteLine(
            @"
config command options:
  --re-generate, -rg            Regenerate config (admin only)
  --change-path, -p <PATH>      Change config file path
  --how-to-use, -htu            Shows all properties and values 
"
        );
    }
}
