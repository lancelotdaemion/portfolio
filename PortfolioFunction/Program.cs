using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

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
                .Build();

            host.Run();
        }
    }
}
