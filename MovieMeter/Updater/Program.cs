using System;
using System.Windows;
using SimpleInjector;
using Updater;
using Updater.DependencyInjection;

static class Program
{
    [STAThread]
    static void Main()
    {
        var container = Bootstrap();

        RunApplication(container);
    }

    private static Container Bootstrap()
    {
        var t = Guid.NewGuid().ToString();
        var container = new Container();

        container.RegisterDependancies();

        container.Register<MainWindow>();
        container.Register<MainWindowViewModel>();

        container.Verify();

        return container;
    }

    private static void RunApplication(Container container)
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
