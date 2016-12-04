namespace Domain.Model.Math
{
    public class LineFunction : IFunction
    {
        public double A { get; }
        public double B { get; }

        public LineFunction(double a, double b)
        {
            A = a;
            B = b;
        }

        public  static LineFunction GetFromTwoPoints(Point point1, Point point2)
        {
            var a = (point1.Y - point2.Y) / (point1.X - point2.X);
            var b = (point1.Y - (point1.X * a));
            return new LineFunction(a, b);
        }
    }
}