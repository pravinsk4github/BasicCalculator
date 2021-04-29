using Calculator.Lib.Abstracts;

namespace Calculator.Lib.Receivers
{
    public class BasicMathMaker : IMathMaker
    {
        public double Add(double num1, double num2)
        {
            return num1 + num2;
        }

        public double Substract(double num1, double num2)
        {
            return num1 - num2;
        }

        public double Multiply(double num1, double num2)
        {
            return num1 * num2;
        }

        public double Divide(double num1, double num2)
        {
            return num1 / num2;
        }
    }
}
