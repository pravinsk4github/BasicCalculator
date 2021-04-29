using Calculator.Lib.Abstracts;

namespace Calculator.Lib.Commands
{
    public class DivideCommand : IOperationCommand
    {
        private readonly IMathMaker _mathMaker;
        public double Operand1 { private get; set; }
        public double Operand2 { private get; set; }

        public DivideCommand(IMathMaker mathMaker)
        {
            _mathMaker = mathMaker;
        }

        public double Execute()
        {
            return _mathMaker.Divide(Operand1, Operand2);
        }
    }
}
