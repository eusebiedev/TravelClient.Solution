// using System.Collections.Generic;
// using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TravelClient.Models
{
  public class Country
  {
    public int CountryId { get; set; }
    public string Name { get; set; }
    public string Language { get; set; }
    public int Population { get; set; }
    public string Climate { get; set; }
    public static List<Country> GetCountries()
    {
      var apiCallTask = ApiHelper.GetAll();
      var result = apiCallTask.Result;

      JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
      List<Country> countryList = JsonConvert.DeserializeObject<List<Country>>(jsonResponse.ToString());

      return countryList;
    }
    public static Country GetDetails(int id)
    {
      var apiCallTask = ApiHelper.Get(id);
      var result = apiCallTask.Result;

      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      Country country = JsonConvert.DeserializeObject<Country>(jsonResponse.ToString());

      return country;
    }
    public static void Post(Country country)
    {
      string jsonCountry = JsonConvert.SerializeObject(country);
      ApiHelper.Post(jsonCountry);
    }
    public static void Put(Country country)
    {
      string jsonCountry = JsonConvert.SerializeObject(country);
      ApiHelper.Put(country.CountryId, jsonCountry);
    }

    public static void Delete(int id)
    {
      ApiHelper.Delete(id);
    }
  }
}