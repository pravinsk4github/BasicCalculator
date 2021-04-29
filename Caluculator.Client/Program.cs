using Calculator.Client;
using Calculator.Lib;
using Calculator.Lib.Abstracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Caluculator.Client
{
    class Program
    {
		private static IServiceProvider _serviceProvider;
        private static IConfiguration _configuration;

        private static Queue<Dictionary<string, double>> _queue;

        static async Task Main(string[] args)
        {
            string trigger = "APPLY";

            InitializeConfigurationBuilder();
            InitializeServiceCollection();

            ConsoleKey consoleKey;

            var feeder = new OperationsFileFeeder(_configuration);
            do
            {
                _queue = new();
                var contents = await feeder.GetContentsAsync();
                Console.WriteLine("Math operation from the file are :");

                foreach (var item in contents)
                {
                    Console.WriteLine($"Input - : {item}");
                    HandleInput(trigger, item);
                }
                Console.WriteLine("Please press enter to continue or escape to exit...");
                consoleKey = Console.ReadKey().Key;
            }
            while (consoleKey != ConsoleKey.Escape);

            Console.WriteLine();

            DisposeServiceCollection();
        }

        private static void HandleInput(string trigger, string input)
        {
            input = input.Trim();
            if (input.Length >= 2)
            {
                var splits = input.Split(' ');
                string op = splits[0].Trim();

                double.TryParse(splits[1].Trim(), out double num1);

                if (op.ToUpper() == trigger)
                {
                    InvokeCalculator(num1);
                }
                else
                {
                    Dictionary<string, double> data = new()
                    {
                        { op, num1 }
                    };
                    _queue.Enqueue(data);
                }                
            }
        }

        private static void InvokeCalculator(double num)
        {
            var client = _serviceProvider.GetRequiredService<ICalculatorClient>();
            var result = num;
            foreach (var item in _queue)
            {
                foreach (var key in item.Keys)
                {
                    result = client.Calculate(key, result, item[key]);
                }
            }
            Console.WriteLine($"Result - : {result}");
        }

        private static void InitializeServiceCollection()
        {
            var services = new ServiceCollection();
            services.AddSingleton<IConfiguration>(_configuration);
            services.RegisterInternalServices();
            _serviceProvider = services.BuildServiceProvider(true);
        }

        private static void InitializeConfigurationBuilder()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            _configuration = builder.Build();           
        }

        private static void DisposeServiceCollection()
        {
            if (_serviceProvider == null)
                return;
            
            if (_serviceProvider is IDisposable)
                ((IDisposable)_serviceProvider).Dispose();
        }
    }
}
