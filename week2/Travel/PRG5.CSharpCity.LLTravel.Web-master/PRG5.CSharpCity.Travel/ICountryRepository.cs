using System.Collections.Generic;

namespace PRG5.CSharpCity.Travel
{
    public interface ICountryRepository
    {
        List<Country> FindAll();
        List<Country> FindByCurrency(string currency);
        List<Country> FindByLanguage(string language);
        List<Country> FindByRegion(string region);
    }
}
