namespace Calculator.Lib.Abstracts
{
    public interface IOperationCommand
    {
        double Operand1 { set; }
        double Operand2 { set; }
        double Execute();
    }
}
