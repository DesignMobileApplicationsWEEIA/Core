using Domain.Model.Math;
using Domain.Model.Math.UnitOfMeasures;

namespace Domain.Utils
{
    public static class Math
    {
        public static double Sign(Point p1, Point p2, Point p3)
        {
            return (p1.X - p3.X) * (p2.Y - p3.Y) - (p2.X - p3.X) * (p1.Y - p3.Y);
        }

        public static bool IsInTriangle(Point pt, Point p1, Point p2, Point p3)
        {
            bool c1, c2, c3;

            c1 = Sign(pt, p1, p2) < 0.0d;
            c2 = Sign(pt, p2, p3) < 0.0d;
            c3 = Sign(pt, p3, p1) < 0.0d;

            return c1 && c2 && c3;
        }

        public static bool IsInPointOfView(Point p1, Point p2, double azimuth)
        {
            var azimuthTan = System.Math.Tan(azimuth);
            var lineFunction = LineFunction.GetFromTwoPoints(p1, p2);
            var distanceBetween = LenghtOfLineInMap(p1, p2);
            return (System.Math.Abs(azimuthTan - lineFunction.A) < 0.1);
        }

        public static double LenghtOfLine(Point point1, Point point2)
        {
            return
                System.Math.Sqrt((System.Math.Pow((point2.X - point1.X), 2)) +
                                 (System.Math.Pow((point2.Y - point1.Y), 2)));
        }

        public static Meter LenghtOfLineInMap(Point point1, Point point2)
        {
            return new Meter(LenghtOfLine(point1, point2) * 73000);
        }
    }
}