using InterestCalculator.Interfaces;

namespace InterestCalculator.Models;

public class CompoundInterest(double principal, double rate, double time, int frequency)
    : InterestBase(principal, rate, time), IInterestCalculator
{
    private int Frequency { get; } = frequency; // Number of times interest is compounded per year

    public double CalculateInterest()
    {
        var interest= Principal * Math.Pow(1 + Rate / (100 * Frequency), Frequency * Time) - Principal;
        return  Math.Round(interest, 2);
    }
}