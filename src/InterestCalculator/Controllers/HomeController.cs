using System.Diagnostics;
using InterestCalculator.Interfaces;
using InterestCalculator.Models;
using Microsoft.AspNetCore.Mvc;

namespace InterestCalculator.Controllers;

public class HomeController(ILogger<HomeController> logger) : Controller
{
    private readonly ILogger<HomeController> _logger = logger;

    public IActionResult Index()
    {
        return View(new InterestViewModel());
    }
   
    [HttpPost]
    public ActionResult Calculate(InterestViewModel model)
    {
        if (ModelState.IsValid)
        {
            IInterestCalculator calculator = null;

            // Check if InterestType is Simple
            if (model.InterestType == InterestType.Simple)
            {
                calculator = new SimpleInterest(model.Principal, model.Rate, model.Time);
            }
            // Check if InterestType is Compound and Frequency is selected
            else if (model.InterestType == InterestType.Compound && model.Frequency != null && model.Frequency != 0)
            {
                // Validate the frequency value (Annually = 1, Quarterly = 2, Monthly = 3)
                int frequency = (int)model.Frequency;
                calculator = new CompoundInterest(model.Principal, model.Rate, model.Time, frequency);
            }

            // If calculator is not null, calculate the interest
            if (calculator != null)
            {
                model.InterestAmount = calculator.CalculateInterest();
            }
            else
            {
                ModelState.AddModelError("", "Please select a valid frequency for Compound Interest.");
            }
        }

        // Return to the same view with the model to display the result
        return View("Index", model);
    }


    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
