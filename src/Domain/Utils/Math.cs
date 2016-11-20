using Domain.Model;

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

    }
}