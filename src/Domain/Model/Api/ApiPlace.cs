using Domain.Model.Database;

namespace Domain.Model.Api
{
    public class ApiPlace
    {
        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public ApiBuilding Building { get; set; }

        public static Place ToPlace(ApiPlace place)
        {
            return new Place()
            {
                Building = ApiBuilding.ToBuilding(place.Building),
                Latitude = place.Latitude,
                Longitude = place.Longitude
            };
        }
    }
}