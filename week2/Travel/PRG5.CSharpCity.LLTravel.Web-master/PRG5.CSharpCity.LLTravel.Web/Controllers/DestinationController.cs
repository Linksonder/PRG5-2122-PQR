using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using PRG5.CSharpCity.LLTravel.Web.Models;
using PRG5.CSharpCity.Travel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PRG5.CSharpCity.LLTravel.Web.Controllers
{
    public class DestinationController : Controller
    {
        private readonly ICountryRepository _countryRepository;

        private readonly ILogger<DestinationController> _logger;

        public DestinationController(ILogger<DestinationController> logger, ICountryRepository repository)
        {
            _logger = logger;
            _countryRepository = repository;
        }

        public IActionResult Index()
        {
            DestinationViewModel result = new DestinationViewModel();

            // The find all method returns a list of all destinations
            result.Countries = _countryRepository.FindAll().ToList();
            PrepViewBag();
            return View("AllDestinations",result);
        }

        public IActionResult Sort(string id)
        {
            DestinationViewModel result = new DestinationViewModel();

            // FindAll returns all destinations, we order those by the EnglishName and return the result
            result.Countries = _countryRepository.FindAll().OrderBy(p => p.EnglishName).ToList();
            result.SortedBy = id;
            PrepViewBag();
            return View("AllDestinations", result);
        }

        [HttpPost]
        public IActionResult Filter(DestinationViewModel src)
        {
            DestinationViewModel result = new DestinationViewModel();
            IEnumerable<Country> list = _countryRepository.FindAll();
            // If there is any filter data, we add filters to our list using the Where statement (just like SQL)
            if (src.FilterData != null)
            {
                if (!string.IsNullOrWhiteSpace(src.FilterData.EnglishName))
                {
                    // Where contains a Lambda expression. this expression returns True if the English Name contains the filter data
                    // false if it doesn't. 
                    list = list.Where(c => c.EnglishName.Contains(src.FilterData.EnglishName, StringComparison.OrdinalIgnoreCase));
                }
                if (!(src.FilterData.Currency == null) && !string.IsNullOrWhiteSpace(src.FilterData.Currency.Symbol))
                {
                    // if currency is set as well, we at a where clause to our query checking if the country has a currency with a matching symbol
                    list = list.Where(c => c.Currency != null && !string.IsNullOrWhiteSpace(c.Currency.Symbol) && c.Currency.Symbol.Contains(src.FilterData.Currency.Symbol, StringComparison.OrdinalIgnoreCase));
                }
                if (!(src.FilterData.Region == null))
                {
                    // if region is filled, we add a where that only selects countries for that region
                    list = list.Where(c => c.Region.Equals(src.FilterData.Region));
                }
            }
            // with all filters complete, we execute the query by call the ToList method.

            // the filtered data should be ordered:
            // first by subregion
            // then by country name
            result.Countries = list.ToList();
            PrepViewBag();
            return View("AllDestinations", result);
        }

        public IActionResult EuroArea()
        {
            DestinationViewModel destinations = new DestinationViewModel();
            destinations.Countries = _countryRepository.FindByCurrency("€");
            ViewBag.FilterName = "Euro area";
            return View("FilteredDestinations", destinations);
        }

        public IActionResult EnglishSpeaking()
        {
            DestinationViewModel destinations = new DestinationViewModel();
            destinations.Countries = _countryRepository.FindByLanguage("English");
            ViewBag.FilterName = "English speaking";
            return View("FilteredDestinations", destinations);
        }

        public IActionResult JustAfrica()
        {
            DestinationViewModel destinations = new DestinationViewModel();
            destinations.Countries = _countryRepository.FindByRegion("Africa");
            ViewBag.FilterName = "African";
            return View("FilteredDestinations", destinations);
        }

        private void PrepViewBag()
        {
            ViewBag.Regions = new List<SelectListItem>();
            ViewBag.Regions.Add(new SelectListItem() { Text = "...", Value = "" });

            // We FindAll destinations, select all regions for those destinations and then use a distinct just like we would in SQL
            // the data is ordered by the data itself (c is the region name) so alphabetical by region
            // the SelectListItem we create is needed to fill a HTML select form input
            ViewBag.Regions.AddRange(_countryRepository.FindAll().Select(c => c.Region).Distinct().OrderBy(c => c).Select(c => new SelectListItem() { Text = c, Value = c }));

        }
    }
}
