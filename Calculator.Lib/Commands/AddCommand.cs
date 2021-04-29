using Calculator.Lib.Abstracts;

namespace Calculator.Lib.Commands
{
    public class AddCommand : IOperationCommand
    {
        private readonly IMathMaker _mathMaker;
        public double Operand1 { private get; set; }
        public double Operand2 { private get; set; }

        public AddCommand(IMathMaker mathMaker)
        {
            _mathMaker = mathMaker;
        }

        public double Execute()
        {
            return _mathMaker.Add(Operand1, Operand2);
        }
    }
}
