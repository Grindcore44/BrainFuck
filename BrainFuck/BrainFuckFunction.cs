namespace BrainFuck;

public class BrainFuckFunction : IBrainFuckFunction
{
    private IRepository _dataFromRepository;
    private IInputOutput _inputOutput;

    public BrainFuckFunction(IRepository dataFromRepository, IInputOutput inputOutput)
    {
        _dataFromRepository = dataFromRepository;
        _inputOutput = inputOutput;
    }

    public virtual void NextCharValue() //тест есть
    {
        _dataFromRepository.Memory[_dataFromRepository.Current]++;
        // так не рабит нихуя
        //dataFromRepository.Memory[dataFromRepository.Current] = Convert.ToChar(Convert.ToInt32(dataFromRepository.Memory[dataFromRepository.Current]) + 1);
    }
    public virtual void PreviousCharValue() // тест есть
    {

        _dataFromRepository.Memory[_dataFromRepository.Current]--;
        // так не рабит нихуя
        // dataFromRepository.Memory[dataFromRepository.Current] = Convert.ToChar(Convert.ToInt32(dataFromRepository.Memory[dataFromRepository.Current]) - 1);

    }
    public virtual void DisplayCellValue() //тест есть 
    {
        _inputOutput.OutputConsole(Convert.ToString(_dataFromRepository.Memory[_dataFromRepository.Current]));
    }
    public virtual void NextCell() //тест есть 
    {
        if (_dataFromRepository.Current < _dataFromRepository.Memory.Length)
        {
            _dataFromRepository.Current = _dataFromRepository.Current + 1;
        }

    }
    public virtual void PreviusCell() // тест есть 
    {
        if (_dataFromRepository.Current > 0)
        {
            _dataFromRepository.Current = _dataFromRepository.Current - 1;
        }

    }
    public virtual void InputValueInCell()
    {
        _dataFromRepository.Memory[_dataFromRepository.Current] = _inputOutput.GetCharUser();
    }
    public virtual int IfZeroNext(int positionNumber, string brainFuckCode) //тест есть
    {
        if (_dataFromRepository.Memory[_dataFromRepository.Current] == 0)
        {
            int NumberOfopenBrackets = 1;
            while (NumberOfopenBrackets != 0)
            {
                positionNumber++;
                if (brainFuckCode[positionNumber] == '[')
                {
                    NumberOfopenBrackets++;
                }
                if (brainFuckCode[positionNumber] == ']')
                {
                    NumberOfopenBrackets--;
                }
            }
        }
        return positionNumber;
    }
    public virtual int IfNoZeroBack(int positionNumber, string brainFuckCode) //тест есть
    {
        if (_dataFromRepository.Memory[_dataFromRepository.Current] != 0)
        {
            int NumberOfopenBrackets = 1;
            while (NumberOfopenBrackets != 0)
            {
                positionNumber--;
                if (brainFuckCode[positionNumber] == ']')
                {
                    NumberOfopenBrackets++;
                }
                if (brainFuckCode[positionNumber] == '[')
                {
                    NumberOfopenBrackets--;
                }

            }
        }
        return positionNumber;
    }
}

