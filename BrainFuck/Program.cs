namespace BrainFuck;
public static class Program
{
    public static void Main() // Задание на дом:
                              // Реализовать новый пункт меню, где при его выборе просит у пользователя ввести в консоль программу на брэйнфаке и исполнить её.
    { 
        var exitToken = new ExitToken();
        var menuLines = new[] 
        {
         new MenuLine("1. Запустить стартовую программу", new DefaultBrainFuckCommand()),
         new MenuLine("2. Запустить свою программу", new BrainFuckCodeFromUser()),
         new MenuLine("3. Выйти", new ExitCommand(exitToken))
        };
        var menuIndex = 0;
        PrintMenu(menuLines, menuIndex);

        while (true)
        {
            var consoleKeyInfo = Console.ReadKey(true);
            if (consoleKeyInfo.Key == ConsoleKey.UpArrow)
            {
                menuIndex -= 1;
                menuIndex = menuIndex < 0 ? 0 : menuIndex; //? - если тру возвращай 0, если фолс возвращай меню индекс
            }
            else if (consoleKeyInfo.Key == ConsoleKey.DownArrow)
            {
                menuIndex += 1;
                menuIndex = menuIndex >= menuLines.Length ? menuLines.Length - 1 : menuIndex;
            }
            else if (consoleKeyInfo.Key == ConsoleKey.Enter)
            {
                var item = menuLines[menuIndex];
                item.Execute();
                if (exitToken.IsCanceled == false)
                {
                    Console.Clear();
                }
            }
            if (exitToken.IsCanceled)
            {
                return;
            }

            PrintMenu(menuLines, menuIndex);
        }

    }
    private static void PrintMenu(MenuLine [] menuLines, int menuIndex)
    {
        Console.SetCursorPosition(0, 0);

        var index = 0;
        foreach (var menuLine in menuLines)
        {
            if (index == menuIndex)
            {
                Console.Write(">");
            }
            else
            {
                Console.Write(" ");
            }

            Console.Write(menuLine.Name);
            Console.Write("\n");
            index += 1;
        }
    }
}

public class BrainFuckCodeFromUser : ICommand
{
    public void Execute()
    {
        Console.Clear();

        InputOutput inputOutput = new InputOutput(Console.In, Console.Out);
        Repository BrainFuckCode = new Repository();
        PerformanceCheck performanceCheck = new PerformanceCheck();

        var brainFuckFunction = new BrainFuckFunction(BrainFuckCode, new InputOutput(Console.In, Console.Out));
        DataOperations dataOperations = new DataOperations(brainFuckFunction);

       

        while (performanceCheck.Performance == false)
        {
            inputOutput.OutputConsole("Введите код для реализации:");
            BrainFuckCode.Program = inputOutput.GetStringUser();
            performanceCheck.CheckBrackets(BrainFuckCode.Program);
            
        }

        dataOperations.EnumСodeBrainFuck(BrainFuckCode.Program);

        Console.WriteLine("\nНажмите любую клавишу для возврата в меню");
        Console.ReadKey(true);
    }
}

public class PerformanceCheck
{
    public bool Performance { get; set; }

    public PerformanceCheck()
    {
        Performance = false;
    }

    public void CheckingFine()
    {
        Performance = true;
    }

    public void CheckBrackets(string brainFuckCode)
    {
        var openingBreakeds = '[';
        var closedBreakeds = ']';
        int countOpeningBreakeds = 0;
        int countClosedBreakeds = 0;

        for (int i = 0; i < brainFuckCode.Length; i++)
        {
            if (brainFuckCode[i] == openingBreakeds)
            {
                countOpeningBreakeds = countOpeningBreakeds + 1;
            }
            else if (brainFuckCode[i] == closedBreakeds)
            {
                countClosedBreakeds = countClosedBreakeds + 1;
            }
            else if (countClosedBreakeds > countOpeningBreakeds)
            {
                break;
            }


        }

        if (countOpeningBreakeds == countClosedBreakeds)
        {
            CheckingFine();
        }

    }
}