namespace Domain.Model
{
    public struct Point
    {
        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double X { get; }
        public double Y { get; }

        public static implicit operator Point(PhoneLocation phoneData)
        {
            return new Point(phoneData.Latitude, phoneData.Longitude);
        }
    }
}