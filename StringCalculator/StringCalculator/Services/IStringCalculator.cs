namespace StringCalculator.Services
{
    public interface IStringCalculator
    {
        int Add(string rawInputString);
        string CalculationString { get; }
    }
}