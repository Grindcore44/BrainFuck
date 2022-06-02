namespace BrainFuck;

public class BrainFuckCodeFromUser : ICommand
{
    private readonly IInputOutput _inputOutput;

    public BrainFuckCodeFromUser(IInputOutput inputOutput)
    {
        _inputOutput = inputOutput;
    }
    public void Execute()
    {
        Console.Clear();

        Repository BrainFuckCode = new Repository();
        PerformanceCheck performanceCheck = new PerformanceCheck();

        var brainFuckFunction = new BrainFuckFunction(BrainFuckCode, _inputOutput);
        DataOperations dataOperations = new DataOperations(brainFuckFunction);



        while (performanceCheck.Performance == false)
        {
            _inputOutput.OutputConsole("Введите код для реализации:");
            BrainFuckCode.Program = _inputOutput.GetStringUser();
            performanceCheck.CheckBrackets(BrainFuckCode.Program);

        }

        dataOperations.EnumСodeBrainFuck(BrainFuckCode.Program);

        Console.WriteLine("\nНажмите любую клавишу для возврата в меню");
        Console.ReadKey(true);
    }
}
