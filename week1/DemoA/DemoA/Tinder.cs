using DemoA.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoA
{
    class Tinder
    {
        private List<Person> mensjes = new List<Person>();

        public Tinder()
        {
            mensjes.Add(new Person() { Name = "Stijn", Bio = "Houd van boot", Gender = Gender.Other });
            mensjes.Add(new Person() { Name = "Ger", Bio = "Houd van Java", Gender = Gender.Male });
            mensjes.Add(new Person() { Name = "Gelens", Bio = "Houd van C++", Gender = Gender.Male });
            mensjes.Add(new Person() { Name = "Anne", Bio = "Houd van Engels", Gender = Gender.Female });
            mensjes.Add(new Person() { Name = "Vera", Bio = "Houd van SLC", Gender = Gender.Female });
        }

        public void Start()
        {
            //Welkom, cw - tab tab
            Console.WriteLine("Welkom bij Tender!");
            //laat 1 persoon zien
            while(true)
            {
                var persoon = GetRandom();
                Console.WriteLine(String.Format("Hoi ik ben {0} ({3}), en ik ben {1} jaar oud. {2}", 
                    persoon.Name, persoon.Age, persoon.Bio, persoon.Gender));

                ConsoleKeyInfo key = Console.ReadKey();

                if(key.KeyChar == 'r')
                {
                    Console.WriteLine("Wow ik wil wel daten met jou");
                }
                else
                {
                    Console.WriteLine("Nou.... nee bedankt");
                }
            }
            //kies links of rechts
            //laat de volgende zien
        }

        private Person GetRandom()
        {
            Random r = new Random();
            int random = r.Next(mensjes.Count);
            return mensjes[random];
        }
    }
}
