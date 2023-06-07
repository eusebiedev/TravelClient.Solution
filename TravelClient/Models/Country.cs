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
  }
}