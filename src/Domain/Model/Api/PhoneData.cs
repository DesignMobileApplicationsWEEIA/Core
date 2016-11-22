namespace Domain.Model.Database
{
    public class PhoneData
    {
        public double Direction { get; set; }
        public PhoneLocation PhoneLocation { get; set; }

        public bool IsInVisualField(Building building)
        {
//            var x = building.Places.Select(place =>
//            {
//                var b1 = Math.Sign(PhoneLocation, new Point(place.Latitude, place.Longitude), new Point());
//
//            });
            return true;
        }
    }
}