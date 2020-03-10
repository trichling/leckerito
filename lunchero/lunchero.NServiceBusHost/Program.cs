using System;
using System.Threading.Tasks;

namespace lunchero.NServiceBusHost
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var host = new EndpointHost();

            await host.Start();

            Console.WriteLine($"Endpoint {EndpointHost.EndpointName} is running. Press any key to shutdown.");
            Console.ReadLine();
            
            await host.Stop();
        }
    }
}


