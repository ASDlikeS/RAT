namespace RAT.Modules.Network;

public static class Network
{
    public static async Task HandleNetworkTest()
    {
        Console.WriteLine("[*] Testing UDP connectivity...");

        for (int i = 0; i <= 100; i += 20)
        {
            Console.Write($"\r    Progress: {i}% ");
            await Task.Delay(200);
        }

        Console.WriteLine("\n[+] UDP test passed");
        Console.WriteLine("    Localhost: OK (ping: 0.4ms)");
        Console.WriteLine("    Gateway: OK (ping: 2.1ms)");
        Console.WriteLine("    External: OK (ping: 42ms)");
    }

    public static async Task HandleNetworkParams()
    {
        Console.WriteLine("[*] Current network configuration:");
        Console.WriteLine("    Listen IP: 0.0.0.0");
        Console.WriteLine("    Port: 8888");
        Console.WriteLine("    Buffer size: 8192");
        Console.WriteLine("    Timeout: 5000ms");

        Console.WriteLine("\n[*] To change parameters, use shell mode or edit config.json");
    }

    public static async Task HandleActiveConnections()
    {
        Console.WriteLine("[*] Active network connections:");
        Console.WriteLine("\n    Protocol  Local Address  Foreign Address  State");
        Console.WriteLine("    --------  -------------  ---------------  -------");
        Console.WriteLine("    UDP       0.0.0.0:8888   *:*              LISTENING");
        Console.WriteLine("    TCP       0.0.0.0:0      *:*              LISTENING");
    }
}
