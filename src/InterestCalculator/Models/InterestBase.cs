namespace InterestCalculator.Models;

public abstract class InterestBase(double principal, double rate, double time)
{
    public double Principal { get; set; } = principal;
    public double Rate { get; set; } = rate; // Annual rate in percentage
    public double Time { get; set; } = time; // Time in years
}