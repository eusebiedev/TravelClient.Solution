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
  public IActionResult Details(int id)
  {
    Country country = Country.GetDetails(id);
    return View(country);
  }
  public ActionResult Create()
  {
    return View();
  }

  [HttpPost]
  public ActionResult Create(Country country)
  {
    Country.Post(country);
    return RedirectToAction("Index");
  }

  public ActionResult Edit(int id)
  {
    Country country = Country.GetDetails(id);
    return View(country);
  }

  [HttpPost]
  public ActionResult Edit(int id, Country country)
  {
    Country.Put(country);
    return RedirectToAction("Details", new { id = country.CountryId });
  }
  public ActionResult Delete(int id)
  {
    Country country = Country.GetDetails(id);
    return View(country);
  }

  [HttpPost, ActionName("Delete")]
  public ActionResult DeleteConfirmed(int id)
  {
    Country.Delete(id);
    return RedirectToAction("Index");
  }
}