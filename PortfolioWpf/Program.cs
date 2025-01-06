using System;
using System.ComponentModel;
using System.Windows;
using PortfolioWpf;
using PortfolioWpf.Data;
using PortfolioWpf.Services;
using PortfolioWpf.ViewModels;
using SimpleInjector;

static class Program
{
    [STAThread]
    static void Main()
    {
        var container = Bootstrap();

        // Any additional other configuration, e.g. of your desired MVVM toolkit.

        RunApplication(container);
    }

    private static SimpleInjector.Container Bootstrap()
    {
        // Create the container as usual.
        var container = new SimpleInjector.Container();

        container.Register<LoremIpsumContext>(Lifestyle.Singleton);

        // Register your types, for instance:
        container.Register<IDataService, DataService>(Lifestyle.Singleton);

        // Register your windows and view models:
        container.Register<MainWindow>();
        
        container.Register<LoremIpsomViewModel>();

        container.Verify();

        return container;
    }

    private static void RunApplication(SimpleInjector.Container container)
    {
        try
        {
            var app = new App();
            var mainWindow = container.GetInstance<MainWindow>();
            app.Run(mainWindow);
        }
        catch (Exception ex)
        {
            //Log the exception and exit
        }
    }
}