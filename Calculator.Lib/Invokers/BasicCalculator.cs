using Calculator.Lib.Abstracts;

namespace Calculator.Lib.Invokers
{
    public class BasicCalculator : ICalculator
    {
        public double Invoke(IOperationCommand mathOperator)
        {
            return mathOperator.Execute();
        }
    }
}