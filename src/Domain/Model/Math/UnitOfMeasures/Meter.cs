namespace Domain.Model.Math.UnitOfMeasures
{
    public struct Meter
    {
        public Meter(double value)
        {
            Value = value;
        }

        public double Value { get; }
    }
}