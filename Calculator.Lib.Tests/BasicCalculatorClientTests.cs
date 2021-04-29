using Calculator.Lib.Clients;
using NUnit.Framework;
using Calculator.Lib.Abstracts;
using System;
using Calculator.Lib.Constants;
using Calculator.Lib.Commands;
using Calculator.Lib.Receivers;
using Calculator.Lib.Invokers;

namespace Calculator.Lib.Tests
{
    public class BasicCalculatorClientTests
    {
        private BasicCalculatorClient _subject;
        private ICalculator _calculator;
        private Func<OperationTypes, IOperationCommand> _func;
        
        [SetUp]
        public void Setup()
        {
            _func = GetOperationCommand;
            _calculator = new BasicCalculator();
            _subject = new BasicCalculatorClient(_func, _calculator);
        }

        [TestCase("Add",10,2, 12)]
        [TestCase("+", 10, 2, 12)]
        [TestCase("Multiply", 10, 2, 20)]
        [TestCase("*", 10, 2, 20)]
        [TestCase("Substract", 10, 2, 8)]
        [TestCase("-", 10, 2, 8)]
        [TestCase("Divide", 10, 2, 5)]
        [TestCase("/", 10, 2, 5)]
        public void Calculate_PassedTwoOperands_ReturnsCorrectResult
            (string op, double operand1, double operand2, double expectedResult)
        {
            var result = _subject.Calculate(op, operand1, operand2);

            Assert.AreEqual(result, expectedResult);
        }

        [TestCase("//", 10, 2, 10)]
        [TestCase("Div", 10, 2, 10)]
        public void Calculate_PassedInvalidOprtion_ReturnsFirstOprandValueAsResult
            (string op, double operand1, double operand2, double expectedResult)
        {
            var result = _subject.Calculate(op, operand1, operand2);

            Assert.AreEqual(result, expectedResult);
        }

        private IOperationCommand GetOperationCommand(OperationTypes type)
        {
            switch (type)
            {
                case OperationTypes.ADD:
                    return new AddCommand(new BasicMathMaker());
                case OperationTypes.SUBSTRACT:
                    return new SubstractCommand(new BasicMathMaker());
                case OperationTypes.MULTIPLY:
                    return new MultiplyCommand(new BasicMathMaker());
                case OperationTypes.DIVIDE:
                    return new DivideCommand(new BasicMathMaker());
                default:
                    return null;
            }            
        }        
    }
}