namespace BrainFuck;

public class InputOutput : IInputOutput, IMenuTextWriter
{
    private TextReader Reader;
    private TextWriter Writer;
    private readonly ICursorWrapper _cursorWrapper;

    public InputOutput(TextReader output, TextWriter input, ICursorWrapper CursorWrapper)
    {
        Reader = output;
        Writer = input;
        _cursorWrapper = CursorWrapper;

    }
   

    public char GetCharUser()
    {
        while (true)
        {
            string userInput = GetStringUser();
            if (char.TryParse(userInput, out char result))
            {
                return result;
            }
        }

    }

    public string GetStringUser()
    {

        return Reader.ReadLine();
    }
    public void OutputConsole(string messageOrChar)
    {
        Writer.Write(messageOrChar);
    }

    public void PrintMenu(MenuLine[] menuLines, int menuIndex)
    {

        _cursorWrapper.SetCursorPosition(0, 0);

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

public interface IInputOutput
{
    char GetCharUser();
    string GetStringUser();
    void OutputConsole(string messageOrChar);
}