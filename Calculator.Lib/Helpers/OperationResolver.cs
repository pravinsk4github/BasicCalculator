using Calculator.Lib.Constants;

namespace Calculator.Lib.Helpers
{
    public class OperationResolver
    {
        public static string Resolve(string input)
        {
            switch (input.ToUpper())
            {
                case "+":
                case Operations.ADD:
                    return Operations.ADD;
                case "-":
                case Operations.SUBSTRACT:
                    return Operations.SUBSTRACT;
                case "*":
                case Operations.MULTIPLY:
                    return Operations.MULTIPLY;
                case "/":
                case Operations.DIVIDE:
                    return Operations.DIVIDE;
            }
            return string.Empty;
        }
    }
}
