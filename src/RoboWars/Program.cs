using System;
using System.Runtime.Loader;
using System.Threading;
using System.Threading.Tasks;
using RoboWars.Infrastructure;
using StructureMap;

namespace RoboWars
{
    class Program
    {
        private readonly AutoResetEvent _closing = new AutoResetEvent(false);
        private AppService _service;
        private IContainer _container;

        private static async Task Main()
        {
            await new Program().RunAsync();
        }

        private async Task RunAsync()
        {
            AppDomain.CurrentDomain.UnhandledException += OnUnhandledException;
            AssemblyLoadContext.Default.Unloading += OnShutdown;
            Console.CancelKeyPress += OnCancelKeyPress;

            try
            {
                _container = new Container(cfg =>
                    cfg.AddRegistry(new AppRegistry())
                );

                _service = _container.GetInstance<AppService>();

                await _service.StartAsync();

                _closing.WaitOne();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error starting RoboWars:\n{0}", ex);
            }
        }

        private void OnShutdown(AssemblyLoadContext context)
        {
            try
            {
                _service?.StopAsync().GetAwaiter().GetResult();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error shutting down RoboWars cleanly:\n{0}", ex);
            }
        }

        private void OnCancelKeyPress(object sender, ConsoleCancelEventArgs args)
        {
            args.Cancel = true;
            _closing.Set();
        }

        private void OnUnhandledException(object sender, UnhandledExceptionEventArgs ex)
        {
            Console.WriteLine(ex.ExceptionObject.ToString());
            Environment.Exit(1);
        }
    }
}
