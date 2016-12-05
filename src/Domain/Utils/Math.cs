using Domain.Model.Math;
using Domain.Model.Math.UnitOfMeasures;

namespace Domain.Utils
{
    public static class Math
    {
        public const int MaxDistance = 40;
        public const int MeterPerDagree = 111000;

        public static bool IsInPointOfView(Point p1, Point p2, double azimuth)
        {
            var azimuthTan = System.Math.Tan(DagreeToReadians(azimuth));
            var lineFunction = LineFunction.GetFromTwoPoints(p1, p2);
            var distanceBetween = LenghtOfLineInMap(p1, p2);
            return (System.Math.Abs(azimuthTan - lineFunction.A) < 0.1) && distanceBetween.Value < MaxDistance;
        }

        public static double LenghtOfLine(Point point1, Point point2)
        {
            return
                System.Math.Sqrt((System.Math.Pow((point2.X - point1.X), 2)) +
                                 (System.Math.Pow((point2.Y - point1.Y), 2)));
        }

        public static Meter LenghtOfLineInMap(Point point1, Point point2)
        {
            return new Meter(LenghtOfLine(point1, point2) * MeterPerDagree);
        }

        public static double DagreeToReadians(double dagree)
        {
            return dagree * (System.Math.PI / 180d);
        }
    }
}