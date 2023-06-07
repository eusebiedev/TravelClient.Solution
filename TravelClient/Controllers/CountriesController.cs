using Microsoft.AspNetCore.Mvc;
using TravelClient.Models;

namespace TravelClient.Controllers;

public class CountriesController : Controller
{
  public IActionResult Index()
  {
    List<Country> countries = Country.GetCountries();
    return View(countries);
  }
}