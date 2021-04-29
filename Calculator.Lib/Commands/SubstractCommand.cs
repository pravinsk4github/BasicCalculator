using Calculator.Lib.Abstracts;

namespace Calculator.Lib.Commands
{
    public class SubstractCommand : IOperationCommand
    {
        private readonly IMathMaker _mathMaker;

        public double Operand1 { private get; set; }
        public double Operand2 { private get; set; }

        public SubstractCommand(IMathMaker mathMaker)
        {
            _mathMaker = mathMaker;
        }

        public double Execute()
        {
            return _mathMaker.Substract(Operand1, Operand2);
        }
    }
}
