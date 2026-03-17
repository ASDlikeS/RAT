using System.Text.RegularExpressions;
using RAT.Utils;

namespace RAT.Shell;

static class Shell
{
    private static bool isShellOpened = true;
    private static Dictionary<string, Action<string[]>> _commands = [];

    static Shell() { }

    private static void InitializeCommands()
    {
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
    }

    internal static void TurnShell()
    {
        while (isShellOpened)
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
        var args = ParseArgument(input);
        if (args.Count == 0)
            return;

        string command = args[0].ToLower();
        var commandArgs = args.Skip(1).ToArray();

        if (_commands.ContainsKey(command))
        {
            try
            {
                _commands[command](commandArgs);
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

    private static List<string> ParseArgument(string command)
    {
        var result = new List<string>();
        var regex = new Regex(@"[\""].+?[\""]|[^ ]+");

        foreach (Match match in regex.Matches(command))
        {
            result.Add(match.Value.Trim('"'));
        }

        return result;
    }

    private static void HandleMachineCommand(string[] args)
    {
        if (args.Length != 1)
        {
            Console.WriteLine("Command machine must have only 1 param");
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
  --re-generate, -rg            Regenerate config with defaults (admin only)
  --change-path, -p <PATH>      Change config file path
"
        );
    }
}
