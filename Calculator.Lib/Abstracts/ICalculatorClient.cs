namespace Calculator.Lib.Abstracts
{
    public interface ICalculatorClient
    {
        double Calculate(string op, double num1, double num2);
    }
}
