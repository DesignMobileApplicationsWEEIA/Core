using System;

namespace Core.Domain.Model
{
    public class Place
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public Building Building { get; set; }
        
        public Place()
        {

        }
    }
}
