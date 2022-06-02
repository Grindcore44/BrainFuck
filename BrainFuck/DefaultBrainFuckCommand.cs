using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainFuck
{
    public class DefaultBrainFuckCommand : ICommand
    {
        private readonly IInputOutput _inputOutput;

        public DefaultBrainFuckCommand(IInputOutput inputOutput)
        {
            _inputOutput = inputOutput;
        }
        public void Execute()
        {
            Console.Clear();

            Repository BrainFuckCode = new Repository();
            var brainFuckFunction = new BrainFuckFunction(BrainFuckCode, _inputOutput);
            DataOperations dataOperations = new DataOperations(brainFuckFunction);
            dataOperations.EnumСodeBrainFuck(BrainFuckCode.Program);

            Console.WriteLine("\nНажмите любую клавишу для возврата в меню");
            Console.ReadKey(true);
        }
       
    }
}

