namespace Calculator.Lib.Abstracts
{
    public interface ICalculator
    {
        double Invoke(IOperationCommand mathOperator);
    }
}