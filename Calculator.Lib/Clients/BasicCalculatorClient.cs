using Calculator.Lib.Abstracts;
using Calculator.Lib.Constants;
using Calculator.Lib.Helpers;
using System;

namespace Calculator.Lib.Clients
{
    public class BasicCalculatorClient : ICalculatorClient
    {
        private readonly Func<OperationTypes, IOperationCommand> _resolver;
        private readonly ICalculator _calculator;

        public BasicCalculatorClient(Func<OperationTypes, IOperationCommand> resolver, ICalculator calculator)
        {
            _resolver = resolver;
            _calculator = calculator;
        }

        public double Calculate(string op, double num1, double num2)
        {
            string op1 = OperationResolver.Resolve(op);
            if (!string.IsNullOrEmpty(op1))
            {
                var command = Extensions.GetMathOperator(_resolver, op1);
                command.Operand1 = num1;
                command.Operand2 = num2;
                return _calculator.Invoke(command);
            }
            return num1;
        }        
    }
}