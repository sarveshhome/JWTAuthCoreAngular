using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace TestAppDemo
{
    class Program
    {
        static void Main(string[] args)
        {

            Goldmedal objgoldmedal = new Goldmedal()
            {
                journeys = new journeys()
                {
                    departureIATA = "LON",
                    arrivalIATA = "BKK",
                    cabinClass = "C"
                },
                passengers = new passengers()
                {
                    age = 30
                }
            };
            string jsonstring = JsonConvert.SerializeObject(objgoldmedal);
            


            Console.WriteLine(jsonstring);
            Console.ReadLine();
        }
    }
    class Goldmedal
    {
        public journeys journeys;

        public passengers passengers;
    }
    class journeys
    {
        public string departureIATA { get; set; }

        public string arrivalIATA;

        public string cabinClass;
    }
    class passengers
    {
        public int age;
    }
}
