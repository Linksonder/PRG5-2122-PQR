using PRG5.CSharpCity.Travel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PRG5.CSharpCity.LLTravel.Web.Models
{
    public class DestinationViewModel
    {
        public List<Country> Countries { get; set; }

        public string SortedBy { get; set; }

        public Country FilterData { get; set; }

    }
}
