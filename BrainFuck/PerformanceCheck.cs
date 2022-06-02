namespace BrainFuck;

public class PerformanceCheck
{
    public bool Performance { get; private set; } //get - получить set - меняем значение

    public PerformanceCheck()
    {
        Performance = false;
    }

    private void CheckingFine()
    {
        Performance = true;
    }

    public void CheckBrackets(string brainFuckCode)
    {
        var openingBreakeds = '[';
        var closedBreakeds = ']';
        int countBreakeds = 0;


        for (int i = 0; i < brainFuckCode.Length; i++)
        {
            if (brainFuckCode[i] == openingBreakeds)
            {
                countBreakeds = countBreakeds + 1;
            }
            else if (brainFuckCode[i] == closedBreakeds)
            {
                countBreakeds = countBreakeds - 1;
            }
            else if (countBreakeds < 0)
            {
                break;
            }


        }

        if (countBreakeds == 0)
        {
            CheckingFine();
        }

    }
}