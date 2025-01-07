using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PortfolioFunctions;

namespace PortfolioFunction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FunctionsDebugger.Enable();

            var host = new HostBuilder()
                .ConfigureFunctionsWorkerDefaults()
                .ConfigureServices(a => a.AddSingleton<ServiceBusContext>((s) => { return new ServiceBusContext(); }))
                .ConfigureServices(a => a.AddSingleton<LoremIpsumContext>())
                .Build();

            host.Run();
        }
    }
}
