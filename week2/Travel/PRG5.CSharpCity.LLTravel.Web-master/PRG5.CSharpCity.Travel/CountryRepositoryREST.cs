using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace PRG5.CSharpCity.Travel
{
    public class CountryRepositoryREST : ICountryRepository
    {
        private readonly HttpClient _httpClient;
        private const string serviceUrl = "https://restcountries.eu/rest/v2/";
        private const string allCommand = "all";
        private List<Country> countryCache;

        public CountryRepositoryREST (IHttpClientFactory httpClientFactory)
        {
            var httpClient = httpClientFactory.CreateClient("CountryRepositoryREST");
            httpClient.BaseAddress = new Uri(serviceUrl);
            _httpClient = httpClient;
            LoadData();
        }

        /// <summary>
        /// Loads data from the datasource, this implementation uses a JSON REST service
        /// </summary>
        private void LoadData()
        {
            List<RestCountry> queryResponse;
            if (countryCache == null)
            {
                List<Country> result = new List<Country>();
                using (HttpResponseMessage response = _httpClient.GetAsync(allCommand).GetAwaiter().GetResult())
                {
                    var responseText = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                    queryResponse = JsonSerializer.Deserialize<List<RestCountry>>(responseText);
                }

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
        /// <returns></returns>
        public List<Country> FindByCurrency(string currency)
        {
            List<Country> result = new List<Country>();
            if (countryCache == null)
            {
                LoadData();
            }
            //do your stuff here
            return result;
        }

        /// <summary>
        /// Finds all countries from our list where specified language is an offical (native) language
        /// </summary>
        /// <param name="language"></param>
        /// <returns></returns>
        public List<Country> FindByLanguage(string language)
        {
            List<Country> result = new List<Country>();
            if (countryCache == null)
            {
                LoadData();
            }
            //do your stuff here
            return result;
        }

        /// <summary>
        /// Finds all countries for our list that belong to a specific region
        /// </summary>
        /// <param name="region"></param>
        /// <returns></returns>
        public List<Country> FindByRegion(string region)
        {
            List<Country> result = new List<Country>();
            if (countryCache == null)
            {
                LoadData();
            }
            //do your stuff here
            return result;
        }
    }
}
