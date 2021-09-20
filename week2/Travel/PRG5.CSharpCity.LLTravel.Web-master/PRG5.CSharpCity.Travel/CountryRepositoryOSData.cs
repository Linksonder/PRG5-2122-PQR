using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace PRG5.CSharpCity.Travel
{
    public class CountryRepositoryOSData 
    {
        private static List<Country> countryList = getAll();
       
        private static List<Country> getAll()
        {
            List<Country> countryList = new List<Country>();

            CultureInfo[] cultures = CultureInfo.GetCultures(CultureTypes.SpecificCultures);

            foreach (CultureInfo culture in cultures)
            {
                RegionInfo region = new RegionInfo(culture.LCID);

                if (!countryList.Any(c => c.EnglishName.Equals(region.EnglishName)))
                {
                    countryList.Add(
                        new Country
                        {
                            EnglishName = region.EnglishName,
                            NativeName = region.NativeName,
                            IsMetric = region.IsMetric,
                            ISOCode = region.TwoLetterISORegionName,
                            Capital = "",
                            Currency = new Currency
                            {
                                Code = region.ISOCurrencySymbol,
                                Name = region.Name,
                                Symbol = region.CurrencySymbol
                            },
                           
                        });
                }
            }
            return countryList;
        }

        public List<Country> FindAll()
        {
            return countryList;
        }

        public Country FindCountryByCode(string code)
        {
            return countryList
                        .Where(c => c.ISOCode.Equals(code, StringComparison.OrdinalIgnoreCase))
                        .FirstOrDefault();
        }

        public Country FindCountryByName(string namePart)
        {
            return countryList
                        .Where(c => c.EnglishName.Contains(namePart, StringComparison.OrdinalIgnoreCase))
                        .FirstOrDefault();
        }

        public string GetCapital(string ISOCode)
        {
            return "";
        }
    }
}
