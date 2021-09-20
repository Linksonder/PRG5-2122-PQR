using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace PRG5.CSharpCity.Travel
{
    public class CountryRepositoryFile : ICountryRepository
    {
        private const string allCommand = "all";
        private List<Country> countryCache;



        public CountryRepositoryFile()
        {
            LoadData();
        }

        private void LoadData()
        {
            List<RestCountry> queryResponse;
            List<Country> result = new List<Country>();
            var folderDetails = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot\\{"MasterData\\masterdata.json"}");
            var JSON = System.IO.File.ReadAllText(folderDetails);
            queryResponse = JsonSerializer.Deserialize<List<RestCountry>>(JSON);


            queryResponse.ForEach(c => result.Add(
                new Country
                {
                    Capital = c.capital,
                    EnglishName = c.name,
                    NativeName = c.nativeName,
                    ISOCode = c.alpha3Code,
                    LCID = Convert.ToInt32(c.numericCode),
                    Region = c.region,
                    SubRegion = c.subregion,
                    Currency = c.currencies.Any() ? new Currency
                    {
                        Code = c.currencies.First().code,
                        Name = c.currencies.First().name,
                        Symbol = c.currencies.First().symbol
                    } : null,
                    Languages = c.languages.Select(l => l.name).ToList()
                }
                ));
            countryCache = result;
        }

        /// <summary>
        /// Finds all available countries
        /// </summary>
        /// <returns></returns>
        public List<Country> FindAll()
        {
            if (countryCache == null)
            {
                LoadData();
            }
            return countryCache;
        }

        /// <summary>
        /// Finds all countries use a specific currency
        /// </summary>
        /// <param name="currency">€,$,etc</param>
        /// <returns>List of countries using that currency, if any</returns>
        public List<Country> FindByCurrency(string currency)
        {
            List<Country> result = new List<Country>();
            if (countryCache == null)
            {
                LoadData();
            }
           
            // filter here
            return result;
        }

        /// <summary>
        /// Finds all countries from our list where specified language is an offical (native) language
        /// </summary>
        /// <param name="language"></param>
        /// <returns>List of countries where specified language is a native language</returns>
        public List<Country> FindByLanguage(string language)
        {
            List<Country> result = new List<Country>();
            if (countryCache == null)
            {
                LoadData();
            }

            // filter here
            //TODO: 
            return result;
        }

        /// <summary>
        /// Finds all countries for our list that belong to a specific region
        /// </summary>
        /// <param name="region"></param>
        /// <returns>List of countries that belong to specified region, if any</returns>
        public List<Country> FindByRegion(string region)
        {
            //Een lege lijst waar we de spullen gaan bewaren!
            List<Country> result = new List<Country>();
            
            //ons lijstje met alle landen
            List<Country> allCountries = FindAll();

            result = allCountries.Where(country=> country.Region == region).ToList();

            return result;
            
        }
    }
}
