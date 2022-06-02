

namespace BrainFuck;

public class Menu
{
    private readonly IMenuTextWriter _menuTextWriter;
    private readonly IInputOutput _inputOutput;

    public Menu(IMenuTextWriter menuTextWriter, IInputOutput inputOutput)
    {
        _menuTextWriter = menuTextWriter;
        _inputOutput = inputOutput;
    }
    public void RunMenu()
    {
        var exitToken = new ExitToken();
        var menuLines = new[]
        {
         new MenuLine("1. Запустить стартовую программу", new DefaultBrainFuckCommand(_inputOutput)),
         new MenuLine("2. Запустить свою программу", new BrainFuckCodeFromUser(_inputOutput)),
         new MenuLine("3. Выйти", new ExitCommand(exitToken))
        };
        var menuIndex = 0;
        _menuTextWriter.PrintMenu(menuLines, menuIndex);

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

            _menuTextWriter.PrintMenu(menuLines, menuIndex);
        }
    }

}



