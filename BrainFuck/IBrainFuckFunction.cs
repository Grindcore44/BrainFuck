public interface IBrainFuckFunction
{
    void NextCharValue();
    void PreviousCharValue();
    void DisplayCellValue();
    void NextCell();
    void PreviusCell();
    void InputValueInCell();
    int IfZeroNext(int positionNumber, string brainFuckCode);
    int IfNoZeroBack(int positionNumber, string brainFuckCode);
}

