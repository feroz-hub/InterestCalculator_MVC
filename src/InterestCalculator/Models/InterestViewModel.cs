using System.ComponentModel.DataAnnotations;

namespace InterestCalculator.Models;

public class InterestViewModel
{
    [Required]
    [Display(Name = "Principal Amount")]
    public double Principal { get; set; }

    [Required]
    [Display(Name = "Rate (%)")]
    public double Rate { get; set; }

    [Required]
    [Display(Name = "Time (Years)")]
    public double Time { get; set; }

    [Display(Name = "Frequency")]
    public Frequency? Frequency { get;set; }
    
    [Required]
    [Display(Name = "Interest Type")]
    public InterestType InterestType { get; set; }

    public double? InterestAmount { get; set; }
}