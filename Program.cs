using RAT.Modules;
using static RAT.Menu.Menu;
using static RAT.Shell.Shell;
using static RAT.Utils.UtilsCollection;

// var configManager = new ConfigManager();
// var menu = new MenuRenderer();
// var shell = new CommandShell();
// var isInMenuMode = true;
// var connectedMachines = new List<MachineInfo>();

ShowBanner();
CheckSystem();

await ModuleManager.InitializeModules();
await Task.Delay(1000);
InitializeCommands();

Console.Write("Continue to start main menu? [Y/n] ");
string? input = Console.ReadLine();
bool doesContinue = true;
while (doesContinue)
    if (input == "n")
    {
        Console.WriteLine("[+] See ya later!");
        Console.ReadKey();
        return 0;
    }
    else if (input == "Y" || input == "y" || string.IsNullOrEmpty(input))
    {
        Console.WriteLine("[*] Starting menu...");
        await Task.Delay(500);
        await MainMenuLoop();
    }
    else
    {
        Console.Write("[!] Unexpected value. Choose [Y/n] ");
        input = Console.ReadLine();
    }

return 0;
