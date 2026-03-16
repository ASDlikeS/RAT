using System.Runtime.InteropServices;
using System.Security.Principal;

namespace RAT.Utils;

public static class UtilsCollection
{
    public const string Version = "1.0.0";
    internal static string userName = Environment.UserName;
    internal static string machineName = Environment.MachineName;
    internal static bool isAdmin;

    public static void ShowBanner()
    {
        Console.WriteLine(
            $@"
    ╔═══════════════════════════════════════╗
    ║    Windows RAT - Professional Tool    ║
    ║           Version {Version, -14}      ║
    ║         Created by @AsdLikeS          ║
    ║  Github: https://github.com/ASDlikeS  ║
    ╚═══════════════════════════════════════╝
"
        );
    }

    public static void CheckSystem()
    {
        string OSName = RuntimeInformation.OSDescription;
        string arch = RuntimeInformation.OSArchitecture.ToString();
        string runtime = RuntimeInformation.RuntimeIdentifier;
        string directory = RuntimeEnvironment.GetRuntimeDirectory();

        Console.WriteLine($"[+] OS detected: {OSName} {arch}");
        Console.WriteLine($"[+] Current directory: {directory}");
        Console.WriteLine($"[+] Runtime id: {runtime}");
        Console.WriteLine($"[+] Machine name: {machineName}");
        Console.WriteLine($"[+] User name: {userName}");

        bool? probablyIsAdmin = IsRunningAsAdmin();
        if (probablyIsAdmin.HasValue)
        {
            Console.WriteLine(
                $"[+] Program executed with {(probablyIsAdmin.Value ? "ADMIN" : "USER")} rights"
            );
            isAdmin = probablyIsAdmin.Value;
        }
        else
            isAdmin = false;
    }

    private static bool? IsRunningAsAdmin()
    {
        try
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                using var identity = WindowsIdentity.GetCurrent();
                var principal = new WindowsPrincipal(identity);
                return principal.IsInRole(WindowsBuiltInRole.Administrator);
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                return Environment.UserName == "root"
                    || (Environment.GetEnvironmentVariable("SUDO_USER") != null);
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                return Environment.UserName == "root";
            }
            return false;
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"[!] Error checking admin rights: {ex.Message}");
            Console.ResetColor();

            return null;
        }
    }

    public static void ShowErrorMessage(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"\n[!] {message}");
        Console.ResetColor();
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }
}
