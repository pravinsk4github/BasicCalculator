using Calculator.Lib.Abstracts;
using Calculator.Lib.Clients;
using Calculator.Lib.Commands;
using Calculator.Lib.Constants;
using Calculator.Lib.Invokers;
using Calculator.Lib.Receivers;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Calculator.Lib
{
    public static partial class Extensions
    {
        public static void RegisterInternalServices(this IServiceCollection services)
        {
            services.AddSingleton<AddCommand>();
            services.AddSingleton<SubstractCommand>();
            services.AddSingleton<MultiplyCommand>();
            services.AddSingleton<DivideCommand>();
            services.AddSingleton<IMathMaker, BasicMathMaker>();
            services.AddSingleton<ICalculatorClient, BasicCalculatorClient>();
            services.AddSingleton<ICalculator, BasicCalculator>();

            services.AddTransient<Func<OperationTypes, IOperationCommand>>(serviceProvider => key =>
            {
                switch (key)
                {
                    case OperationTypes.ADD:
                        return serviceProvider.GetService<AddCommand>();
                    case OperationTypes.SUBSTRACT:
                        return serviceProvider.GetService<SubstractCommand>();
                    case OperationTypes.MULTIPLY:
                        return serviceProvider.GetService<MultiplyCommand>();
                    case OperationTypes.DIVIDE:
                        return serviceProvider.GetService<DivideCommand>();
                    default:
                        return null;
                }
            });
        }

        public static IOperationCommand GetMathOperator(Func<OperationTypes, IOperationCommand> resolver, string op)
        {
            var id = (OperationTypes)Enum.Parse(typeof(OperationTypes), op.ToUpper(), true);
            return resolver(id);
        }
    }   
}
