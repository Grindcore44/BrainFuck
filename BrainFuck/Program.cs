

namespace BrainFuck;
public static class Program
{
    public static void Main() // Задание на дом:
                              // Реализовать новый пункт меню, где при его выборе просит у пользователя ввести в консоль программу на брэйнфаке и исполнить её.
    {
      var consoleCoursorWrapper = new ConsoleCursorWrapper();
      var inputOutput = new InputOutput(Console.In, Console.Out, consoleCoursorWrapper);
      var menu = new Menu(inputOutput, inputOutput);

        menu.RunMenu();
    }

}

public interface ICursorWrapper
{ 
    void SetCursorPosition(int left, int top); // принимает значение по высоте и долготе и переносит туда курсор пользователя 

}

public class ConsoleCursorWrapper : ICursorWrapper
{
    public void SetCursorPosition(int left, int top)
    { 
     Console.SetCursorPosition(left, top);
    }

}

public interface IMenuTextWriter
{
    void PrintMenu(MenuLine[] menuLines, int selectedMenuIndex);

}
