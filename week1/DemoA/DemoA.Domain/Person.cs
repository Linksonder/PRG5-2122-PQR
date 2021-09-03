using System;

namespace DemoA.Domain
{
    public class Person
    {
        public String Name { get; set; }

        public int Age
        {
            get 
            {
                //tip: zoek op de docs naar Timespan!
                //huh welke docs? Die van Microsoft natuurlijk! Gewoon op de het een internet. 
                TimeSpan result = DateTime.Now - DateOfBirth;
                double result2 = result.Days / 365;
                return (int) Math.Round(result2);
                
                //bereken hier de leeftijd op basis van geboortedatum//
            }
        }

        public DateTime DateOfBirth { get; set; }
        public String Bio { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public Gender Gender { get; set; }
    }

    public enum Gender
    {
        Male, Female, Other
    }
}
