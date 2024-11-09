using InterestCalculator.Interfaces;

namespace InterestCalculator.Models;

public class SimpleInterest(double principal, double rate, double time) :InterestBase(principal, rate, time),IInterestCalculator
{
    public double CalculateInterest()
    {
        return (Principal * Rate * Time) / 100;
    }
}