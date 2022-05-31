

public sealed class MenuLine
{ 
    private ICommand _command;

    public string Name { get;}


    public MenuLine(string name, ICommand command)
    {
        Name = name;
        _command = command; 
    
    }
    public void Execute()
    {
        _command.Execute();
    }
    
}