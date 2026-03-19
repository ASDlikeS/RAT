using System;
using static RAT.Menu.Menu;

namespace RAT.Core;

internal static class Payload
{
    private static string _configPath = @$"C:\Users\{Environment.UserName}\RatToolKit.json";

    private static void ParseConfigParams()
    {
        if (!File.Exists(_configPath))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(
                $"File doesn't exist in directory {_configPath}, be sure if you change config path, you have to regenerate config there: config --re-generate | Or be sure, path is correct to reach him."
            );
            Console.ResetColor();
            return;
        }

        string[] config = File.ReadAllLines(_configPath);
        if(config.Length < 1)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(
                $"File doesn't exist in directory {_configPath}, be sure if you change config path, you have to regenerate config there: config --re-generate | Or be sure, path is correct to reach him."
            );
            Console.ResetColor();
            return;
        }

        
        
    }

    public static void GeneratePayload() { }
}
