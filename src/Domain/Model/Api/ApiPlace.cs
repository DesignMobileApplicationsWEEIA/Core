namespace Domain.Model.Api
{
    public class ApiPlace
    {
        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public ApiBuilding Building { get; set; }

    }
}