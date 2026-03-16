namespace RAT.Config;

public static class Config
{
    public static async Task HandleShowConfig()
    {
        Console.WriteLine("[*] Current payload configuration:");
        Console.WriteLine(
            @"
    ╔══════════════════════════════════╗
    ║         PAYLOAD CONFIG           ║
    ╠══════════════════════════════════╣
    ║  Network:                        ║
    ║    Listen IP: 0.0.0.0            ║
    ║    Port: 8888                    ║
    ║                                   ║
    ║  Modules:                         ║
    ║    Camera: ENABLED                ║
    ║    Screenshot: ENABLED            ║
    ║    Keylogger: DISABLED            ║
    ║    Shell: ENABLED                 ║
    ║                                   ║
    ║  Behavior:                        ║
    ║    Auto-start: DISABLED           ║
    ║    Hide console: ENABLED          ║
    ║    Max connections: 10            ║
    ╚══════════════════════════════════╝"
        );
    }

    public static async Task HandleEditConfig()
    {
        Console.WriteLine("[*] Opening config.json for editing...");
        await Task.Delay(1000);
        Console.WriteLine("[+] Config editor closed");
        Console.WriteLine("[*] Changes saved (simulated)");
    }
}
