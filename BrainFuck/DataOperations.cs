

public class DataOperations
{
    private IBrainFuckFunction _brainFuckFunction;

    public DataOperations(IBrainFuckFunction brainFuckFunction)
    {
        _brainFuckFunction = brainFuckFunction;
    }

    public void EnumСodeBrainFuck(string brainFuckCode)
    {
        for (int i = 0; i < brainFuckCode.Length; i++)
        {
            switch (brainFuckCode[i])
            {
                case '+':
                     _brainFuckFunction.NextCharValue();
                    break;
                case '-':
                    _brainFuckFunction.PreviousCharValue();
                    break;
                case '.':
                    _brainFuckFunction.DisplayCellValue();
                    break;
                case '>':
                    _brainFuckFunction.NextCell();
                    break;
                case '<':
                    _brainFuckFunction.PreviusCell();
                    break;
                case ',':
                    _brainFuckFunction.InputValueInCell();
                    break;
                case '[':
                    i = _brainFuckFunction.IfZeroNext(i, brainFuckCode);
                    break;
                case ']':
                    i = _brainFuckFunction.IfNoZeroBack(i, brainFuckCode);
                    break;
            }
        }
    }


}

