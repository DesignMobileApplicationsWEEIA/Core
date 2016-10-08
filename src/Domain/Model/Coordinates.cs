namespace Core.Domain.Model
{
    public sealed class Coordinates : BaseEntity
    {
        public double X { get; set; }

        public double Y { get; set; }

        public double Z { get; set; }

        public Coordinates()
        {
        }
    }
}
