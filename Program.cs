using RAT.Modules;
using static RAT.Menu.Menu;
using static RAT.Utils.UtilsCollection;

// var configManager = new ConfigManager();
// var menu = new MenuRenderer();
// var shell = new CommandShell();
// var isInMenuMode = true;
// var connectedMachines = new List<MachineInfo>();

ShowBanner();
CheckSystem();

await ModuleManager.InitializeModules();
await MainMenuLoop();
