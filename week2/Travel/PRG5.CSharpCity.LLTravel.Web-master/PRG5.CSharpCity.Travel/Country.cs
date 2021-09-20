using System.Collections.Generic;
using System.ComponentModel;
namespace PRG5.CSharpCity.Travel
{
    public class Currency {
        public string Code { get; set;}
        public string Symbol { get; set;}
        public string Name { get; set;}
    }

    public class Country
    {
        public int LCID { get; set; }
        public string ISOCode { get; set;}
        [DisplayName("Country (native)")]
        public string NativeName { get; set;}
        [DisplayName("Metric system")]
        public bool? IsMetric { get; set;}
        public int ContinentId { get; set;}
        [DisplayName("Country (english)")]
        public string EnglishName { get; set;}
        public Currency Currency { get; set;}
        public string Capital { get; set; }
        public string AccessCode { get; set; }
        public string Region { get; set; }
        public string SubRegion { get; set; }
        public List<string> Languages { get; set; }
    }
}
